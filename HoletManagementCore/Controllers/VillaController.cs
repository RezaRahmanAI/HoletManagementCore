using HotelManagementCore.Domain.Entities;
using HotelManagementCore.Infrastructure.Data;
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

        public IActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Create(Villa villa)
        {            

            if (ModelState.IsValid)
            {

                villa.CreatedDate = DateTime.Now;
                _context.Villas.Add(villa);
                _context.SaveChanges();

                return RedirectToAction("Index");

            }

            return View(villa);
        }
    }
}
