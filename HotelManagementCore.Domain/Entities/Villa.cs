using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementCore.Domain.Entities
{
    public class Villa
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public double price { get; set; }
        public int Sqft { get; set; }
        public int Occupency { get; set; }
        [NotMapped]
        public IFormFile? Image { get; set; }
        public string? ImgUrl { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get;set; }

        [ValidateNever]
        public IEnumerable<Amenity> Amenities { get; set; }
        [ValidateNever]
        public IEnumerable<VillaNumber> VillaNumbers { get; set; }

        [NotMapped]
        public bool IsAvailable { get; set; } = true;
    }
}
