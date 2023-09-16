using System.ComponentModel.DataAnnotations;

namespace EcommerceApi.Models
{
	public class Category
	{
		[Key]
		public int Id { get; set; }

		public string Nom { get; set; }

        public List<ProductCategory> ProductCategories { get; set; }
    }
}

