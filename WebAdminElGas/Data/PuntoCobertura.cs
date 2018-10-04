using System;
using System.Collections.Generic;

namespace WebAdminElGas.Data
{
    public partial class PuntoCobertura
    {
        public int IdPuntoCobertura { get; set; }
        public double? Latitud { get; set; }
        public double? Longitud { get; set; }
        public int? IdCobertura { get; set; }

        public Cobertura IdCoberturaNavigation { get; set; }
    }
}
