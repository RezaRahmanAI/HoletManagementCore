using HotelManagementCore.Application.Common.Interface;
using HotelManagementCore.Domain.Entities;
using HotelManagementCore.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace HoletManagementCore.Controllers
{
    public class VillaController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private IWebHostEnvironment _webHostEnvironment;
        public VillaController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            var villas = _unitOfWork.Villa.GetAll();
            return View(villas);
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

                if (villa.Image != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(villa.Image.FileName);
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, @"images\Villa");

                    using var fileStream = new FileStream(Path.Combine(filePath, fileName), FileMode.Create);
                   villa.Image.CopyTo(fileStream);
                    villa.ImgUrl = @"\images\Villa" +  fileName;
                }
                else {
                    villa.ImgUrl = "https://dummyimage.com/600x400/000/fff";
                }

                villa.CreatedDate = DateTime.Now;
                _unitOfWork.Villa.Add(villa);
                TempData["success"] = "The Villa has been created";
                _unitOfWork.Save();

                return RedirectToAction("Index");

            }

            return View(villa);
        }

        public IActionResult Edit(int Id)
        {

            ViewBag.Title = "Update";

            Villa? obj = _unitOfWork.Villa.Get(x => x.Id == Id);
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

                if (villa.Image != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(villa.Image.FileName);
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, @"images\Villa");

                    if (!string.IsNullOrEmpty(villa.ImgUrl))
                    {
                        var oldImgPath = Path.Combine(_webHostEnvironment.WebRootPath, villa.ImgUrl.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImgPath))
                        {
                            System.IO.File.Delete(oldImgPath);
                        }
                    }

                    using var fileStream = new FileStream(Path.Combine(filePath, fileName), FileMode.Create);
                    villa.Image.CopyTo(fileStream);
                    villa.ImgUrl = @"\images\Villa" + fileName;
                }                

                _unitOfWork.Villa.Update(villa);
                _unitOfWork.Save();
                return RedirectToAction("Index");

            }

            return View(villa);
        }

        public IActionResult Delete(int Id)
        {

            Villa? villa = _unitOfWork.Villa.Get(x => x.Id == Id);
            if (villa == null)
            {
                return BadRequest();
            }
            
            _unitOfWork.Villa.Delete(villa);
            TempData["success"] = "The Villa has been deleted";
            _unitOfWork.Save();

            return RedirectToAction("Index");

        }
    }
}
