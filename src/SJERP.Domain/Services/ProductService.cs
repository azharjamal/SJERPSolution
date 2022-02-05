using SJERP.Domain.Interfaces;
using SJERP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJERP.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _productRepository.GetAll();
        }

        public async Task<Product> GetById(int Id)
        {
            return await _productRepository.GetById(Id);
        }

        public async Task<Product> Add(Product product)
        {
            if (_productRepository.Search(b => b.Name == product.Name).Result.Any())
                return null;

            await _productRepository.Add(product);
            return product;
        }

        public async Task<Product> Update(Product product)
        {
            if (_productRepository.Search(b => b.Name == product.Name && b.Id == product.Id).Result.Any())
                return null;

            await _productRepository.Update(product);
            return product;
        }

        public async Task<bool> Remove(Product product)
        {

            await _productRepository.Remove(product);
            return true;
        }

        public async Task<IEnumerable<Product>> GetProductByCategory(int categoryId)
        {
            return await _productRepository.GetProductsByCategory(categoryId);
        }

        public async Task<IEnumerable<Product>> Search(string productName)
        {
            return await _productRepository.Search(b => b.Name.Contains(productName));
        }

        public async Task<IEnumerable<Product>> SearchProductWithCategory(string searchValue)
        {
            return await _productRepository.SearchProductWithCategory(searchValue);
        }

        public void Dispose()
        {
            _productRepository?.Dispose();
        }
    }

}
