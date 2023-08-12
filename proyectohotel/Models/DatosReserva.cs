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


    public class DatosReserva
    {
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }
        public string NombresHuespedes { get; set; }
        public int NumeroHabitaciones { get; set; }
        public List<Pasajero> Pasajeros { get; set; }
        public ContactoEmergencia ContactoEmergencia { get; set; }
    }
}
