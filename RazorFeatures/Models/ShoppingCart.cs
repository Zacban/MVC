using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RazorFeatures.Models {
    public class ShoppingCart {
        private LinqValueCalculator calc;

        public ShoppingCart(LinqValueCalculator calcParam) {
            calc = calcParam;
        }

        public IEnumerable<Product> Products { get; set; }

        public decimal CalculateProductsTotal() {
            return calc.ValueProducts(Products);
        }
    }
}