using Catalog.API.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Data
{
    public class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool existProduct = productCollection.Find(x => true).Any();

            if (!existProduct)
            {
                productCollection.InsertManyAsync(GetPreconfiguredProducts());
            }
        }

        private static IEnumerable<Product> GetPreconfiguredProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Name = "Iphone X",
                    Summary = "Iphone X Summary",
                    Description = "Iphone X 24GB 1TB HD 248GB SDD",
                    ImageFile = "product-1.png",
                    Price = 470.00M,
                    Category = "Smart Phone"
                },
                new Product()
                {
                    Name = "Iphone XI",
                    Summary = "Iphone XI Summary",
                    Description = "Iphone XI 24GB 1TB HD 248GB SDD",
                    ImageFile = "product-2.png",
                    Price = 570.00M,
                    Category = "Smart Phone"
                },
                new Product()
                {
                    Name = "Iphone XII",
                    Summary = "Iphone XII Summary",
                    Description = "Iphone XII 24GB 1TB HD 248GB SDD",
                    ImageFile = "product-3.png",
                    Price = 670.00M,
                    Category = "Smart Phone"
                }
            };
        }
    }
}
