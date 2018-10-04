using System;
using System.Collections.Generic;

namespace WebAdminElGas.Data
{
    public partial class Bodega
    {
        public Bodega()
        {
            Distribuidor = new HashSet<Distribuidor>();
        }

        public int IdBodega { get; set; }
        public string NombreBodega { get; set; }
        public string Direccion { get; set; }
        public string TelfContacto { get; set; }
        public string NombreContacto { get; set; }

        public ICollection<Distribuidor> Distribuidor { get; set; }
    }
}
