using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SJERP.Domain.Models;

namespace SJERP.Domain.Interfaces
{
    public interface IBrandService : IDisposable
    {
        Task<IEnumerable<Brand>> GetAll();
        Task<Brand> GetById(int Id);
        Task<Brand> Add(Brand brand);
        Task<Brand> Update(Brand brand);
        Task<bool> Remove(Brand brand);
        Task<IEnumerable<Brand>> Search(string brandName);



    }
}
