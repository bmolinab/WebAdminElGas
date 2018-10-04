using System;
using System.Collections.Generic;

namespace WebAdminElGas.Data
{
    public partial class Ciudad
    {
        public Ciudad()
        {
            Sector = new HashSet<Sector>();
        }

        public int IdCiudad { get; set; }
        public string Nombre { get; set; }

        public ICollection<Sector> Sector { get; set; }
    }
}
