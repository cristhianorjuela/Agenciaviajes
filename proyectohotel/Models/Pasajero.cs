using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

namespace proyectohotel.Models
{
    public class Pasajero
    {
        public int Id { get; set; }
        public string NombresApellidos  { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Genero { get; set; }
        public string  TipoDocumento  { get; set; }
        public string NumeroDocumento { get; set; }
        public string Email {get; set; }
        public string  TelefonoContacto {get; set; }

        
    }

}
3003330000