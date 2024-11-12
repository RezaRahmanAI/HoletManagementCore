using HoletManagementCore.ViewModels;
using HotelManagementCore.Application.Common.Interface;
using HotelManagementCore.Application.Utility;
using HotelManagementCore.Domain.Entities;
using HotelManagementCore.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HoletManagementCore.Controllers
{
    [Authorize(Roles = SD.Role_Admin)]
    
    public class AmenityController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public AmenityController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var villaNumbers = _unitOfWork.Amenity.GetAll(includeProperties: "Villa");
            //var villaNumbers = _unitOfWork.VillaNumbers.Include(u => u.Villa).ToList();
            return View(villaNumbers);
        }

        public IActionResult Create()
        {
            //ViewBag.Villas = new SelectList(_context.Villas, "Id", "Name");

            var vm = new AmenityVM
            {
                VillaList = _unitOfWork.Villa.GetAll().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                })

            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(AmenityVM obj)
        {

            
            ModelState.Remove("Villa");

            if (ModelState.IsValid )
            {
                
                _unitOfWork.Amenity.Add(obj.Amenity);
                TempData["success"] = "The Villa Number has been created";
                _unitOfWork.Save();

                return RedirectToAction("Index");

            }

          

            obj.VillaList = _unitOfWork.Villa.GetAll().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });

            return View(obj);
        }

        public IActionResult Edit(int id)
        {

            AmenityVM amenityNumber = new()
            {
                VillaList = _unitOfWork.Amenity.GetAll().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }),
                Amenity = _unitOfWork.Amenity.Get(x => x.Id == id)
            };

            if (amenityNumber.Amenity == null)
            {
                return RedirectToAction("Error", "Home");
            }

            
            return View(amenityNumber);
        }

        [HttpPost]
        public IActionResult Edit(AmenityVM obj)
        {            
            if (ModelState.IsValid)
            {
                _unitOfWork.Amenity.Update(obj.Amenity);
                _unitOfWork.Save();
                TempData["Success"] = "Amenity has been updated successfully";
                return RedirectToAction("Index");

            }

            return View(obj);
        }

        public IActionResult Delete(int id)
        {

            Amenity? amenity = _unitOfWork.Amenity.Get(x => x.Id == id);
            if (amenity == null)
            {
                return BadRequest();
            }
            
            _unitOfWork.Amenity.Delete(amenity);
            TempData["success"] = "The amenity has been deleted";
            _unitOfWork.Save();

            return RedirectToAction("Index");

        }
    }
}
