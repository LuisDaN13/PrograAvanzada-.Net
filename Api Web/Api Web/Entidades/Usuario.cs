using Api_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_Web.Entidades
{
    public class Usuario
    {
        public long Consecutivo { get; set; }
        public string Identificacion { get; set; }
        public string Contrasenna { get; set; }
        public string Nombre { get; set; }
        public string CorreoElectronico { get; set; }
        public bool Estado { get; set; }
        public long ConsecutivoRol { get; set; }
        public string NombreRol { get; set; }
    }
    public class ConfirmacionUsuario
    {
        public int Codigo { get; set; }
        public string Detalle { get; set; }
        public object Datos { get; set; }
        public object Dato { get; set; }
    }
}