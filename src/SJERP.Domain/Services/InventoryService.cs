using SJERP.Domain.Interfaces;
using SJERP.Domain.Models;
using SJERP.Domain.Models.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJERP.Domain.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryRepository _inventoryRepository;
        public InventoryService(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        public async Task<IEnumerable<Inventory>> GetAll()
        {
            return await _inventoryRepository.GetAll();
        }

        public async Task<Inventory> GetById(int Id)
        {
            return await _inventoryRepository.GetById(Id);
        }

        public async Task<Inventory> Add(Inventory inventory)
        {
            if (_inventoryRepository.Search(b => b.Serial == inventory.Serial).Result.Any())
                return null;

            await _inventoryRepository.Add(inventory);
            return inventory;
        }

        public async Task<Inventory> Update(Inventory inventory)
        {
            //if (_inventoryRepository.Search(b => b.Serial == inventory.Serial && b.Id == inventory.Id).Result.Any())

                //if (_inventoryRepository.Search(b => b.Serial == inventory.Serial).Result.Any())
                //return null;

            await _inventoryRepository.Update(inventory);
            return inventory;
        }

        public async Task<bool> Remove(Inventory inventory)
        {

            await _inventoryRepository.Remove(inventory);
            return true;
        }

        //public async Task<IEnumerable<Inventory>> GetProductByCategory(int categoryId)
        //{
        //    return await _inventoryRepository.GetProductsByCategory(categoryId);
        //}

        public async Task<IEnumerable<Inventory>> Search(string serial)
        {
            return await _inventoryRepository.Search(b => b.Serial.Contains(serial));
        }


        //public async Task<IEnumerable<Inventory>> SearchInventoryfromStock(string searchValue)
        //{
        //    return await _inventoryRepository.SearchInventoryfromStock(searchValue);
        //}

        public void Dispose()
        {
            _inventoryRepository?.Dispose();
        }

        public Task<IEnumerable<Inventory>> GetInventoryByCategory(int CategoryId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Inventory>> SearchInventoryfromStock(string searchedValue)
        {
            return await _inventoryRepository.SearchInventoryfromStock(searchedValue);
        }

        public async Task<IEnumerable<Inventory>> GetAllSales()
        {
            return await _inventoryRepository.GetAllSales();

        }
    }

}
