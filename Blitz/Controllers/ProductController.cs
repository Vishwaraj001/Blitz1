using Blitz.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;





namespace Blitz.Controllers
{
    public class ProductController : Controller
    {
        IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductModel productModel)
        {
            ProductModel ordersModel = _productRepository.AddProducts(productModel);
            //return RedirectToAction("OrderDetails");
            return View();
        }

        public IActionResult ProductDetails()
        {
            var products = _productRepository.GetProducts();
            return View(products);
        }

        public IActionResult SearchProduct(string name)
        {
            // List<ProductModel> search= (List<ProductModel>)(IQueryable<ProductModel>)_productRepository.SearchProducts(name);    
            ViewBag.Name1 = name;
            var searchProduct = _productRepository.SearchProducts(name);
            ViewBag.Name2 = name;
            return View(searchProduct);
        }

        [HttpGet]
        public IActionResult Update()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Update(int id, ProductModel productModel)
        {
            var products = _productRepository.UpdateProduct(id,productModel);
            return RedirectToAction("ProductDetails");
        }


        public IActionResult Delete()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {
            ProductModel o = _productRepository.DeleteById(id);
            return View();
        }




    }


}

