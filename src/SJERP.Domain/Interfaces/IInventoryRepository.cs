
using SJERP.Domain.Models;
using SJERP.Domain.Models.Inventory;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SJERP.Domain.Interfaces
{
    public interface IInventoryRepository : IRepository<Inventory>
    {
        Task<IEnumerable<Inventory>> GetAllSales();
        Task<IEnumerable<Inventory>> SearchInventoryfromStock(string searchedValue);
    }

}
