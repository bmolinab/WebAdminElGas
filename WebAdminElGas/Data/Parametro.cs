using System;
using System.Collections.Generic;

namespace WebAdminElGas.Data
{
    public partial class Parametro
    {
        public int IdParametro { get; set; }
        public string Nombre { get; set; }
        public double? Valor { get; set; }
        public string Mensaje { get; set; }
    }
}
