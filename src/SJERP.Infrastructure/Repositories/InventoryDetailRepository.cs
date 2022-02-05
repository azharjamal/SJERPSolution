using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SJERP.Domain.Interfaces;
using SJERP.Domain.Models;
using SJERP.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using SJERP.Domain.Models.Inventory;

namespace SJERP.Infrastructure.Repositories
{
    public class InventoryDetailRepository : Repository<InventoryDetail>, IInventoryDetailRepository
    {
        public InventoryDetailRepository(SJERPDbContext context) : base(context) { }
    }
}
