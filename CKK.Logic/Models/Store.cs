using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
    public class Store
    {
        private int Id;
        private string Name;
        private List<StoreItem> items;

        public Store() { }

        public int GetId()
        {
            return Id;
        }

        public void SetId(int id)
        {
            Id = id;
        }

        public string GetName()
        {
            return Name;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public StoreItem AddStoreItem(Product prod, int quantity)
        {
            if (quantity > 0)
            {
                var storeitem = items.FirstOrDefault(p => p.GetProduct().GetId() == prod.GetId());

                if (storeitem == null)
                {
                    var x = new StoreItem(prod, quantity);
                    items.Add(x);
                    return storeitem;
                }
                else
                {
                    storeitem.SetQuantity(storeitem.GetQuantity() + quantity);
                    return storeitem;
                }
            }
            else
            {
                return null;
            }
        }

        public StoreItem RemoveStoreItem(int id, int quantity)
        {
            var storeitem = items.FirstOrDefault(p => p.GetProduct().GetId() == id);

            if (quantity > 0 && storeitem.GetQuantity() != 0)
            {
                if (storeitem != null)
                {
                    if (storeitem.GetQuantity() <= quantity)
                    {
                        storeitem.SetQuantity(0);
                        return storeitem;
                    }
                    else
                    {
                        storeitem.SetQuantity(storeitem.GetQuantity() - quantity);
                        return storeitem;
                    }
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        public StoreItem FindStoreItemById(int id)
        {
            var storeitem = items.FirstOrDefault(p => p.GetProduct().GetId() == id);

            if (storeitem.GetProduct().GetId() == id)
            {
                return storeitem;
            }
            else
            {
                return null;
            }
        }
        public List<StoreItem> GetStoreItem()
        {
            return items;
        }
    }
}