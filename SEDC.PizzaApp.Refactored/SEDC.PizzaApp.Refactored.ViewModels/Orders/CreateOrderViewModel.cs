using SEDC.PizzaApp.Refactored.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Refactored.ViewModels.Orders
{
    public class CreateOrderViewModel
    {
        [Display(Name ="Payment method")]
        public PaymentMethod PaymentMethod { get; set; }

        [Display(Name = "User")]
        public int UserId { get; set; }

        [Display(Name = "Is order delivered")]
        public bool IsDelivered { get; set; }


    }
}
