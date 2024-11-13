using HotelManagementCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace HotelManagementCore.Application.Common.Interface
{
    public interface IBookingRepository : IRepository<Booking>
    {
        void Update(Booking entity);
        void UpdateStatus(int bookingId, string orderStatus);
        void UpdateStripePaymentId(int bookingId, string sessionId, string paymentIntentId);
       
    }
}
