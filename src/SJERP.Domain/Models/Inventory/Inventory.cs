using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJERP.Domain.Models.Inventory
{
    public class Inventory : Entity
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string Ram { get; set; }
        public string Serial { get; set; }
        public string CPU { get; set; }
        public DateTime StockDate { get; set; }
        public DateTime SalesDate { get; set; }
        public bool IsSale { get; set; }
        public int UserId { get; set; }
        /* EF Relationship */
        public IEnumerable<InventoryDetail> InventoryDetail { get; set; }
        //public IEnumerable<ProductImage> ProductImages { get; set; }
    }
}
