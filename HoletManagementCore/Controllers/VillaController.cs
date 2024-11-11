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
                ModelState.AddModelError("Name", "Name and Description can't be the same");
            }

            if (ModelState.IsValid)
            {
                if (villa.Image != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(villa.Image.FileName);
                    string folderPath = Path.Combine(_webHostEnvironment.WebRootPath, "images", "Villa");

                    // Ensure the directory exists
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    // Save the image file
                    string filePath = Path.Combine(folderPath, fileName);
                    using var fileStream = new FileStream(filePath, FileMode.Create);
                    villa.Image.CopyTo(fileStream);

                    // Set the ImgUrl property
                    villa.ImgUrl = $"/images/Villa/{fileName}";
                }
                else
                {
                    // Optionally set a default external image
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
            if (obj == null)
            {
                return NotFound();
            }
            return View("Edit", obj);
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
                    string folderPath = Path.Combine(_webHostEnvironment.WebRootPath, "images", "Villa");

                    // Delete the old image if it exists
                    if (!string.IsNullOrEmpty(villa.ImgUrl))
                    {
                        var oldImgPath = Path.Combine(_webHostEnvironment.WebRootPath, villa.ImgUrl.TrimStart('/'));

                        if (System.IO.File.Exists(oldImgPath))
                        {
                            System.IO.File.Delete(oldImgPath);
                        }
                    }

                    // Save the new image
                    string filePath = Path.Combine(folderPath, fileName);
                    using var fileStream = new FileStream(filePath, FileMode.Create);
                    villa.Image.CopyTo(fileStream);

                    villa.ImgUrl = $"/images/Villa/{fileName}";
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

            // Delete the image file if it exists
            if (!string.IsNullOrEmpty(villa.ImgUrl))
            {
                var imgPath = Path.Combine(_webHostEnvironment.WebRootPath, villa.ImgUrl.TrimStart('/'));
                if (System.IO.File.Exists(imgPath))
                {
                    System.IO.File.Delete(imgPath);
                }
            }

            _unitOfWork.Villa.Delete(villa);
            TempData["success"] = "The Villa has been deleted";
            _unitOfWork.Save();

            return RedirectToAction("Index");
        }
    }
}
