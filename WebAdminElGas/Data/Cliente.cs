using System;
using System.Collections.Generic;

namespace WebAdminElGas.Data
{
    public partial class Cliente
    {
        public Cliente()
        {
            Compra = new HashSet<Compra>();
            CompraCancelada = new HashSet<CompraCancelada>();
        }

        public int IdCliente { get; set; }
        public string Identificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public double? Longitud { get; set; }
        public double? Latitud { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string IdAspNetUser { get; set; }
        public string DeviceId { get; set; }
        public bool? Habilitado { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public int? IdSector { get; set; }
        public int? SistemaOperativo { get; set; }

        public AspNetUsers IdAspNetUserNavigation { get; set; }
        public Sector IdSectorNavigation { get; set; }
        public ICollection<Compra> Compra { get; set; }
        public ICollection<CompraCancelada> CompraCancelada { get; set; }
    }
}
