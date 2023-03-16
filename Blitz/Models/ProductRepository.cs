using System.Collections.Generic;
using System.Linq;

namespace Blitz.Models
{
    public class ProductRepository : IProductRepository
    {
        ProjectDbContext _projectDbContext;

        public ProductRepository(ProjectDbContext projectDbContext)
        {
            this._projectDbContext = projectDbContext;
        }

        public ProductModel AddProducts(ProductModel order)
        {
            _projectDbContext.ProductsTable.Add(order);
            _projectDbContext.SaveChanges();
            return null;
        }


      public IEnumerable<ProductModel> GetProducts()
        {
            return _projectDbContext.ProductsTable.Select(o => o).ToList();
            //return _projectDbContext.ProductsTable.Select(o => o).ToList();
        }

        public IEnumerable<ProductModel> SearchProducts(string OrderSearch)
        {
            return _projectDbContext.ProductsTable.Where(b => b.Product_Name.Contains(OrderSearch)).ToList<ProductModel>();
        }

    }
}
