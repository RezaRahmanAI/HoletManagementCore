using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementCore.Application.Common.Interface
{
    public interface IUnitOfWork
    {
        IVillaRepository Villa {  get; }
        IAmenityRepository Amenity {  get; }
        IVillaNumberRepository VillaNumber { get; }
        void Save();
    }
}
