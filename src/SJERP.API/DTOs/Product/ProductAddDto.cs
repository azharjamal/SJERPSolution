using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SJERP.API.DTOs.Product
{
    public class ProductAddDto
    {
        [Required(ErrorMessage = "The field {0} is required")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(150, ErrorMessage = "The field {0} must be between {2} and {1} characters", MinimumLength = 2)]

        public int BrandId { get; set; }
        public int VendorId { get; set; }
        public string Name { get; set; }


    }
}
