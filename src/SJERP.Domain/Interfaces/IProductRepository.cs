using SJERP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJERP.Domain.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        new Task<List<Product>> GetAll();

        new Task<Product> GetById(int Id);

        Task<IEnumerable<Product>> GetProductsByCategory(int CategoryId);
        Task<IEnumerable<Product>> SearchProductWithCategory(string searchvalue);

    }
}
