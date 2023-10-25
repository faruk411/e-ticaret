using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace e_ticaret_MVC.Entity
{
    public class Product
    {
        public int Id { get; set; }
        [DisplayName("Ürün Adı")]
        public string Name { get; set; }
        [DisplayName("Ürün Açıklaması")]
        public string Description { get; set; }
        [DisplayName("Ürün Fiyatı")]
        public double Price { get; set; }
        [DisplayName("Stok sayısı")]
        public int Stock { get; set; }
        [DisplayName("Ürün Resmi")]
        public string Image { get; set; }
        public bool IsHome { get; set; }
        public bool IsApproved { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }



    }
}