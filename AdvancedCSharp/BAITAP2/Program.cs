using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BAITAP2
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<Product>()
            {
                new Product()
                    {Type = "Classic", Color = "red", Country = "USA", Name = "BMW", Price = "1"},
                new Product()
                    {Type = "Modern", Color = "red", Country = "USA", Name = "Lamborghini", Price = "1.5"},
                new Product()
                    {Type = "Classic", Color = "red", Country = "VN", Name = "Mercedes", Price = "1"},
                new Product()
                    {Type = "Classic", Color = "blue", Country = "USA", Name = "Mercedes", Price = "1.2"},
                new Product()
                    {Type = "Classic", Color = "red", Country = "USA", Name = "Mercedes", Price = "2"},
                new Product()
                    {Type = "Modern", Color = "blue", Country = "VN", Name = "Ferrari", Price = "2.5"},
                new Product()
                    {Type = "Modern", Color = "blue", Country = "USA", Name = "Ferrari", Price = "3.2"},
                new Product()
                    {Type = "Classic", Color = "red", Country = "VN", Name = "Mercedes", Price = "1.3"},
                new Product()
                    {Type = "Modern", Color = "red", Country = "VN", Name = "Lamborghini", Price = "3"},
            };
            var result = from product in list
                         where product.Name != "BMW"
                         where product.Type == "Classic" && product.Color == "red" || product.Type == "Modern"
                         group product by new
                         {
                             product.Type,
                             product.Color,
                             product.Name
                         } into customProduct
                         let total = customProduct.Sum(x => double.Parse(x.Price))
                         orderby total
                         let count = customProduct.Count()
                         let listCountry = customProduct.Select(x => x.Country)
                         let listPrice = customProduct.OrderBy(x=>x.Price).Select(x => double.Parse(x.Price))
                         select new
                         {
                             type = customProduct.Key.Type,
                             color = customProduct.Key.Color,
                             name = customProduct.Key.Name,
                             countrys = listCountry.ToList(),
                             prices = listPrice.ToList(),
                             totalPrice = total,
                             countProduct = count
                         };

            if (result.Count() > 0)
            {
                foreach (var item in result)
                {
                    Console.WriteLine("Type: " + item.type + "\tColor: " + item.color + "\tName: " + item.name);
                    for (int i = 0; i < item.countProduct; i++)
                    {
                        if(item.countrys.Count()>0&&item.prices.Count()>0)
                            Console.WriteLine("\tCountry: " + item.countrys[i] + "\t" + "Price: " + item.prices[i]);
                    }
                    Console.WriteLine("\tTotalPrice: " + item.totalPrice);
                }
            }
            
            
            Console.ReadLine();
        }
    }
    public class Category
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public int Count { get; set; }
        public decimal TotalPrice { get; set; }
        public List<Product> Products { get; set; }
    }

    public class Product
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Country { get; set; }
        public string Price { get; set; }
    }


}
