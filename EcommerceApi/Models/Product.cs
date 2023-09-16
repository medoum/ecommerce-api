
using System.ComponentModel.DataAnnotations;

namespace EcommerceApi.Models
{
	public class Product
	{
		[Key]
		public int Id { get; set; }

		public string Nom { get; set; }

		public double Prix { get; set; }

		public string Image { get; set; }

		public Category Category { get; set; }

		public List<ProductOwner> ProductOwners { get; set; }
		public List<ProductCategory> ProductCategories { get; set; }

	}
}

