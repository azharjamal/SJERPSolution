using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SJERP.Domain.Models;
using SJERP.Domain.Interfaces;
using System.Linq;

namespace SJERP.Domain.Services
{
    //public class BrandService : IBrandService
    //{
    //    private readonly IBrandRepository _brandRepository;
    //    private readonly IBookService _bookService;


    //    public BrandService(IBrandRepository BrandRepository, IBookService bookService)
    //    {
    //        _brandRepository = BrandRepository;
    //        _bookService = bookService;
    //    }

    //    public async Task<IEnumerable<Brand>> GetAll()
    //    {
    //        return await _brandRepository.GetAll();
    //    }

    //    public async Task<Brand> GetById(int Id)
    //    {
    //        return await _brandRepository.GetById(Id);
    //    }

    //    public async Task<Brand> Add(Brand Brand)
    //    {
    //        if (_brandRepository.Search(c => c.Name == Brand.Name).Result.Any())
    //            return null;

    //        await _brandRepository.Add(Brand);

    //        return Brand;
    //    }

    //    public async Task<Brand> Update(Brand Brand)
    //    {
    //        if (_brandRepository.Search(c => c.Name == Brand.Name && c.Id == Brand.Id).Result.Any())
    //            return null;

    //        await _brandRepository.Update(Brand);
    //        return Brand;
    //    }

    //    public async Task<bool> Remove(Brand Brand)
    //    {
    //        var books = await _bookService.GetBookByCategory(Brand.Id);
    //        if (books.Any()) return false;

    //        await _brandRepository.Remove(Brand);
    //        return true;
    //    }

    //    public async Task<IEnumerable<Brand>> Search(string BrandName)
    //    {
    //        return await _brandRepository.Search(c => c.Name.Contains(BrandName));

    //    }

    //    public void Dispose()
    //    {
    //        _brandRepository?.Dispose();
    //    }
    //}

}
