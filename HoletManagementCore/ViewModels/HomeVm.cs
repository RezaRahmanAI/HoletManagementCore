using HotelManagementCore.Domain.Entities;

namespace HoletManagementCore.ViewModels
{
    public class HomeVm
    {
        public IEnumerable<Villa> VillaList { get; set; }
        public DateOnly CheckInDate { get; set; }
        public DateOnly CheckOutDate { get; set; }
        public int Night {  get; set; }
    }
}
