using EcommerceApi.Data;
using EcommerceApi.Dto;
using EcommerceApi.Models;
using EcommerceApi.Services;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApi.Repository
{
    public class ProductService : IProductService
	{
        private readonly EcomDbContext _ecomDbContext;

		public ProductService(EcomDbContext ecomDbContext)
		{
            _ecomDbContext = ecomDbContext;            
		}

        public async Task<Product> AddProduct(int userId,int categoryId,Product product)
        {
            var productOwnerEntity = await _ecomDbContext.Users.Where(a => a.Id == userId).FirstOrDefaultAsync(); 
            var category = await _ecomDbContext.Categories.Where(c => c.Id == categoryId).FirstOrDefaultAsync();

            if (productOwnerEntity == null || category == null)
            {
                throw new Exception("Produit non trouvé");
               
            }

            var productOwner = new ProductOwner()
            {
                User = productOwnerEntity,
                Product = product,
            };

            

            var productCategory = new ProductCategory()
            {
                Category = category,
                Product = product,
            };

            _ecomDbContext.Add(productOwner);
            _ecomDbContext.Add(productCategory);
            _ecomDbContext.Add(product);
            


           await _ecomDbContext.SaveChangesAsync();

           return product;

         
        }

        public Task DeleteProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetProduts()
        {
             return await _ecomDbContext.Products.ToListAsync();
        }

        public async Task<Product> GetSigleProduct(int productId)
        {
            return await _ecomDbContext.Products.FindAsync(productId);

        }

    }
}

