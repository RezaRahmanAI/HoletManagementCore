using HotelManagementCore.Application.Common.Interface;
using HotelManagementCore.Application.Utility;
using HotelManagementCore.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HoletManagementCore.Controllers
{
    public class BookingController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public BookingController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Authorize]
        public IActionResult Index()
        {
            var claimIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            // Check if the user is an admin
            bool isAdmin = User.IsInRole("Admin");

            IEnumerable<Booking> bookings;

            if (isAdmin)
            {
                // Admin should see all bookings
                bookings = _unitOfWork.Booking.GetAll(includeProperties: "villa");  // Use GetAll for multiple bookings
            }
            else
            {
                // Regular user should only see their own bookings
                bookings = _unitOfWork.Booking.GetAll(b => b.UserId == userId, includeProperties: "villa");  // Use GetAll for multiple bookings
            }

            // Pass the bookings to the view
            return View(bookings);
        }




        [Authorize]
        public IActionResult FinalizeBooking(int villaId, DateTime checkInDate, int nights)
        {

            var claimIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            ApplicationUser user = _unitOfWork.ApplicationUser.Get(u => u.Id == userId);

            Booking booking = new()
            {
                VillaId = villaId,
                villa = _unitOfWork.Villa.Get(u => u.Id == villaId, includeProperties: "Amenities"),
                CheckInDate = checkInDate,
                Nights = nights,
                CheckOutDate = checkInDate.AddDays(nights),
                UserId = userId,
                Phone = user.PhoneNumber,
                Email = user.Email,
                Name = user.Name
            };

            booking.TotalCost = booking.villa.price * nights;

            return View(booking);
        }



        [Authorize]
        [HttpPost]
        public IActionResult FinalizeBooking(Booking booking)
        {

            var villa = _unitOfWork.Villa.Get(x => x.Id == booking.VillaId);
            booking.TotalCost = villa.price * booking.Nights;

            booking.Status = SD.StatusPending;
            booking.BookingDate = DateTime.Now;

            _unitOfWork.Booking.Add(booking);
            _unitOfWork.Save();

            return RedirectToAction(nameof(BookingConfirmation), new {id = booking.Id});
        }


        [Authorize]
        public IActionResult BookingConfirmation(int id)
        {
            // Get the booking details using the provided booking ID
            var booking = _unitOfWork.Booking.Get(b => b.Id == id, includeProperties: "villa");

            // Check if booking exists
            if (booking == null)
            {
                return NotFound();
            }

            // Pass the booking details to the view
            ViewData["BookingDetails"] = booking;

            return View(id);
        }


        //[Authorize]
        //public IActionResult BookingConfirmation(int id) 
        //{
        //    return View(id);
        //}
    }
}
