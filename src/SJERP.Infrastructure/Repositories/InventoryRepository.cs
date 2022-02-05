using Microsoft.EntityFrameworkCore;
using SJERP.Domain.Interfaces;
using SJERP.Domain.Models;
using SJERP.Domain.Models.Inventory;
using SJERP.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJERP.Infrastructure.Repositories
{
    public class InventoryRepository : Repository<Inventory>, IInventoryRepository
    {
        public InventoryRepository(SJERPDbContext context) : base(context) { }

        public override async Task<List<Inventory>> GetAll()
        {
            return await Db.Inventories.AsNoTracking()
                .Include(b => b.InventoryDetail)
                .Where(b => b.IsSale == false)
                .OrderBy(b => b.Make)
                .ToListAsync();
        }


        public override async Task<Inventory> GetById(int id)
        {
            return await Db.Inventories.AsNoTracking()
                .Include(b=> b.InventoryDetail)
                .Where(b => b.Id == id)
                .FirstOrDefaultAsync();
        }

        //public async Task<IEnumerable<Inventory>> GetProductsByCategory(int categoryId)
        //{
        //    return await Search(b => b.CategoryId == categoryId);
        //}

        public async Task<IEnumerable<Inventory>> SearchInventoryfromStock(string searchedValue)
        {
            return await Db.Inventories.AsNoTracking()
                .Include(b => b.InventoryDetail)
                .Where(b => b.Make.Contains(searchedValue) ||
                            b.Model.Contains(searchedValue) ||
                            b.Serial.Contains(searchedValue) ||
                            b.CPU.Contains(searchedValue))
                .ToListAsync();
        }


        public async Task<IEnumerable<Inventory>> GetAllSales()
        {
            return await Db.Inventories.AsNoTracking()
            .Include(b => b.InventoryDetail)
            .Where(b => b.IsSale == true)
            .OrderBy(b => b.Make)
            .ToListAsync();
        }
    }

}
