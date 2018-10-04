using System;
using System.Collections.Generic;

namespace WebAdminElGas.Data
{
    public partial class Sector
    {
        public Sector()
        {
            Cliente = new HashSet<Cliente>();
            Distribuidor = new HashSet<Distribuidor>();
            PuntoSector = new HashSet<PuntoSector>();
            SectorDistribuidor = new HashSet<SectorDistribuidor>();
        }

        public int IdSector { get; set; }
        public string Nombre { get; set; }
        public int? IdCiudad { get; set; }

        public Ciudad IdCiudadNavigation { get; set; }
        public ICollection<Cliente> Cliente { get; set; }
        public ICollection<Distribuidor> Distribuidor { get; set; }
        public ICollection<PuntoSector> PuntoSector { get; set; }
        public ICollection<SectorDistribuidor> SectorDistribuidor { get; set; }
    }
}
