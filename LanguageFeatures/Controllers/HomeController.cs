using LanguageFeatures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace LanguageFeatures.Controllers {
    public class HomeController : Controller {
        //
        // GET: /Home/

        public string Index() {
            return "Navigate to an URL to show an example";
        }

        public ViewResult AutoProperty() {
            // create a new Product object
            Product myProduct = new Product();

            // set the property value
            myProduct.Name = "Kayak";

            // get the property
            string productName = myProduct.Name;

            return View("Result", (object)string.Format("Product name: {0}", productName));
        }

        public ViewResult CreateProduct() {
            // create a new Product object
            Product myProduct = new Product() {
                ProductId = 100,
                Name = "Kayak",
                Description = "A boat for one person",
                Price = 275M,
                Category = "Watersports"
            };


            return View("Result", (object)string.Format("Category: {0}", myProduct.Category));
        }

        public ViewResult CreateCollection() {
            string[] stringArray = { "apple", "orange", "plum" };

            List<int> intList = new List<int> { 10, 20, 30, 40 };

            Dictionary<string, int> myDict = new Dictionary<string, int> {
                {"apple", 10}, {"orange", 20}, {"plum", 30}
            };

            return View("Result", (object)stringArray[1]);
        }

        public ViewResult UseExtension() {
            // create and populate ShoppingCart
            ShoppingCart cart = new ShoppingCart {
                Products = new List<Product> {
                    new Product {Name = "Kayak", Price = 275M},
                    new Product {Name = "Lifejacket", Price = 48.95M},
                    new Product {Name = "Soccer ball", Price = 19.50M},
                    new Product {Name = "Corner flag", Price = 34.95M}
                }
            };

            // get the total value of the products in the cart
            decimal cartTotal = cart.TotalPrices();

            return View("Result", (object)string.Format("Total: {0:c}", cartTotal));
        }

        public ViewResult UseFilterExtensionMethod() {
            // create and populate ShoppingCart
            ShoppingCart cart = new ShoppingCart {
                Products = new List<Product> {
                    new Product {Name = "Kayak", Price = 275M, Category="Watersports"},
                    new Product {Name = "Lifejacket", Price = 48.95M, Category="Watersports"},
                    new Product {Name = "Soccer ball", Price = 19.50M, Category="Soccer" },
                    new Product {Name = "Corner flag", Price = 34.95M, Category="Soccer" }
                }
            };

            Func<Product, bool> dCategoryFilter = delegate(Product prod) { return prod.Category == "Soccer"; };
            Func<Product, bool> lCategoryFilter = prod => prod.Category == "Soccer";

            //return View("Result", (object)string.Format("Total: {0:c}", cart.FilterByCategory("Soccer").TotalPrices()));
            return View("Result", (object)string.Format("Total: {0:c}", cart.Filter(dCategoryFilter).TotalPrices()));
        }

        public ViewResult FindProducts() {
            Product[] products = {
                new Product {Name = "Kayak", Price = 275M, Category="Watersports"},
                new Product {Name = "Lifejacket", Price = 48.95M, Category="Watersports"},
                new Product {Name = "Soccer ball", Price = 19.50M, Category="Soccer" },
                new Product {Name = "Corner flag", Price = 34.95M, Category="Soccer" }
            };

            Product[] aFoundProducts = new Product[3];
            Array.Sort(products, (item1, item2) => {
                return Comparer<decimal>.Default.Compare(item1.Price, item2.Price);
            });

            // get the first three items in the array as the results
            Array.Copy(products, aFoundProducts, 3);

            // create the result
            StringBuilder result2 = new StringBuilder();
            foreach (Product prod in aFoundProducts) {
                result2.AppendFormat("Product: {0} ", prod.Price);
            }

            var lFoundProducts = from match in products
                                 orderby match.Price descending
                                 select new {
                                     match.Name,
                                     match.Price
                                 };

            return View("Result", (object)result2.ToString());
        }
    }
}
