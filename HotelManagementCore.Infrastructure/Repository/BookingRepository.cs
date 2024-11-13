using HotelManagementCore.Application.Common.Interface;
using HotelManagementCore.Application.Utility;
using HotelManagementCore.Domain.Entities;
using HotelManagementCore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementCore.Infrastructure.Repository
{
    public class BookingRepository : Repository<Booking>, IBookingRepository
    {
        private readonly ApplicationDbContext _context;
        public BookingRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }


        public void Update(Booking entity)
        {
            _context.Bookings.Update(entity);
        }

        public void UpdateStatus(int bookingId, string orderStatus)
        {
            var bookingFromDb = _context.Bookings.FirstOrDefault(m => m.Id == bookingId);
            if (bookingFromDb != null)
            {
                bookingFromDb.Status = orderStatus;
                if (orderStatus == SD.StatusCheckIn)
                {
                    bookingFromDb.ActualCheckOutDate = DateTime.Now;
                }
                if (orderStatus == SD.StatusCompleted)
                {
                    bookingFromDb.ActualCheckOutDate = DateTime.Now;
                }
            }
        }

        public void UpdateStripePaymentId(int bookingId, string sessionId, string paymentIntentId)
        {
            var bookingFromDb = _context.Bookings.FirstOrDefault(m => m.Id == bookingId);
            if (bookingFromDb != null)
            {
                if (!string.IsNullOrEmpty(sessionId))
                {
                    bookingFromDb.StripeSessionId = sessionId;
                }
                if (!string.IsNullOrEmpty(paymentIntentId))
                {
                    bookingFromDb.StripePaymentIntentId = paymentIntentId;
                    bookingFromDb.PaymentDate = DateTime.Now;
                    bookingFromDb.IsPaymentSuccessful = true;

                }
            }
        }

    }
}