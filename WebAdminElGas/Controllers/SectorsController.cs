using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAdminElGas.Data;
using WebAdminElGas.Models;

namespace WebAdminElGas.Controllers
{
    public class SectorsController : Controller
    {
        private readonly ELGASContext _context;

        public SectorsController(ELGASContext context)
        {
            _context = context;
        }

        // GET: Sectors
        public async Task<IActionResult> Index()
        {
            var eLGASContext = _context.Sector.Include(s => s.IdCiudadNavigation);
            return View(await eLGASContext.ToListAsync());
        }

        // GET: Sectors/Details/5

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            

            var sector = await _context.Sector
                .Include(s => s.IdCiudadNavigation)
                .SingleOrDefaultAsync(m => m.IdSector == id);
            if (sector == null)
            {
                return NotFound();
            }

            return View(sector);



        }

        public async Task<JsonResult> DetalleSector(int IdSector)
        {
            if (IdSector <= 0)
            {
                return Json(false);
            }


            var response = await _context.PuntoSector.Where(x => x.IdSector == IdSector).ToListAsync();

            if (response == null)
            {
                return Json(false);
            }

            //var listaRequest = new List<PuntoSector>();

            //foreach (var item in response)
            //{
            //    listaRequest.Add(new PuntosRequest { lat = (Double)item.Latitud, lng = (Double)item.Longitud });
            //}

            return Json(response);
        }


        // GET: Sectors/Create
        public IActionResult Create()
        {
            ViewData["IdCiudad"] = new SelectList(_context.Ciudad, "IdCiudad", "Nombre");
            return View();
        }

        // POST: Sectors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSector,Nombre,IdCiudad")] Sector sector)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sector);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCiudad"] = new SelectList(_context.Ciudad, "IdCiudad", "Nombre", sector.IdCiudad);
            return View(sector);
        }

        // GET: Sectors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sector = await _context.Sector.SingleOrDefaultAsync(m => m.IdSector == id);
            if (sector == null)
            {
                return NotFound();
            }
            ViewData["IdCiudad"] = new SelectList(_context.Ciudad, "IdCiudad", "Nombre", sector.IdCiudad);
            return View(sector);
        }

        // POST: Sectors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSector,Nombre,IdCiudad")] Sector sector)
        {
            if (id != sector.IdSector)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sector);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SectorExists(sector.IdSector))
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
            ViewData["IdCiudad"] = new SelectList(_context.Ciudad, "IdCiudad", "Nombre", sector.IdCiudad);
            return View(sector);
        }

        // GET: Sectors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sector = await _context.Sector
                .Include(s => s.IdCiudadNavigation)
                .SingleOrDefaultAsync(m => m.IdSector == id);
            if (sector == null)
            {
                return NotFound();
            }

            return View(sector);
        }

        // POST: Sectors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sector = await _context.Sector.SingleOrDefaultAsync(m => m.IdSector == id);
            _context.Sector.Remove(sector);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SectorExists(int id)
        {
            return _context.Sector.Any(e => e.IdSector == id);
        }


        public async Task<JsonResult> InsertarSector(string nombreSector, List<Posiciones> arreglo)
        {

            //if (string.IsNullOrEmpty(nombreSector) || arreglo.Count <= 2)
            //{
            //    return Json(false);
            //}

            //IdentityPersonalizado ci = (IdentityPersonalizado)HttpContext.User.Identity;
            //string nombreUsuario = ci.Identity.Name;
            //var administrador = new Administrador { Nombre = nombreUsuario };
            //administrador = await ProveedorAutenticacion.GetUser(administrador);

            //var lista = new List<PuntoSector>();

            //foreach (var item in arreglo)
            //{
            //    //item.latitud=item.latitud.Replace(".", ",");
            //    //item.longitud=item.longitud.Replace(".", ",");
            //    lista.Add(new PuntoSector { Latitud = Convert.ToDouble(item.latitud), Longitud = Convert.ToDouble(item.longitud) });

            //}

            //var sector = new SectorViewModel
            //{
            //    Sector = new Sector { NombreSector = nombreSector, EmpresaId = administrador.EmpresaId },
            //    PuntoSector = lista,
            //};



            //var response = await ApiServicio.InsertarAsync(sector, new Uri(WebApp.BaseAddress), "/api/Sectors/InsertarSector");
            //if (!response.IsSuccess)
            //{
            //    return Json(false);
            //}
            return Json(true);
        }
    }
}
