using System;
using System.Collections.Generic;

namespace WebAdminElGas.Data
{
    public partial class Ruta
    {
        public int IdRuta { get; set; }
        public int? IdDistribuidor { get; set; }
        public double? Longitud { get; set; }
        public double? Latitud { get; set; }
        public DateTime? Fecha { get; set; }

        public Distribuidor IdDistribuidorNavigation { get; set; }
    }
}
