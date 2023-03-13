using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Business
{
    public class ProductService
    {
        public List<ProductReadVM> GetProducts()
        {
            var productList = ApplicationDbContext.ProductList;
            return productList.Select(x => new ProductReadVM
            {
                Id = x.Id,
                Name = x.Name,
                CreateTime = x.CreateTime
            }).ToList();
        }

        public void CreateProduct(ProductCreateVM product)
        {
            var productModel = new Product
            {
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity,
            };
            ApplicationDbContext.ProductList.Add(productModel);
        }

        public void UpdateProduct(ProductUpdateVM product) {
        
            var updatedModel = ApplicationDbContext.ProductList.FirstOrDefault(x=>x.Id == product.Id);
            
            updatedModel.Name=product.Name;
            updatedModel.Price=product.Price;
            updatedModel.Quantity=product.Quantity;
            updatedModel.UpdateTime = product.UpdatedTime;

        }
    }
}
