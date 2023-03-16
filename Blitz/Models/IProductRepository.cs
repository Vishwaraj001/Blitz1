using System;
using System.Collections.Generic;

namespace Blitz.Models

{
    public interface IProductRepository
    {
        ProductModel AddProducts(ProductModel order);
        IEnumerable<ProductModel> GetProducts();
        IEnumerable<ProductModel> SearchProducts(string OrderSearch);
    }
}

