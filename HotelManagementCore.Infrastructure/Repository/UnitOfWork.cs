using HotelManagementCore.Application.Common.Interface;
using HotelManagementCore.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementCore.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IVillaRepository Villa {  get; private set; }
        public IAmenityRepository Amenity {  get; private set; }

        public IBookingRepository Booking { get; private set; }

        public IVillaNumberRepository VillaNumber { get; private set; }

        public IApplicationUserRepository ApplicationUser { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Villa = new VillaRepository(_context);
            Amenity = new AmenityRepository(_context);
            Booking = new BookingRepository(_context);
            ApplicationUser = new ApplicationUserRepository(_context);
            VillaNumber = new VillaNumberRepository(_context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
