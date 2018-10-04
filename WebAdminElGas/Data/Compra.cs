using System;
using System.Collections.Generic;

namespace WebAdminElGas.Data
{
    public partial class Compra
    {
        public Compra()
        {
            CompraCancelada = new HashSet<CompraCancelada>();
        }

        public int IdCompra { get; set; }
        public int? IdCliente { get; set; }
        public int? IdDistribuidor { get; set; }
        public int? Estado { get; set; }
        public double? Longitud { get; set; }
        public double? Latitud { get; set; }
        public int? Cantidad { get; set; }
        public double? ValorTotal { get; set; }
        public int? Calificacion { get; set; }
        public DateTime? FechaPedido { get; set; }
        public DateTime? FechaAplica { get; set; }
        public DateTime? FechaFinalizacion { get; set; }
        public string Direccion { get; set; }
        public string Referencia { get; set; }
        public int? EstadoNotificacion { get; set; }
        public string Barrio { get; set; }
        public string Sector { get; set; }

        public Cliente IdClienteNavigation { get; set; }
        public Distribuidor IdDistribuidorNavigation { get; set; }
        public ICollection<CompraCancelada> CompraCancelada { get; set; }
    }
}
