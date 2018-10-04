using System;
using System.Collections.Generic;

namespace WebAdminElGas.Data
{
    public partial class PuntoSector
    {
        public int IdPuntoSector { get; set; }
        public double? Latitud { get; set; }
        public double? Longitud { get; set; }
        public int IdSector { get; set; }

        public Sector IdSectorNavigation { get; set; }
    }
}
