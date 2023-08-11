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
    public class Habitacion
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public int NumeroDisponible { get; set; }
        public decimal Costo_Base { get; set; }
        public decimal Impuesto {get; set, }
        public string Ubicacion {get; set;}
        public double Habilitado {get; set;}

    // Agrega más propiedades según tus necesidades
    }
}