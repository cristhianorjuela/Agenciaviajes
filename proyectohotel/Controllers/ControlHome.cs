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



namespace proyectohotel.Controllers
{
    public class ControlHome : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
