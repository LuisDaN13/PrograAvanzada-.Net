using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pagina_Web.Entidades
{
    public class TiposCategoria
    {
        public int IdCategoria { get; set; }
        public string NombreCategoria { get; set; }
    }
    public class ConfirmacionTiposCategoria
    {
        public int Codigo { get; set; }
        public string Detalle { get; set; }
        public object Datos { get; set; }
        public object Dato { get; set; }
    }
}