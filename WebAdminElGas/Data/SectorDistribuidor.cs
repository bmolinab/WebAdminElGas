using System;
using System.Collections.Generic;

namespace WebAdminElGas.Data
{
    public partial class SectorDistribuidor
    {
        public int IdSectorDistribuidor { get; set; }
        public int? IdSector { get; set; }
        public int? IdDistribuidor { get; set; }

        public Distribuidor IdDistribuidorNavigation { get; set; }
        public Sector IdSectorNavigation { get; set; }
    }
}
