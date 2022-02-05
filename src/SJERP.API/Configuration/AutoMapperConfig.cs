
using AutoMapper;
using SJERP.API.DTOs.Book;
using SJERP.API.DTOs.Category;
using SJERP.API.DTOs.Inventory;
using SJERP.API.DTOs.Product;
using SJERP.Business.Authentication.Models.Accounts;
using SJERP.Domain.Models;
using SJERP.Domain.Models.Accounts;
using SJERP.Domain.Models.Inventory;

namespace SJERP.API.Configuration
{
    public class AutoMapperConfig: Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Category, CatgoryAddDto>().ReverseMap();
            CreateMap<Category, CatgoryEditDto>().ReverseMap();
            CreateMap<Category, CatgoryResultDto>().ReverseMap();

            CreateMap<Product, ProductAddDto>().ReverseMap();
            CreateMap<Product, ProductEditDto>().ReverseMap();
            CreateMap<Product, ProductResultDto>().ReverseMap();

            CreateMap<Inventory, InventoryAddDto>().ReverseMap();
            CreateMap<Inventory, InventoryEditDto>().ReverseMap();
            CreateMap<Inventory, InventoryResultDto>().ReverseMap();

            //CreateMap<InventoryDetail, InventoryAddDto>().ReverseMap();
            //CreateMap<InventoryDetail, InventoryEditDto>().ReverseMap();
            //CreateMap<InventoryDetail, InventoryResultDto>().ReverseMap();
            //CreateMap<Book, BookAddDto>().ReverseMap();
            //CreateMap<Book, BookEditDto>().ReverseMap();
            //CreateMap<Book, BookResultDto>().ReverseMap();

            CreateMap<Account, AccountResponse>();

            CreateMap<Account, AuthenticateResponse>();

            CreateMap<RegisterRequest, Account>();

            CreateMap<CreateRequest, Account>();

            CreateMap<UpdateRequest, Account>()
                .ForAllMembers(x => x.Condition(
                    (src, dest, prop) =>
                    {
                        // ignore null & empty string properties
                        if (prop == null) return false;
                        if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                        // ignore null role
                        if (x.DestinationMember.Name == "Role" && src.Role == null) return false;

                        return true;
                    }
                ));
        }
    }
}
