using System;
using System.Collections.Generic;

namespace WebAdminElGas.Data
{
    public partial class Distribuidor
    {
        public Distribuidor()
        {
            Compra = new HashSet<Compra>();
            CompraCancelada = new HashSet<CompraCancelada>();
            Ruta = new HashSet<Ruta>();
            SectorDistribuidor = new HashSet<SectorDistribuidor>();
        }

        public int IdDistribuidor { get; set; }
        public string Identificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string PlacaVehiculo { get; set; }
        public int? Prioridad { get; set; }
        public int? IdTipoSuscripcion { get; set; }
        public string IdAspNetUser { get; set; }
        public string DeviceId { get; set; }
        public bool? Habilitado { get; set; }
        public string FirebaseId { get; set; }
        public int? IdSector { get; set; }
        public string Direccion { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public int? IdBodega { get; set; }

        public Bodega IdBodegaNavigation { get; set; }
        public Sector IdSectorNavigation { get; set; }
        public ICollection<Compra> Compra { get; set; }
        public ICollection<CompraCancelada> CompraCancelada { get; set; }
        public ICollection<Ruta> Ruta { get; set; }
        public ICollection<SectorDistribuidor> SectorDistribuidor { get; set; }
    }
}
