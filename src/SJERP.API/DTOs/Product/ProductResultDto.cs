using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SJERP.API.DTOs.Product
{
    public class ProductResultDto
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
        public int BrandId { get; set; }

        public string BrandName { get; set; }
        public int VendorId { get; set; }

        public string VendorName { get; set; }

        public string Name { get; set; }


    }
}
