using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using LearnASPNETMVC.Models;
using LearnASPNETMVC.ViewModels.Home;

namespace LearnASPNETMVC.Controllers
{
    public class HomeController : Controller
    {
        /*
        public ActionResult Index()
        {
            var factory = new ShopFactory();
            var products = factory.Products.ToList();
            return View(products);
        }
        */

        public ActionResult Index(string searchCriteria)
        {
            var factory = new ShopFactory();
            IQueryable<Product> prods = factory.Products.OrderBy(p => p.Name);
            if (searchCriteria != null)
            {
                prods = prods.Where(p => p.Name.Contains(searchCriteria));
            }
            var products = prods.Take(10).ToList();
            return View(products);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        // GET: Products
        public ActionResult ShowLanguage()
        {
            /*
             * แบบที่ 1 ใช้ ViewBag
            var languages = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            //ViewBag = Dynamic Object
            ViewBag.LanguagesList = languages;
            return View();
            */

            //แบบที่ 2 ใช้ ViewModel ในที่นี้ คือ CultureInfo
            //CultureInfo[] languages = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            //return View(languages);

            //แบบที่ 3 แยก View Model ออกมาเลย ผมที่ได้ คือ Code Clean ขึ้น ตัว Razer ไม่ C# Code มากจนเกินไป
            var viewModel = new ShowLanguagesViewModel(CultureInfo.GetCultures(CultureTypes.SpecificCultures));
            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            var factory = new ShopFactory();
            var found = factory.Products.Where(p => p.ID == id).FirstOrDefault();
            return View(found);
        }

        //Action Result ไม่จพเป็น Return View ทำได้หลายอย่าง เช่น อันนี้ Return เป็น Image
        public ActionResult Picture(int id)
        {
            var factory = new ShopFactory();
            var product = factory.Products.Where(p => p.ID == id).FirstOrDefault();
            if (product == null)
            {
                return HttpNotFound();
            }
            var img = new WebImage(string.Format("~/Content/images/{0}.jpg", product.ImageName));

            img.Resize(50, 50);
            return File(img.GetBytes(), "image/jpeg");
        }

        public ActionResult ComputeProduct(decimal? number1, decimal? number2)
        {
            var viewModel = new ComputeProductViewModel(number1, number2);
            return View(viewModel);
        }
    }
}