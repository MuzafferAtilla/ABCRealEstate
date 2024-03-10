using System;
using Entity.Abstract;
using Entity.Concrete;

namespace Business.Abstract
{
	public interface IProductService
	{
        Task<Product> Add(Product entity);
        Task<Product> Delete(Product entity);
        Task<Product> Update(Product entity);
        Task<ICollection<Product>> GetList();
        Task<Product> GetById(int productId);

        Task<ICollection<ProductListViewModel>> GetFilteredProductList(FilteredProductInput filteredProductInput);
    }
}

