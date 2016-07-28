using SportsStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        private IProductsRepository repository;
        public NavController(IProductsRepository repo) {
            this.repository = repo;
        }

        public PartialViewResult Menu(string category = null) {
            IEnumerable<string> categories = repository.Products.Select(p => p.Category).Distinct().OrderBy(x => x);

            ViewBag.SelectedCategory = category;

            return PartialView(categories);
        }
    }
}
