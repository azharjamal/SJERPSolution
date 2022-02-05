using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJERP.Domain.Models.Inventory
{
    public class InventoryDetail : Entity
    {
        public int InventoryId { get; set; }
        public string diskname { get; set; }
        public string disksize { get; set; }

        ///* EF Relationship */
        //public IEnumerable<Inventory> Inventories { get; set; }
    }
}
