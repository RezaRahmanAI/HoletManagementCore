using HotelManagementCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace HotelManagementCore.Application.Common.Interface
{
    public interface IAmenityRepository : IRepository<Amenity>
    {
        void Update(Amenity entity);        
       
    }
}
