//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Api_Web.Models
{
    using System;
    
    public partial class ConsultarUsuario_Result
    {
        public long Consecutivo { get; set; }
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string CorreoElectronico { get; set; }
        public bool Estado { get; set; }
        public bool Temporal { get; set; }
        public System.DateTime Vencimiento { get; set; }
        public long ConsecutivoRol { get; set; }
        public string NombreRol { get; set; }
    }
}
