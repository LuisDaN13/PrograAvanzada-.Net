using Api_Web.Entidades;
using Api_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api_Web.Controllers
{
    public class InicioController : ApiController
    {
        [Route("Inicio/RegistrarUsuario")]
        [HttpPost]
        public int RegistrarUsuario(Usuario entidad)
        {
            try
            {
                using (var db = new Pagina_Web___MartesEntities())
                {
                    return db.RegistrarUsuario(entidad.Identificacion, entidad.Contrasenna, entidad.Nombre, entidad.Correo);
                }
            }
            catch (Exception ex) 
            {
                return -1;
            }
        }

        [Route("Inicio/IniciarSesionUsuario")]
        [HttpPost]
        public List<IniciarSesionUsuario_Result> IniciarSesionUsuario(Usuario entidad)
        {
            try
            {
                using (var db = new Pagina_Web___MartesEntities())
                {
                    var datos = db.IniciarSesionUsuario(entidad.Identificacion, entidad.Contrasenna).ToList();
                    if (datos.Count > 0)
                        return datos;
                    else 
                        return null;                    
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
