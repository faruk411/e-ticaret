using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace e_ticaret_MVC.Entity
{
    public class DataInitializer:DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var Kategoriler = new List<Category>()
            {
                new Category{Name="Kamera" , Description="kamera ürünleri"},
                new Category{Name="Bilgisayar" , Description="Bilgisayar ürünleri"},
                new Category{Name="Elektronik" , Description="Elektronik ürünleri"},
                new Category{Name="Telefon" , Description="Telefon ürünleri"},
                new Category{Name="Beyaz eşya" , Description="Beyaz eşya ürünleri"}
            };
            foreach (var kategori in Kategoriler)
            {
                context.Categories.Add(kategori);
            }
            context.SaveChanges();
            List<Product> urunler = new List<Product>()
            {
                new Product(){Name="Canon Eos 1200D 18-55 mm DC Profesyonel Dijital Fotoğraf Makinesi",Description="Kullanmayı çok seveceğiniz ergonomik tasarım optik vizör, çekiminizi oluşturmanıza ve tahmin etmenize olanak tanıyarak her zaman anın arkasındaki duyguyu yakalamak için hazır olmanızı sağlar . Sezgisel kullanımlı kullanıcı dostu kontrolleri ve görüntüyü incelemek için 7,5 cm'lik (3 inç) geniş LCD ekranıyla EOS 1200d'yi kullanması çok keyiflidir ",Price=1200 , Stock=500 , IsApproved=true , CategoryId=1,IsHome=true,Image="1.jpg"},
                new Product(){Name="Canon Eos 100d 18-55 mm DC Profesyonel  Fotoğraf Makinesi",Description="Kullanmayı çok seveceğiniz ergonomik tasarım optik vizör, çekiminizi oluşturmanıza ve tahmin etmenize olanak tanıyarak her zaman anın arkasındaki duyguyu yakalamak için hazır olmanızı sağlar . Sezgisel kullanımlı kullanıcı dostu kontrolleri ve görüntüyü incelemek için 7,5 cm'lik (3 inç) geniş LCD ekranıyla EOS 1200d'yi kullanması çok keyiflidir ",Price=2000 , Stock=500 , IsApproved=true , CategoryId=1,IsHome=true,Image="2.jpg"},
                new Product(){Name="Canon Eos 700D 18-55 mm DC DSLR Dijital Fotoğraf Makinesi",Description="Kullanmayı çok seveceğiniz ergonomik tasarım optik vizör, çekiminizi oluşturmanıza ve tahmin etmenize olanak tanıyarak her zaman anın arkasındaki duyguyu yakalamak için hazır olmanızı sağlar . Sezgisel kullanımlı kullanıcı dostu kontrolleri ve görüntüyü incelemek için 7,5 cm'lik (3 inç) geniş LCD ekranıyla EOS 1200d'yi kullanması çok keyiflidir ",Price=1800 , Stock=500 , IsApproved=false , CategoryId=1,IsHome=true,Image="3.jpg"},
                new Product(){Name="Canon Eos 100D 18-55 mm DC IS STM KIT DSLR Fotoğraf Makinesi",Description="Kullanmayı çok seveceğiniz ergonomik tasarım optik vizör, çekiminizi oluşturmanıza ve tahmin etmenize olanak tanıyarak her zaman anın arkasındaki duyguyu yakalamak için hazır olmanızı sağlar . Sezgisel kullanımlı kullanıcı dostu kontrolleri ve görüntüyü incelemek için 7,5 cm'lik (3 inç) geniş LCD ekranıyla EOS 1200d'yi kullanması çok keyiflidir ",Price=1000 , Stock=500 , IsApproved=true , CategoryId=1,IsHome=true, Image = "4.jpg"},
                new Product(){Name="Canon Eos 700D+18-55 ıs Stm + Çanta + 16Gb hafıza kartı   ",Description="Kullanmayı çok seveceğiniz ergonomik tasarım optik vizör, çekiminizi oluşturmanıza ve tahmin etmenize olanak tanıyarak her zaman anın arkasındaki duyguyu yakalamak için hazır olmanızı sağlar . Sezgisel kullanımlı kullanıcı dostu kontrolleri ve görüntüyü incelemek için 7,5 cm'lik (3 inç) geniş LCD ekranıyla EOS 1200d'yi kullanması çok keyiflidir ",Price=1500 , Stock=500 , IsApproved=false , CategoryId=1,IsHome=false,Image="5.jpg"},

                new Product(){Name="Dell Inspiron 5567 Intel Core i5 11200U 8Gb Ram 1TB Ssd RXT3050Ti ",Price=27000 , Stock=500 , IsApproved=true , CategoryId=2,IsHome = false,Image="1.jpg"},
                new Product(){Name="Lenova Ideapad 310 Intel Core i3 8500U 12Gb Ram 500Gb Ssd Gtx1650",Description="Kullanmayı çok seveceğiniz ergonomik tasarım optik vizör, çekiminizi oluşturmanıza ve tahmin etmenize olanak tanıyarak her zaman anın arkasındaki duyguyu yakalamak için hazır olmanızı sağlar . Sezgisel kullanımlı kullanıcı dostu kontrolleri ve görüntüyü incelemek için 7,5 cm'lik (3 inç) geniş LCD ekranıyla EOS 1200d'yi kullanması çok keyiflidir ",Price=18000 , Stock=1200 , IsApproved=true , CategoryId=2,IsHome=true, Image = "2.jpg"},
                new Product(){Name="Asus UX310UQ-FB418T Intel Core i7 7500U 8Gb Ram 500Gb Ssd Gtx3050 ",Description="Kullanmayı çok seveceğiniz ergonomik tasarım optik vizör, çekiminizi oluşturmanıza ve tahmin etmenize olanak tanıyarak her zaman anın arkasındaki duyguyu yakalamak için hazır olmanızı sağlar . Sezgisel kullanımlı kullanıcı dostu kontrolleri ve görüntüyü incelemek için 7,5 cm'lik (3 inç) geniş LCD ekranıyla EOS 1200d'yi kullanması çok keyiflidir ",Price=26000 , Stock=0 , IsApproved=false , CategoryId=2,IsHome=true,Image="3.jpg"},
                new Product(){Name="Asus UX310UQ-FB418T Intel Core i7 7500U 8Gb Ram 500Gb Ssd Gtx1650",Description="Kullanmayı çok seveceğiniz ergonomik tasarım optik vizör, çekiminizi oluşturmanıza ve tahmin etmenize olanak tanıyarak her zaman anın arkasındaki duyguyu yakalamak için hazır olmanızı sağlar . Sezgisel kullanımlı kullanıcı dostu kontrolleri ve görüntüyü incelemek için 7,5 cm'lik (3 inç) geniş LCD ekranıyla EOS 1200d'yi kullanması çok keyiflidir ",Price=20000 , Stock=600 , IsApproved=true , CategoryId=2, IsHome = false,Image="4.jpg"},
                new Product(){Name="Asus UX310UQ-FB418T Intel Core i7 7500U 8Gb Ram 500Gb Ssd Gtx4050",Description="Kullanmayı çok seveceğiniz ergonomik tasarım optik vizör, çekiminizi oluşturmanıza ve tahmin etmenize olanak tanıyarak her zaman anın arkasındaki duyguyu yakalamak için hazır olmanızı sağlar . Sezgisel kullanımlı kullanıcı dostu kontrolleri ve görüntüyü incelemek için 7,5 cm'lik (3 inç) geniş LCD ekranıyla EOS 1200d'yi kullanması çok keyiflidir ",Price=36000 , Stock=500 , IsApproved=true , CategoryId=2, IsHome = false, Image = "5.jpg"},

                new Product(){Name="LG 49UH610V 49 124 Ekran 4K Uydu Alıcılı Smart LED TV ",Price=27000 , Stock=500 , IsApproved=true , CategoryId=2, IsHome = false,Image="1.jpg"},
                new Product(){Name="VESTEL 49UB8300 49 124 eKRAN 4k Smart LED TV",Description="Kullanmayı çok seveceğiniz ergonomik tasarım optik vizör, çekiminizi oluşturmanıza ve tahmin etmenize olanak tanıyarak her zaman anın arkasındaki duyguyu yakalamak için hazır olmanızı sağlar . Sezgisel kullanımlı kullanıcı dostu kontrolleri ve görüntüyü incelemek için 7,5 cm'lik (3 inç) geniş LCD ekranıyla EOS 1200d'yi kullanması çok keyiflidir ",Price=20000 , Stock=1200 , IsApproved=true , CategoryId=3, IsHome = false, Image = "2.jpg"},
                new Product(){Name="Samsung 55KU7500 55 140 Ekran 4K Uydu Alıcı Smart  ",Description="Kullanmayı çok seveceğiniz ergonomik tasarım optik vizör, çekiminizi oluşturmanıza ve tahmin etmenize olanak tanıyarak her zaman anın arkasındaki duyguyu yakalamak için hazır olmanızı sağlar . Sezgisel kullanımlı kullanıcı dostu kontrolleri ve görüntüyü incelemek için 7,5 cm'lik (3 inç) geniş LCD ekranıyla EOS 1200d'yi kullanması çok keyiflidir ",Price=23000 , Stock=0 , IsApproved=false , CategoryId=3, IsHome = true, Image = "3.jpg"},
                new Product(){Name="LG 55UH615V 55 140 Ekran 4K Uydu Alıcılı Smart Wi-Fi",Description="Kullanmayı çok seveceğiniz ergonomik tasarım optik vizör, çekiminizi oluşturmanıza ve tahmin etmenize olanak tanıyarak her zaman anın arkasındaki duyguyu yakalamak için hazır olmanızı sağlar . Sezgisel kullanımlı kullanıcı dostu kontrolleri ve görüntüyü incelemek için 7,5 cm'lik (3 inç) geniş LCD ekranıyla EOS 1200d'yi kullanması çok keyiflidir ",Price=29000 , Stock=600 , IsApproved=true , CategoryId=3, IsHome = true, Image = "4.jpg"},
                new Product(){Name="Sony Kd-55Xd7005B 55 140 Ekran 4K Uydu Alıcılı Smart LED TV",Description="Kullanmayı çok seveceğiniz ergonomik tasarım optik vizör, çekiminizi oluşturmanıza ve tahmin etmenize olanak tanıyarak her zaman anın arkasındaki duyguyu yakalamak için hazır olmanızı sağlar . Sezgisel kullanımlı kullanıcı dostu kontrolleri ve görüntüyü incelemek için 7,5 cm'lik (3 inç) geniş LCD ekranıyla EOS 1200d'yi kullanması çok keyiflidir ",Price=35000 , Stock=500 , IsApproved=true , CategoryId=3,IsHome=false, Image = "5.jpg"},

                new Product(){Name="Apple Iphone 6 32 Gb (Türkiye Garantili)",Price=3000 , Stock=500 , IsApproved=true , CategoryId=4, IsHome = false,Image="1.jpg"},
                new Product(){Name="Apple Iphone 7 32 Gb (Türkiye Garantili)",Description="Kullanmayı çok seveceğiniz ergonomik tasarım optik vizör, çekiminizi oluşturmanıza ve tahmin etmenize olanak tanıyarak her zaman anın arkasındaki duyguyu yakalamak için hazır olmanızı sağlar . Sezgisel kullanımlı kullanıcı dostu kontrolleri ve görüntüyü incelemek için 7,5 cm'lik (3 inç) geniş LCD ekranıyla EOS 1200d'yi kullanması çok keyiflidir ",Price=5600 , Stock=1200 , IsApproved=true , CategoryId=4, IsHome = true, Image = "2.jpg"},
                new Product(){Name="Apple Iphone 6S 32 Gb (Türkiye Garantili)",Description="Kullanmayı çok seveceğiniz ergonomik tasarım optik vizör, çekiminizi oluşturmanıza ve tahmin etmenize olanak tanıyarak her zaman anın arkasındaki duyguyu yakalamak için hazır olmanızı sağlar . Sezgisel kullanımlı kullanıcı dostu kontrolleri ve görüntüyü incelemek için 7,5 cm'lik (3 inç) geniş LCD ekranıyla EOS 1200d'yi kullanması çok keyiflidir ",Price=3400 , Stock=0 , IsApproved=false , CategoryId=4, IsHome = true, Image = "3.jpg"},
                new Product(){Name="Case 4U Manyetik Mıknatıslı Araç İçi Telefon Tutucu",Description="Kullanmayı çok seveceğiniz ergonomik tasarım optik vizör, çekiminizi oluşturmanıza ve tahmin etmenize olanak tanıyarak her zaman anın arkasındaki duyguyu yakalamak için hazır olmanızı sağlar . Sezgisel kullanımlı kullanıcı dostu kontrolleri ve görüntüyü incelemek için 7,5 cm'lik (3 inç) geniş LCD ekranıyla EOS 1200d'yi kullanması çok keyiflidir ",Price=4000 , Stock=600 , IsApproved=true , CategoryId=4, IsHome = false, Image = "4.jpg"},
                new Product(){Name="Xiaomi Mi 5S 64 Gb (İthalatçı Garantili)",Description="Kullanmayı çok seveceğiniz ergonomik tasarım optik vizör, çekiminizi oluşturmanıza ve tahmin etmenize olanak tanıyarak her zaman anın arkasındaki duyguyu yakalamak için hazır olmanızı sağlar . Sezgisel kullanımlı kullanıcı dostu kontrolleri ve görüntüyü incelemek için 7,5 cm'lik (3 inç) geniş LCD ekranıyla EOS 1200d'yi kullanması çok keyiflidir ",Price=5500 , Stock=500 , IsApproved=true , CategoryId=4,IsHome=false, Image = "5.jpg"}

            };
            foreach(var urun in urunler)
            {
                context.Products.Add(urun);
            }
            context.SaveChanges();

            base.Seed(context);
        }
    }
}