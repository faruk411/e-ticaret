using e_ticaret_MVC.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace e_ticaret_MVC.Models
{
    public class UserOrderModel
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public double Total { get; set; }
        public DateTime Deta { get; set; }
        public EnumOrderState OrderState { get; set; }
    }
}