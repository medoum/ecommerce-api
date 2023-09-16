using EcommerceApi.Dto;
using EcommerceApi.Models;

namespace EcommerceApi.Services
{
	public interface IProductService
	{
        Task<IEnumerable<Product>> GetProduts();
        Task<Product> GetSigleProduct(int productId);
        Task<Product> AddProduct(int userId, int categoryId, Product product);
        Task DeleteProduct(int productId);


    }
}

