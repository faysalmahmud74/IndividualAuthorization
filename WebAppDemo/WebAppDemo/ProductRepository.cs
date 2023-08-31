using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppDemo.Models;

namespace WebAppDemo
{
    public class ProductRepository
    {
        public int Add(ProductModel model)
        {
            using (var context = new ProductEntities())
            {
                ProductInfo e = new ProductInfo();

                e.Name = model.Name;
                e.Price = model.Price;
                e.Quantity = model.Quantity;
                e.Category = model.Category;


                context.ProductInfo.Add(e);
                context.SaveChanges();

                return e.Id;
            }
        }

        public List<ProductModel> GetAllData()
        {
            using (var context = new ProductEntities())
            {
                var result = context.ProductInfo.Select(x => new ProductModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    Quantity = x.Quantity,
                    Category = x.Category

                }
                ).ToList();

                return result;
            }
        }

        public ProductModel GetDetails(int id)
        {
            using (var context = new ProductEntities())
            {
                var result = context.ProductInfo.Where(x => x.Id == id).Select(x => new ProductModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    Quantity = x.Quantity,
                    Category = x.Category
                }
                ).FirstOrDefault();

                return result;
            }
        }

        public bool UpdateData(int id, ProductModel model)
        {
            using (var context = new ProductEntities())
            {
                var M = context.ProductInfo.FirstOrDefault(x => x.Id == id);
                if (M != null)
                {
                    M.Name = model.Name;
                    M.Price = model.Price;
                    M.Quantity = model.Quantity;
                    M.Category = model.Category;

                }

                context.SaveChanges();

                return true;
            }
        }

        public bool DeleteData(int id)
        {
            using (var context = new ProductEntities())
            {
                var d = context.ProductInfo.FirstOrDefault(x => x.Id == id);
                if (d != null)
                {
                    context.ProductInfo.Remove(d);
                    context.SaveChanges();
                    return true;
                }

                return false;
            }
        }

    }
}