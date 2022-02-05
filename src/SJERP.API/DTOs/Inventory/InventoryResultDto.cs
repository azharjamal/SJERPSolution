using SJERP.Domain.Models.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SJERP.API.DTOs.Inventory
{
    public class InventoryResultDto
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Ram { get; set; }
        public string Serial { get; set; }
        public string CPU { get; set; }
        public DateTime StockDate { get; set; }
        public DateTime? SalesDate { get; set; }
        public bool IsSale { get; set; }
        public int UserId { get; set; }
        public IEnumerable<InventoryDetail> InventoryDetail { get; set; }
    }
}
