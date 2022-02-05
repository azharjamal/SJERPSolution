using SJERP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJERP.Domain.Interfaces
{
    public interface IProductService : IDisposable
    {
        Task<IEnumerable<Product>> GetAll();

        Task<Product> GetById(int Id);
        Task<Product> Add(Product book);

        Task<Product> Update(Product product);
        Task<bool> Remove(Product product);
        Task<IEnumerable<Product>> GetProductByCategory(int CategoryId);
        Task<IEnumerable<Product>> Search(string productName);
        Task<IEnumerable<Product>> SearchProductWithCategory(string searchedValue);

    }
}
