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
        private readonly ApplicationDbContext _context;

        public SolicitudesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewData["YearID"] = new SelectList(_context.Year, "YearID", "year");
            ViewData["ProgramaID"] = new SelectList(_context.Programa, "ProgramaID", "nombre");
            ViewData["ComponenteID"] = new SelectList(_context.Componente, "ComponenteID", "nombre");
            ViewData["Instancia_EjecutoraID"] = new SelectList(_context.Instancia_Ejecutora, "Instancia_EjecutoraID", "nombre");
            ViewData["DelegacionID"] = new SelectList(_context.Delegacion, "DelegacionID", "nombre");

            return View();
        }
    }
}
