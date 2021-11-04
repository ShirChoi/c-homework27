using System;
using System.ComponentModel.DataAnnotations;
namespace Homework27.Models {
    public class Product {
        public int ID { get; set; }
        [Required(ErrorMessage = "can't be empty")]
        public string Name { get; set; }
        [Required(ErrorMessage = "can't be empty")]
        public decimal Cost { get; set; }
    }
}
