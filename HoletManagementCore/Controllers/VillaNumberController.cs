using HotelManagementCore.Domain.Entities;
using HotelManagementCore.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace HoletManagementCore.Controllers
{
    public class VillaNumberController : Controller
    {
        private readonly ApplicationDbContext _context;
        public VillaNumberController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var villaNumbers = _context.VillaNumbers.ToList();
            return View(villaNumbers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Villa villa)
        {


            if (villa.Name == villa.Description)
            {
                ModelState.AddModelError("Name", "Name and Description can't be same");
            }

            if (ModelState.IsValid)
            {

                villa.CreatedDate = DateTime.Now;
                _context.Villas.Add(villa);
                TempData["success"] = "The Villa has been created";
                _context.SaveChanges();

                return RedirectToAction("Index");

            }

            return View(villa);
        }

        public IActionResult Edit(int Id)
        {

            ViewBag.Title = "Update";

            Villa? obj = _context.Villas.FirstOrDefault(x => x.Id == Id);
            if (obj==null)
            {
                return NotFound();
            }
            return View("Edit",obj);
        }

        [HttpPost]
        public IActionResult Update(Villa villa)
        {
            villa.UpdatedDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                _context.Update(villa);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }

            return View(villa);
        }

        public IActionResult Delete(int Id)
        {

            Villa? villa = _context.Villas.FirstOrDefault(x => x.Id == Id);
            if (villa == null)
            {
                return BadRequest();
            }
            
            _context.Villas.Remove(villa);
            TempData["success"] = "The Villa has been deleted";
            _context.SaveChanges(true);

            return RedirectToAction("Index");

        }
    }
}
