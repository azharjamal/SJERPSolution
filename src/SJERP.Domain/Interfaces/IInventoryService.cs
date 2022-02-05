using SJERP.Domain.Models.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJERP.Domain.Interfaces
{

    public interface IInventoryService : IDisposable
    {
        Task<IEnumerable<Inventory>> GetAll();
        Task<IEnumerable<Inventory>> GetAllSales();
        Task<Inventory> GetById(int Id);
        Task<Inventory> Add(Inventory inventory);
        Task<Inventory> Update(Inventory inventory);
        Task<bool> Remove(Inventory inventory);
        Task<IEnumerable<Inventory>> GetInventoryByCategory(int CategoryId);
        Task<IEnumerable<Inventory>> Search(string productName);
        Task<IEnumerable<Inventory>> SearchInventoryfromStock(string searchedValue);

    }
}
