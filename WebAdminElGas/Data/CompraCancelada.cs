using System;
using System.Collections.Generic;

namespace WebAdminElGas.Data
{
    public partial class CompraCancelada
    {
        public int IdCompraCancelada { get; set; }
        public int IdCompra { get; set; }
        public int? IdCliente { get; set; }
        public int? IdDistribuidor { get; set; }
        public DateTime? Fecha { get; set; }
        public int CanceladaPor { get; set; }

        public Cliente IdClienteNavigation { get; set; }
        public Compra IdCompraNavigation { get; set; }
        public Distribuidor IdDistribuidorNavigation { get; set; }
    }
}
