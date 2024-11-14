using HoletManagementCore.Models;
using HoletManagementCore.ViewModels;
using HotelManagementCore.Application.Common.Interface;
using HotelManagementCore.Application.Utility;
using Microsoft.AspNetCore.Authorization;
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


        
        public IActionResult Dashboard()
        {
            // Retrieve and set statistics for the dashboard
            var totalCustomers = _unitOfWork.ApplicationUser.GetAll().Count();
            var totalBookings = _unitOfWork.Booking.GetAll().Count();
            var totalCanceled = _unitOfWork.Booking.GetAll(b => b.Status == SD.StatusCancelled).Count();
            var totalCompleted = _unitOfWork.Booking.GetAll(b => b.Status == SD.StatusCompleted).Count();
            var totalEarnings = _unitOfWork.Booking
                .GetAll(b => b.Status == SD.StatusCompleted)
                .Sum(b => b.TotalCost);
            
            // Pass data to the view
            ViewData["TotalCustomers"] = totalCustomers;
            ViewData["TotalBookings"] = totalBookings;
            ViewData["TotalCanceled"] = totalCanceled;
            ViewData["TotalCompleted"] = totalCompleted;
            ViewData["TotalEarnings"] = totalEarnings;

            return View();
        }

        public IActionResult Index()
        {
            if (User.IsInRole(SD.Role_Admin))
            {
                // Redirect to the Dashboard action in the BookingController
                return RedirectToAction("Dashboard", "Home");
            }
            

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

        //public IActionResult GetVillaByDate(int numNights, DateOnly checkInDate)
        //{
        //    var villaList = _unitOfWork.Villa.GetAll(includeProperties: "Amenities").ToList();
        //    foreach (var villa in villaList)
        //    {
        //        if (villa.Id % 2 == 0)
        //        {
        //            villa.IsAvailable = false;
        //        }
        //    }

        //    HomeVm homeVm = new()
        //    {
        //        CheckInDate = checkInDate,
        //        VillaList = villaList,
        //        Night = numNights
        //    };

        //    return PartialView("_VillaList",homeVm);
        //}



        public IActionResult GetVillaByDate(int numNights, DateOnly checkInDate)
        {
            // Fetch villas with their amenities and villa numbers
            var villaList = _unitOfWork.Villa.GetAll(includeProperties: "Amenities,VillaNumbers").ToList();

            // Get all bookings within the specified date range
            var endDate = checkInDate.AddDays(numNights);

            // Fetch all bookings that are not completed and overlap with the selected date range
            var bookedVillaNumbers = _unitOfWork.Booking
                .GetAll(b => b.Status != SD.StatusCompleted
                             )
                .Select(b => b.VillaNumber)
                .Distinct()
                .ToList();

            foreach (var villa in villaList)
            {
                // Check if all villa numbers for this villa are booked and not completed
                var isAllVillaNumbersBooked = villa.VillaNumbers.All(vn => bookedVillaNumbers.Contains(vn.VillaNo));

                villa.IsAvailable = !isAllVillaNumbersBooked;
            }

            HomeVm homeVm = new()
            {
                CheckInDate = checkInDate,
                VillaList = villaList,
                Night = numNights
            };

            return PartialView("_VillaList", homeVm);
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
