using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearnASPNETMVC.Models;
using LearnASPNETMVC.ViewModels.Car;

namespace LearnASPNETMVC.Controllers
{
    public class GarageController : Controller
    {
        public ActionResult CarsList()
        {
            var factory = new GarageFactory();
            var viewModel = new CarsListViewModel(factory.Cars);
            return View(viewModel);
        }
    }
}