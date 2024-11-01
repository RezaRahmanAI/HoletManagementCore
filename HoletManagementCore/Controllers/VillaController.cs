﻿using HotelManagementCore.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace HoletManagementCore.Controllers
{
    public class VillaController : Controller
    {
        private readonly ApplicationDbContext _context;
        public VillaController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var villas = _context.Villas.ToList();
            return View(villas);
        }
    }
}
