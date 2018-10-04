﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAdminElGas.Data;

namespace WebAdminElGas.Controllers
{
    public class ClientesController : Controller
    {
        private readonly ELGASContext _context;

        public ClientesController(ELGASContext context)
        {
            _context = context;
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            var eLGASContext = _context.Cliente.Include(c => c.IdAspNetUserNavigation).Include(c => c.IdSectorNavigation);
            return View(await eLGASContext.ToListAsync());
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente
                .Include(c => c.IdAspNetUserNavigation)
                .Include(c => c.IdSectorNavigation)
                .SingleOrDefaultAsync(m => m.IdCliente == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            ViewData["IdAspNetUser"] = new SelectList(_context.AspNetUsers, "Id", "Id");
            ViewData["IdSector"] = new SelectList(_context.Sector, "IdSector", "IdSector");
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCliente,Identificacion,Nombres,Apellidos,Direccion,Longitud,Latitud,Telefono,Correo,IdAspNetUser,DeviceId,Habilitado,FechaRegistro,IdSector,SistemaOperativo")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAspNetUser"] = new SelectList(_context.AspNetUsers, "Id", "Id", cliente.IdAspNetUser);
            ViewData["IdSector"] = new SelectList(_context.Sector, "IdSector", "IdSector", cliente.IdSector);
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente.SingleOrDefaultAsync(m => m.IdCliente == id);
            if (cliente == null)
            {
                return NotFound();
            }
            ViewData["IdAspNetUser"] = new SelectList(_context.AspNetUsers, "Id", "Id", cliente.IdAspNetUser);
            ViewData["IdSector"] = new SelectList(_context.Sector, "IdSector", "IdSector", cliente.IdSector);
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCliente,Identificacion,Nombres,Apellidos,Direccion,Longitud,Latitud,Telefono,Correo,IdAspNetUser,DeviceId,Habilitado,FechaRegistro,IdSector,SistemaOperativo")] Cliente cliente)
        {
            if (id != cliente.IdCliente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.IdCliente))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAspNetUser"] = new SelectList(_context.AspNetUsers, "Id", "Id", cliente.IdAspNetUser);
            ViewData["IdSector"] = new SelectList(_context.Sector, "IdSector", "IdSector", cliente.IdSector);
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente
                .Include(c => c.IdAspNetUserNavigation)
                .Include(c => c.IdSectorNavigation)
                .SingleOrDefaultAsync(m => m.IdCliente == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cliente = await _context.Cliente.SingleOrDefaultAsync(m => m.IdCliente == id);
            _context.Cliente.Remove(cliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
            return _context.Cliente.Any(e => e.IdCliente == id);
        }
    }
}
