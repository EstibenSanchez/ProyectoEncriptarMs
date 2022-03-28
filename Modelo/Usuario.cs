using System;
using System.Text.Json;

namespace ProyectoEncriptarMs.Modelo
{
    public class Usuario
    {
        public string correo { get; set; }
        public string password { get; set; }
        public DateTime fecha { get; set; }

        public string Json()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
