using SJERP.Domain.Models.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJERP.Domain.Interfaces
{
    public interface IInventoryDetailService : IDisposable
    {

        Task<IEnumerable<InventoryDetail>> GetAll();

        Task<InventoryDetail> GetById(int Id);
        Task<InventoryDetail> Add(InventoryDetail inventoryDetail);
        Task<InventoryDetail> Update(InventoryDetail inventoryDetail);
        Task<bool> Remove(InventoryDetail inventoryDetail);
    }
}
