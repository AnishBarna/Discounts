using Discount.Models;


namespace Discount.Data
{
    public static class DBInitializer
{
    public static void Initialize(DiscountContext context)
    {


        if( context.ProductCities.Any() ||
            context.Products.Any() || 
            context.Cities.Any() ||
            context.Keys.Any())
            {
                return;
            }

        var keys = new Key[]
        {
            new Key{Id = 1 , CityId = 6 , ProductCityId = 31 , ProductId = 21}
        };

        var cities = new City[]
        {
            new City{CityId = 1  , CityName = "City 1 "},
            new City{CityId = 2  , CityName = "City 2 "},
            new City{CityId = 3  , CityName = "City 3 "},
            new City{CityId = 4  , CityName = "City 4 "},
            new City{CityId = 5  , CityName = "City 5 "}
        };

        var products = new Product[]
        {
            new Product{ProductId = 1  , ProductName = "Product 1 "},
            new Product{ProductId = 2  , ProductName = "Product 2 "},
            new Product{ProductId = 3  , ProductName = "Product 3 "},
            new Product{ProductId = 4  , ProductName = "Product 4 "},
            new Product{ProductId = 5  , ProductName = "Product 5 "},
            new Product{ProductId = 6  , ProductName = "Product 6 "},
            new Product{ProductId = 7  , ProductName = "Product 7 "},
            new Product{ProductId = 8  , ProductName = "Product 8 "},
            new Product{ProductId = 9  , ProductName = "Product 9 "},
            new Product{ProductId = 10  , ProductName = "Product 10 "},
            new Product{ProductId = 11  , ProductName = "Product 11 "},
            new Product{ProductId = 12  , ProductName = "Product 12 "},
            new Product{ProductId = 13  , ProductName = "Product 13 "},
            new Product{ProductId = 14  , ProductName = "Product 14 "},
            new Product{ProductId = 15  , ProductName = "Product 15 "},
            new Product{ProductId = 16  , ProductName = "Product 16 "},
            new Product{ProductId = 17  , ProductName = "Product 17 "},
            new Product{ProductId = 18  , ProductName = "Product 18 "},
            new Product{ProductId = 19  , ProductName = "Product 19 "},
            new Product{ProductId = 20  , ProductName = "Product 20 "},
        
        };

        var productcities = new ProductCity[]
        {
            new ProductCity{Id = 1  , CityId =  3  , ProductId =  16 },
            new ProductCity{Id = 2  , CityId =  3  , ProductId =  5 },
            new ProductCity{Id = 3  , CityId =  5  , ProductId =  5 },
            new ProductCity{Id = 4  , CityId =  4  , ProductId =  10 },
            new ProductCity{Id = 5  , CityId =  1  , ProductId =  2 },
            new ProductCity{Id = 6  , CityId =  1  , ProductId =  6 },
            new ProductCity{Id = 7  , CityId =  4  , ProductId =  20 },
            new ProductCity{Id = 8  , CityId =  4  , ProductId =  1 },
            new ProductCity{Id = 9  , CityId =  2  , ProductId =  15 },
            new ProductCity{Id = 10  , CityId =  2  , ProductId =  16 },
            new ProductCity{Id = 11  , CityId =  4  , ProductId =  5 },
            new ProductCity{Id = 12  , CityId =  3  , ProductId =  5 },
            new ProductCity{Id = 13  , CityId =  4  , ProductId =  7 },
            new ProductCity{Id = 14  , CityId =  3  , ProductId =  8 },
            new ProductCity{Id = 15  , CityId =  2  , ProductId =  8 },
            new ProductCity{Id = 16  , CityId =  2  , ProductId =  17 },
            new ProductCity{Id = 17  , CityId =  1  , ProductId =  17 },
            new ProductCity{Id = 18  , CityId =  1  , ProductId =  19 },
            new ProductCity{Id = 19  , CityId =  3  , ProductId =  3 },
            new ProductCity{Id = 20  , CityId =  5  , ProductId =  18 },
            new ProductCity{Id = 21  , CityId =  2  , ProductId =  3 },
            new ProductCity{Id = 22  , CityId =  4  , ProductId =  12 },
            new ProductCity{Id = 23  , CityId =  2  , ProductId =  19 },
            new ProductCity{Id = 24  , CityId =  1  , ProductId =  18 },
            new ProductCity{Id = 25  , CityId =  4  , ProductId =  16 },
            new ProductCity{Id = 26  , CityId =  4  , ProductId =  11 },
            new ProductCity{Id = 27  , CityId =  3  , ProductId =  19 },
            new ProductCity{Id = 28  , CityId =  4  , ProductId =  4 },
            new ProductCity{Id = 29  , CityId =  1  , ProductId =  10 },
            new ProductCity{Id = 30  , CityId =  5  , ProductId =  4 },

        };

        context.Cities.AddRange(cities);
        context.Products.AddRange(products);
        context.ProductCities.AddRange(productcities);
        context.Keys.AddRange(keys);    

        context.SaveChanges();
    }
}
}