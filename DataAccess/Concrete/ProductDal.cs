using Core.DataAccess;
using DataAccess.Abtract;
using DataAccess.Concrete.Contexts;
using Entity.Abstract;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class ProductDal : EntityRepositoryBase<Product, AbcContext>, IProductDal
    {
        public ProductDal(AbcContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ICollection<ProductListViewModel>> GetFilteredProductList(FilteredProductInput filteredProductInput)
        {
            var query = _context.Products.AsQueryable();

            if (filteredProductInput.MaxPrice > 0 || filteredProductInput.MinPrice > 0)
            {
                query.Where(m => m.Price >= filteredProductInput.MinPrice && m.Price <= filteredProductInput.MaxPrice);
            }

            if (filteredProductInput.ProductAge.Count > 0)
            {
                query.Where(m => filteredProductInput.ProductAge.Contains(m.ProductAge));
            }

            if (filteredProductInput.RoomType.Count > 0)
            {
                query.Where(m => filteredProductInput.RoomType.Contains(m.RoomType));
            }

            if (filteredProductInput.SaleType.Count > 0)
            {
                query.Where(m => filteredProductInput.SaleType.Contains(m.SaleType));
            }

            if (!String.IsNullOrWhiteSpace(filteredProductInput.ProductName))
            {
                query.Where(m => filteredProductInput.ProductName.Contains(m.ProductName));
            }

            var result = await query.Select(m => new ProductListViewModel
            {
                ProductName = m.ProductName,
                Description = m.Description,
                Price = m.Price,
                ProductAge = m.ProductAge,
                ProductArea = m.ProductArea,
                ProductId = m.ProductId,
                RoomType = m.RoomType,
                SaleType = m.SaleType
            }).ToListAsync();

            return result;
        }
    }
}

