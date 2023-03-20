//using DocumentFormat.OpenXml.Office.CustomUI;
//using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;

//using System.Web; //.HttpSessionState class.;
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
      
        public ProductModel UpdateProduct(int id, ProductModel productModel)
        {

            var v = _projectDbContext.ProductsTable.Find(id);
            v.Product_Name = productModel.Product_Name; 
            v.Product_Price = productModel.Product_Price;
            v.SubCategory_Id = productModel.SubCategory_Id; 
            v.Category_Id   = productModel.Category_Id;
            v.Category_Id   = productModel.Category_Id;
            _projectDbContext.SaveChanges();

            return null;
        }

        public ProductModel DeleteById(int id)
        {
            _projectDbContext.ProductsTable.Remove(_projectDbContext.ProductsTable.Find(id));
            _projectDbContext.SaveChanges();
            return null;
        }


    }
}
