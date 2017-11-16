using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CashierBot.Models
{
    [Serializable]
    public class Cart
    {
        List<MenuItem> itemsInCart;
        decimal currentCost;

        public Cart()
        {
            this.itemsInCart = new List<MenuItem>();
            this.currentCost = (decimal)0.0;
        }

        private Decimal calculateCost()
        {
            Decimal runningCost = (Decimal)0.0;

            foreach (MenuItem item in itemsInCart)
            {
                runningCost += item.cost;
            }
            return runningCost;
        }
        public decimal GetCost()
        {
            return this.currentCost;
        }

        public void addItemToCart(MenuItem item)
        {
            itemsInCart.Add(item);
            this.currentCost = calculateCost();
        }

        public void removeItemFromCart(MenuItem item)
        {
            //Remove Item
            this.currentCost = calculateCost();
        }

        public int NumberOfItemsInCart()
        {
            return itemsInCart.Count();
        }
    }
}