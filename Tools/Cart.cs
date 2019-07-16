using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BACommerce.Tools
{
    public class Cart
    {
        private Dictionary<int, CartItem> _cart = new Dictionary<int, CartItem>();

        public List<CartItem> CartProductList
        {
            get
            {
                return _cart.Values.ToList();
            }
        }


        public void AddCart(CartItem item)
        {
            if (_cart.ContainsKey(item.Id))
            {
                _cart[item.Id].Quantity += item.Quantity;
            }
            else
            {
                _cart.Add(item.Id, item);
            }
        }

        public void RemoveCart(int id)
        {
            if (_cart[id].Quantity > 1)
            {
                _cart[id].Quantity -= 1;
                return;
            }

            _cart.Remove(id);
        }

        public void DecreaseCart(int id)
        {
            _cart[id].Quantity--;

            if (_cart[id].Quantity <= 0)
            {
                _cart.Remove(id);
            }
        }

        public void IncreaseCart(int id)
        {
            _cart[id].Quantity++;
        }




    }
}