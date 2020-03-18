using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaAFT.Data;

namespace SistemaAFT.Models
{
    public class SolicitudesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
