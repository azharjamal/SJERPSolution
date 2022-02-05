using SJERP.Domain.Interfaces;
using SJERP.Domain.Models.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJERP.Domain.Services
{
    public class InventoryDetailService : IInventoryDetailService
    {
        private readonly IInventoryDetailRepository _inventoryDetailRepository;

        public InventoryDetailService(IInventoryDetailRepository inventoryDetailRepository)
        {
            _inventoryDetailRepository = inventoryDetailRepository;
        }
        public async Task<InventoryDetail> Add(InventoryDetail inventoryDetail)
        {
            if (_inventoryDetailRepository.Search(b => b.InventoryId == inventoryDetail.InventoryId && b.diskname == inventoryDetail.diskname).Result.Any())
                return null;

            await _inventoryDetailRepository.Add(inventoryDetail);
            return inventoryDetail;
        }
        public void Dispose()
        {
            _inventoryDetailRepository?.Dispose();
        }

        public Task<IEnumerable<InventoryDetail>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<InventoryDetail> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Remove(InventoryDetail inventoryDetail)
        {

            await _inventoryDetailRepository.Remove(inventoryDetail);
            return true;
        }

        public Task<InventoryDetail> Update(InventoryDetail inventoryDetail)
        {
            throw new NotImplementedException();
        }
    }
}
