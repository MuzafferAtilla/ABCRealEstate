using System;
namespace Entity.Abstract
{
	public class FilteredProductInput
	{
        public string? ProductName { get; set; }
        public decimal MaxPrice { get; set; }
        public decimal MinPrice { get; set; }
        public required List<int> ProductAge { get; set; }
        public required List<string> RoomType { get; set; }
        public required List<string> SaleType { get; set; }
    }
}

