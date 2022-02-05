using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJERP.Domain.Models
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        /* EF Relationship */
        public Brand Brand { get; set; }
        public Category Category { get; set; }
        public ProductType ProductType { get; set; }
        public Vendor Vendor { get; set; }
        public IEnumerable<ProductImage> ProductImages { get; set; }
    }
}
