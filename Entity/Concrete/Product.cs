using System;
using Core.Entity;

namespace Entity.Concrete
{
	public class Product : IAbcEntity
	{
		public int ProductId { get; set; }
        public string? ProductName { get; set; }
		public string? Description { get; set; }
		public decimal Price { get; set; }
		public int ProductAge { get; set; }
		public string? RoomType { get; set; }
		public string? SaleType { get; set; }
		public int ProductArea { get; set; }
		public string? PhotoUrl { get; set; }
	}
}

