using System;
using Core.DataAccess;
using Entity.Abstract;
using Entity.Concrete;

namespace DataAccess.Abtract
{
	public interface IProductDal : IEntityRepository<Product>
	{
        Task<ICollection<ProductListViewModel>> GetFilteredProductList(FilteredProductInput filteredProductInput);
    }
}

