using System;
namespace EcommerceApi.Models
{
	public class ProductOwner
	{
		public int ProductId { get; set; }
		public int UserId { get; set; }
		public Product Product { get; set; }
		public User User { get; set; }
	}
}

