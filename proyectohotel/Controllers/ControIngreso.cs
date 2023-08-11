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

namespace proyectohotel.ControlIngreso
{
    public class ControlIngreso : ControlIngreso
    {
        public IActionResult Login()
        {
            return View();
        }
    }


     [HttpPost]
    public IActionResult Login(string username, string password)
    {
        // Verificar las credenciales aquí (puedes consultar la base de datos)

        if (username == "usuario" && password == "contraseña") // Cambia esto con tu lógica de autenticación
        {
             // Autenticación exitosa, redirigir a la página principal
            return RedirectToAction("Index", "Home");
        }
         else
        {
           // Autenticación fallida, mostrar un mensaje de error
            ViewBag.ErrorMessage = "Credenciales inválidas";
            return View();
        }
}

}