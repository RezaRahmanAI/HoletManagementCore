using HoletManagementCore.Models;
using HoletManagementCore.ViewModels;
using HotelManagementCore.Application.Common.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HoletManagementCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            HomeVm vm = new()
            {
                VillaList = _unitOfWork.Villa.GetAll(includeProperties: "Amenities"),
                Night = 1,
                CheckInDate = DateOnly.FromDateTime(DateTime.Now),
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Index(HomeVm homeVm)
        {
            homeVm.VillaList = _unitOfWork.Villa.GetAll(includeProperties: "Amenities");
            
            return View(homeVm);
        }

        public IActionResult GetVillaByDate(int numNights, DateOnly checkInDate)
        {
            var villaList = _unitOfWork.Villa.GetAll(includeProperties: "Amenities").ToList();
            foreach (var villa in villaList)
            {
                if (villa.Id % 2 == 0)
                {
                    villa.IsAvailable = false;
                }
            }

            HomeVm homeVm = new()
            {
                CheckInDate = checkInDate,
                VillaList = villaList,
                Night = numNights
            };

            return PartialView("_VillaList",homeVm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
