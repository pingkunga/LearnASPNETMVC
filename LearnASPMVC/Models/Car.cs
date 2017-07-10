using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LearnASPNETMVC.Models
{
    public class Car
    {
        public int ID { get; set; }

        [Required]
        [RegularExpression("..+")]
        public string Model { get; set; }

        [Range(10, 300)]
        public double MaxSpeed { get; set; }
    }
}