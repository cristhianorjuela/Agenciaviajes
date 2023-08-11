
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
using System.Net;
using System.Net.Mail;
using proyectohotel.Models;
using proyectohotel.Data;


namespace  proyectohotel.Controllers
{
[ApiController]
[Route("api/[controller]")]
    public class HotelesController : ControllerBase
    {
        private readonly DbContext _context;

        public HotelesController(DbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CrearHotel([FromBody] Hotel hotel)
        {
             _context.Hoteles.Add(hotel);
              _context.SaveChanges();
             return Ok();
        }

        [HttpPost("{hotelId}/asignar-habitaciones")]
        public IActionResult AsignarHabitaciones(int hotelId, [FromBody] ICollection<Habitacion> habitaciones)
        {
            var hotel = _context.Hoteles.Include(h => h.HabitacionesDisponibles).FirstOrDefault(h => h.Id == hotelId);
         if (hotel == null)
         {
            return NotFound();
         }

            hotel.HabitacionesDisponibles = habitaciones;
             _context.SaveChanges();

         return Ok();
        }

        // Modificar valores del hotel
        [HttpPut("{hotelId}/modificar-hotel")]
        public IActionResult ModificarHotel(int hotelId, [FromBody] Hotel hotelModificado)
        {
             var hotel = _context.Hoteles.Find(hotelId);
            if (hotel == null)
            {
              return NotFound();
            }   

            // Actualizar propiedades del hotel según hotelModificado
             hotel.Nombre = hotelModificado.Nombre;
             hotel.Direccion = hotelModificado.Direccion;
             hotel.EmailContacto = hotelModificado.EmailContacto;
             hotel.TelefonoContacto = hotelModificado.TelefonoContacto;
             hotel.Habilitado = hotelModificado.Habilitado;
            

            _context.SaveChanges();

                 return Ok();
        }

        // Modificar valores de las habitaciones del hotel
        [HttpPut("{hotelId}/modificar-habitaciones")]
        public IActionResult ModificarHabitaciones(int hotelId, [FromBody] ICollection<Habitacion> habitacionesModificadas)
        {
             var hotel = _context.Hoteles.Include(h => h.HabitacionesDisponibles).FirstOrDefault(h => h.Id == hotelId);
            if (hotel == null)
            {
               return NotFound();
            }

            foreach (var habitacionModificada in habitacionesModificadas)
            {
             var habitacion = hotel.HabitacionesDisponibles.FirstOrDefault(h => h.Id == habitacionModificada.Id);
                if (habitacion != null)
                {
                 // Actualizar propiedades de la habitación según habitacionModificada
                     habitacion.Tipo = habitacionModificada.Tipo;
                     habitacion.NumeroDisponible = habitacionModificada.NumeroDisponible;
                     habitacion.CostoBase = habitacionModificada.CostoBase;
                     habitacion.Impuesto = habitacionModificada.Impuesto;
                     habitacion.Ubicacion = habitacionModificada.Ubicacion;
                     habitacion.Habilitado = habitacionModificada.Habilitado;
                }
            }

                _context.SaveChanges();

            return Ok();
        }

              // Ver habitaciones disponibles en un hotel
        [HttpGet("{hotelId}/habitaciones-disponibles")]
        public IActionResult HabitacionesDisponibles(int hotelId)
        {
            var hotel = _context.Hoteles.Include(h => h.HabitacionesDisponibles).FirstOrDefault(h => h.Id == hotelId);
            if (hotel == null)
            {
               return NotFound();
            }

            var habitacionesDisponibles = hotel.HabitacionesDisponibles.Where(hab => hab.NumeroDisponible > 0).ToList();

            return Ok(habitacionesDisponibles);
        }

        // Ver detalles de una habitación
        [HttpGet("{hotelId}/habitaciones/{habitacionId}")]
        public IActionResult DetallesHabitacion(int hotelId, int habitacionId)
        {
            var hotel = _context.Hoteles.Include(h => h.HabitacionesDisponibles).FirstOrDefault(h => h.Id == hotelId);
            if (hotel == null)
            {
                return NotFound();
            }

            var habitacion = hotel.HabitacionesDisponibles.FirstOrDefault(hab => hab.Id == habitacionId);
            if (habitacion == null || habitacion.NumeroDisponible <= 0)
            {
             return NotFound("La habitación no está disponible.");
            }

            return Ok(habitacion);
        }
                  // Habilitar un hotel
        [HttpPut("{hotelId}/habilitar-hotel")]
        public IActionResult HabilitarHotel(int hotelId)
        {
            var hotel = _context.Hoteles.Find(hotelId);
            if (hotel == null)
            {
                return NotFound();
            }

            hotel.Habilitado = true;
          _context.SaveChanges();

         return Ok();
        }

        // Deshabilitar un hotel
        [HttpPut("{hotelId}/deshabilitar-hotel")]
        public IActionResult DeshabilitarHotel(int hotelId)
        {
            var hotel = _context.Hoteles.Find(hotelId);
            if (hotel == null)
            {
                return NotFound();
            }

            hotel.Habilitado = false;
            _context.SaveChanges();

            return Ok();
        }

        // Listar reservas realizadas en un hotel
        [HttpGet("{hotelId}/reservas")]
        public IActionResult ListarReservas(int hotelId)
        {
             var hotel = _context.Hoteles.Include(h => h.Reservas).FirstOrDefault(h => h.Id == hotelId);
            if (hotel == null)
            {
              return NotFound();
            }

            return Ok(hotel.Reservas);
        }


        // Ver detalle de una reserva
        [HttpGet("{hotelId}/reservas/{reservaId}")]
        public IActionResult DetalleReserva(int hotelId, int reservaId)
        {
            var hotel = _context.Hoteles.Include(h => h.Reservas).FirstOrDefault(h => h.Id == hotelId);
            if (hotel == null)
            {
                return NotFound();
            }

            var reserva = hotel.Reservas.FirstOrDefault(r => r.Id == reservaId);
            if (reserva == null)
            {
                return NotFound();
            }

          return Ok(reserva);
        }

        // Búsqueda de hoteles
        [HttpPost("buscar-hoteles")]
        public IActionResult BuscarHoteles([FromBody] BusquedaHoteles busqueda)
        {
            var hotelesEncontrados = _context.Hoteles
            .Where(h => h.Habilitado && h.HabitacionesDisponibles.Any(hab => hab.NumeroDisponible > 0));

            if (busqueda.FechaEntrada != DateTime.MinValue)
            {
               hotelesEncontrados = hotelesEncontrados.Where(h => h.Reservas.All(r => r.FechaSalida < busqueda.FechaEntrada));
            }

            if (busqueda.FechaSalida != DateTime.MinValue)
            {
                hotelesEncontrados = hotelesEncontrados.Where(h => h.Reservas.All(r => r.FechaEntrada > busqueda.FechaSalida));
            }

            if (!string.IsNullOrEmpty(busqueda.CiudadDestino))
            {
                 hotelesEncontrados = hotelesEncontrados.Where(h => h.Ciudad == busqueda.CiudadDestino);
            }

            var hotelesFiltrados = hotelesEncontrados.ToList();

         return Ok(hotelesFiltrados);

        }


        [HttpPost("{hotelId}/habitaciones/{habitacionId}/reservar")]
        public IActionResult ReservarHabitacion(int hotelId, int habitacionId, [FromBody] DatosReserva datosReserva)
        {
            var hotel = _context.Hoteles.Include(h => h.HabitacionesDisponibles).FirstOrDefault(h => h.Id == hotelId);
            if (hotel == null)
            {
                return NotFound();
            }

            var habitacion = hotel.HabitacionesDisponibles.FirstOrDefault(hab => hab.Id == habitacionId);
            if (habitacion == null || habitacion.NumeroDisponible <= 0)
            {
                return NotFound("La habitación no está disponible.");
            }

             // Verificar si hay disponibilidad para las fechas y la cantidad de habitaciones
            if (!VerificarDisponibilidad(hotel, habitacion, datosReserva.FechaEntrada, datosReserva.FechaSalida, datosReserva.NumeroHabitaciones))
            {
                return BadRequest("La habitación no está disponible para las fechas o cantidad de habitaciones seleccionadas.");
            }

            // Crear y guardar la reserva
             var reserva = new Reserva
            {
                FechaReserva = DateTime.Now,
                NombresHuespedes = datosReserva.NombresHuespedes,
                NumeroHabitaciones = datosReserva.NumeroHabitaciones,
                HotelId = hotelId
            };

             _context.Reservas.Add(reserva);
            habitacion.NumeroDisponible -= datosReserva.NumeroHabitaciones;
            _context.SaveChanges();

            return Ok(reserva);
        }

           
            // Método para verificar disponibilidad de fechas
        private bool VerificarDisponibilidad(Hotel hotel, Habitacion habitacion, DateTime fechaEntrada, DateTime fechaSalida)
        {
           // Verificar si hay reservas en las fechas seleccionadas para esta habitación
             var reservasEnFechas = _context.Reservas
            .Where(r => r.HotelId == hotel.Id && r.HabitacionId == habitacion.Id)
            .Where(r => !(r.FechaSalida <= fechaEntrada || r.FechaEntrada >= fechaSalida))
            .ToList();

                // Si no hay reservas en las fechas seleccionadas, la habitación está disponible
            return reservasEnFechas.Count == 0;
        }
        

            // Enviar notificación por correo electrónico
        private void EnviarNotificacionCorreo(Reserva reserva)
        {
            var smtpClient = new SmtpClient("smtp.example.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("tu_correo@example.com", "tu_contraseña"),
                EnableSsl = true,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress("tu_correo@example.com"),
                Subject = "Confirmación de Reserva",
                Body = $"¡Tu reserva en el hotel {reserva.Hotel.Nombre} ha sido confirmada! Detalles de la reserva: [Aquí va la información de la reserva]",
                IsBodyHtml = true,
            };

            mailMessage.To.Add(reserva.NombresHuespedes); // Agrega la dirección de correo electrónico del huésped

            smtpClient.Send(mailMessage);
        }

    }
}