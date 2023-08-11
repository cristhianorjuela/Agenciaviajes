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
    public class Reserva
    {
        public int Id { get; set; }
        public DateTime FechaReserva { get; set; }
        public string NombresHuespedes { get; set; }
        public int NumeroHabitaciones { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }

        // Otras propiedades...
    }
}
