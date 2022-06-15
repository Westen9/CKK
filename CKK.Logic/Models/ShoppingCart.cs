using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
    public class ShoppingCart
    {
        private Customer Customer;
        private List<ShoppingCartItem> Products;

        public ShoppingCart(Customer cust)
        {
            Customer = cust;
        }
        public int GetCustomerid()
        {
            return Customer.GetId();
        }        

        public ShoppingCartItem AddProduct(Product prod, int quantity)
        {
            var shoppingcartitem = Products.FirstOrDefault(p => p.GetProduct().GetId() == prod.GetId());

            if (quantity > 0 && prod != null)
            {
                if (shoppingcartitem == null)
                {
                    var x = new ShoppingCartItem(prod, quantity);
                    Products.Add(x);
                    return shoppingcartitem;
                }
                else
                {
                    shoppingcartitem.SetQauntity(shoppingcartitem.GetQuantity() + quantity);
                    return shoppingcartitem;
                }
            }
            else
            {
                return null;
            }
        }
        public ShoppingCartItem RemoveProduct(Product prod, int quantity)
        {
            var shoppingcartitem = Products.FirstOrDefault(p => p.GetProduct() == prod);

            if (shoppingcartitem != null && prod != null)
            {
                if (shoppingcartitem.GetQuantity() - quantity > 0)
                {
                    shoppingcartitem.SetQauntity(shoppingcartitem.GetQuantity() - quantity);
                    return shoppingcartitem;
                }
                else 
                {
                    Products.Remove(shoppingcartitem);
                    return shoppingcartitem;
                }
            }
            else
            {
                return null;
            }
        }
        public ShoppingCartItem GetProductById(int id)
        {
            var shoppingcartitem = Products.FirstOrDefault(p => p.GetProduct().GetId() == id);

            if (shoppingcartitem.GetProduct().GetId() == id)
            {
                return shoppingcartitem;
            }
            else
            {
                return null;
            }
        }
        public decimal GetTotal()
        {
            decimal Total = 0;

            foreach (var Product in Products)
            {
                Total += (Product.GetQuantity() * Product.GetProduct().GetPrice());
            }

            return Total;
        }

        public List<ShoppingCartItem> GetProduct()
        {
            return Products;
        }
    }
}

