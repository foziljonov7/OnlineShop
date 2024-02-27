using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Api.Data;
using OnlineShop.Api.Models.Sold;
using OnlineShop.Api.Repository;
using OnlineShop.Api.ViewModels;

namespace OnlineShop.Api.Services
{
    public class SoldProductService : ISoldProductService
    {
        private readonly ISoldProductRepository repository;
        private readonly IMapper mapper;

        public SoldProductService(
            ISoldProductRepository repository,
            IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<(Guid productId, double totalPrice)> GetReturnSoldProduct(Guid id, int quantity)
        {
            var returnSoldProduct = await repository.GetReturnSoldProduct(id, quantity);
            return returnSoldProduct;
        }

        public async Task<SoldProductViewModel> GetSoldProduct(Guid id)
        {
            var soldProduct = await repository.GetSoldProduct(id);
            return (SoldProductViewModel)soldProduct;
        }

        public async Task<List<SoldProductViewModel>> GetSoldProducts()
        {
            var soldProducts = await repository.GetSoldProducts();
            return mapper.Map<List<SoldProduct>, List<SoldProductViewModel>>(soldProducts);
        }

        Task<(Guid productId, int quantity)> ISoldProductService.GetReturnSoldProduct(Guid id, int quantity)
        {
            throw new NotImplementedException();
        }
    }
}
