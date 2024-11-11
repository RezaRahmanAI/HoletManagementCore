using HoletManagementCore.ViewModels;
using HotelManagementCore.Application.Common.Interface;
using HotelManagementCore.Domain.Entities;
using HotelManagementCore.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HoletManagementCore.Controllers
{
    public class VillaNumberController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public VillaNumberController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var villaNumbers = _unitOfWork.VillaNumber.GetAll(includeProperties: "Villa");
            //var villaNumbers = _unitOfWork.VillaNumbers.Include(u => u.Villa).ToList();
            return View(villaNumbers);
        }

        public IActionResult Create()
        {
            //ViewBag.Villas = new SelectList(_context.Villas, "Id", "Name");

            var vm = new VillaNumberVM
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
        public IActionResult Create(VillaNumberVM obj)
        {

            bool villaNoExist = _unitOfWork.VillaNumber.Any(x => x.VillaNo == obj.VillaNumber.VillaNo);

            //if (villa.Name == villa.Description)
            //{
            //    ModelState.AddModelError("Name", "Name and Description can't be same");
            //}
            ModelState.Remove("Villa");

            if (ModelState.IsValid && !villaNoExist)
            {
                
                _unitOfWork.VillaNumber.Add(obj.VillaNumber);
                TempData["success"] = "The Villa Number has been created";
                _unitOfWork.Save();

                return RedirectToAction("Index");

            }

            if (villaNoExist)
            {
                TempData["error"] = "The villa number already exist";
            }

            obj.VillaList = _unitOfWork.Villa.GetAll().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });

            return View(obj);
        }

        public IActionResult Edit(int Id)
        {

            VillaNumberVM villaNumberVM = new()
            {
                VillaList = _unitOfWork.Villa.GetAll().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }),
                VillaNumber = _unitOfWork.VillaNumber.Get(x => x.VillaNo == Id)
            };

            if (villaNumberVM.VillaNumber == null)
            {
                return RedirectToAction("Error", "Home");
            }

            
            return View(villaNumberVM);
        }

        [HttpPost]
        public IActionResult Edit(VillaNumberVM obj)
        {            
            if (ModelState.IsValid)
            {
                _unitOfWork.VillaNumber.Update(obj.VillaNumber);
                _unitOfWork.Save();
                TempData["Success"] = "Villa Number has been updated successfully";
                return RedirectToAction("Index");

            }

            return View(obj);
        }

        public IActionResult Delete(int Id)
        {

            VillaNumber? villa = _unitOfWork.VillaNumber.Get(x => x.VillaNo == Id);
            if (villa == null)
            {
                return BadRequest();
            }
            
            _unitOfWork.VillaNumber.Delete(villa);
            TempData["success"] = "The VillaNumber has been deleted";
            _unitOfWork.Save();

            return RedirectToAction("Index");

        }
    }
}
