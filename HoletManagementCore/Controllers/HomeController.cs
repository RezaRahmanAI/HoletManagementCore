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
