using Api_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_Web.Entidades
{
    public class Producto
    {
        public long Consecutivo { get; set; }
        public string NombreProducto { get; set; }
        public string Precio { get; set; }
        public string Inventario { get; set; }
        public long Estado { get; set; }
        public string RutaImagen { get; set; }
        public string IdCategoria { get; set; }
        public string NombreCateogria { get; set; }
    }

    public class ConfirmacionProducto
    {
        public int Codigo { get; set; }
        public string Detalle { get; set; }
        public List<ConsultarProductos_Result> Datos { get; set; }
        public object Dato { get; set; }
    }
}