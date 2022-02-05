using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SJERP.API.DTOs.Product;
using SJERP.Domain.Interfaces;
using SJERP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SJERP.API.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : MainController
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IMapper mapper,  IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAll();

            return Ok(_mapper.Map<IEnumerable<ProductResultDto>>(products));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetById(id);

            if (product == null) return NotFound();

            return Ok(_mapper.Map<ProductResultDto>(product));
        }

        [HttpGet]
        [Route("get-products-by-category/{categoryId}")]
        public async Task<IActionResult> GetProductsByCategory(int categoryId)
        {
            var books = await _productService.GetProductByCategory(categoryId);

            if (!books.Any()) return NotFound();

            return Ok(_mapper.Map<IEnumerable<ProductResultDto>>(books));
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductAddDto productDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var product = _mapper.Map<Product>(productDto);
            var bookResult = await _productService.Add(product);

            if (bookResult == null) return BadRequest();

            return Ok(_mapper.Map<ProductResultDto>(bookResult));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductEditDto productDto)
        {
            if (id != productDto.Id) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            await _productService.Update(_mapper.Map<Product>(productDto));

            return Ok(productDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _productService.GetById(id);
            if (product == null) return NotFound();

            await _productService.Remove(product);

            return Ok();
        }

        [Route("search/{productName}")]
        [HttpGet]
        public async Task<ActionResult<List<Product>>> Search(string productName)
        {
            var books = _mapper.Map<List<Product>>(await _productService.Search(productName));

            if (books == null || books.Count == 0) return NotFound("None product was founded");

            return Ok(books);
        }

        [Route("search-product-with-category/{searchedValue}")]
        [HttpGet]
        public async Task<ActionResult<List<Product>>> SearchProductWithCategory(string searchedValue)
        {
            var products = _mapper.Map<List<Product>>(await _productService.SearchProductWithCategory(searchedValue));

            if (!products.Any()) return NotFound("None product was founded");

            return Ok(_mapper.Map<IEnumerable<ProductResultDto>>(products));
        }
    }

}
