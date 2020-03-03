using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace SistemaAFT.Controllers
{
    public class RoleController : Controller
    {
        RoleManager<IdentityRole> _roleManager;
        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        //[Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var roles = _roleManager.Roles.ToList();
            
            return View(roles);
        }

<<<<<<< HEAD
       // [Authorize(Roles = "Admin")]
=======
        //[Authorize(Roles = "Admin")]
>>>>>>> 99981ddb2fba6410202fcf1aa785cbccb9075168
        public IActionResult Create()
        {
            return View(new IdentityRole());
        }

        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole role)
        {
            await _roleManager.CreateAsync(role);
            return RedirectToAction("Index");
        }
    }
}