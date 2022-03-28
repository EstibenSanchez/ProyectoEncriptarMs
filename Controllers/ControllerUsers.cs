using Microsoft.AspNetCore.Mvc;
using ProyectoEncriptarMs.Modelo;
using ProyectoEncriptarMs.Servicios;
using System.Collections.Generic;

namespace ProyectoEncriptarMs.Controllers
{
    [ApiController]
    public class ControllerUsers : Controller
    {
        private ServicioUsuarios servicio = new ServicioUsuarios();



        [HttpPost]
        [Route("insertusers")]

        public List<Usuario> Post(List<Usuario> usuarios)
        {
            return servicio.Postt(usuarios);

        }
    }
}
