using System;
using System.Collections.Generic;

namespace WebAdminElGas.Data
{
    public partial class Cobertura
    {
        public Cobertura()
        {
            PuntoCobertura = new HashSet<PuntoCobertura>();
        }

        public int IdCobertura { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public ICollection<PuntoCobertura> PuntoCobertura { get; set; }
    }
}
