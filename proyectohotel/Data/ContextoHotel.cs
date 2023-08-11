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

using Microsoft.EntityFrameworkCore;

namespace proyectohotel.Data
{
    public class ContextoHotel : DbContext
    {
        public ContextoHotel(DbContextOptions<ContextoHotel> options) : base(options) { }

        public DbSet<Hotel> Hoteles { get; set; }
        public DbSet<Habitacion> Habitaciones { get; set; }
        public DbSet<Reserva> Reservas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de relaciones
            modelBuilder.Entity<Hotel>()
                .HasMany(h => h.Reservas)
                .WithOne(r => r.Hotel)
                .HasForeignKey(r => r.HotelId);

        }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de relaciones
            modelBuilder.Entity<Hotel>()
               .HasMany(h => h.HabitacionesDisponibles)
                .WithOne(hab => hab.Hotel)
                .HasForeignKey(hab => hab.HotelId);

        }
    }
}
