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
    public class ContactoEmergencia
    {
        public int Id { get; set; }
        public string NombresCompletos { get; set; }
        public string TelefonoContacto { get; set; }        
        
    }

}