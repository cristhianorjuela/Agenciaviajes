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
    public class Hotel
    {
        public int  Id Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string EmailContacto { get; set; }
        public string TelefonoContacto { get; set; }
        public bool Habilitado { get; set; }
        public ICollection<Habitacion> HabitacionesDisponibles { get; set; }
        public ICollection<Reserva> Reservas { get; set; }

    // Agrega más propiedades según tus necesidades
    }
}