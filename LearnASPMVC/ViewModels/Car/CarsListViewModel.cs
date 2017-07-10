using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearnASPNETMVC.Models;

namespace LearnASPNETMVC.ViewModels.Car
{
    public class CarsListViewModel
    {
        public CarsListViewModel(IEnumerable<Models.Car> cars)
        {
            CarsList = cars.Select(
            c => new SelectListItem()
            {
                Text = c.Model
            }
            );
            FastestCar = cars.OrderByDescending(c => c.MaxSpeed).FirstOrDefault();
        }
        public IEnumerable<SelectListItem> CarsList
        {
            get; private set;
        }
        public Models.Car FastestCar { get; set; }
    }
}