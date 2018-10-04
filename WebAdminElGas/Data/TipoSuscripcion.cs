using System;
using System.Collections.Generic;

namespace WebAdminElGas.Data
{
    public partial class TipoSuscripcion
    {
        public int IdTipoSuscripcion { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double? Precio { get; set; }
        public int? Prioridad { get; set; }
    }
}
