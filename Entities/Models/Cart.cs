﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; }
        public Cart()
        {
            Lines = new List<CartLine>();
        }

        public virtual void AddItem(Product product, int quantity)
        {
            //ilgili urun yoksa sifirdan  bunu sepete ekle
            CartLine? line = Lines.Where(l => l.Product.ProductId == product.ProductId).FirstOrDefault();
            if (line == null)
            {
                Lines.Add(new CartLine() { Product = product, Quantity = quantity });
            }
            //urun varsa miktari arttir
            else
            {
                line.Quantity += quantity;
            }
        }

        public virtual void RemoveLine(Product product) => Lines.RemoveAll(l=>l.Product.ProductId == product.ProductId);

        public decimal ComputeTotalValue() => Lines.Sum(e=>e.Product.Price*e.Quantity);

        public virtual void Clear()=> Lines.Clear();
    }
}
 