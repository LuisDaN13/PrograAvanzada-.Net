using Api_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_Web.Entidades
{
    public class TiposRoles
    {
        public int ConsecutivoRol { get; set; }
        public string NombreRol { get; set; }
    }
    public class ConfirmacionTiposRoles
    {
        public int Codigo { get; set; }
        public string Detalle { get; set; }
        public List<ConsultarTiposRoles_Result> Datos { get; set; }
        public ConsultarTiposRoles_Result Dato { get; set; }
    }
}