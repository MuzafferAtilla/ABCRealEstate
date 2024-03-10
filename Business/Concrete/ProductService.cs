using System;
using Business.Abstract;
using DataAccess.Abtract;
using Entity.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class ProductService : IProductService
    {

        private readonly IProductDal _productDal;

        public ProductService(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public Task<Product> Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task<Product> Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetById(int productId)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<ProductListViewModel>> GetFilteredProductList(FilteredProductInput filteredProductInput)
        {
            //some business rules...
            return await _productDal.GetFilteredProductList(filteredProductInput);
        }

        public async Task<ICollection<Product>> GetList()
        {
            return await _productDal.GetList();
        }

        public Task<Product> Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}

