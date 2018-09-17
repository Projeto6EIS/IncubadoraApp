using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IncubadoraApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace IncubadoraApp.Controllers
{
    public class RecemNascidoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RecemNascidoController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

    }
}