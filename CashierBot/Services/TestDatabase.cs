using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CashierBot.Models;

namespace CashierBot.Services
{
    public class TestDatabase : IDatabase
    {
        public List<MenuItem> GetMenu()
        {
            List<MenuItem> MenuToReturn = new List<MenuItem>();

            MenuToReturn.Add(new MenuItem("McChicken",1,(decimal)1.25,1000));

            MenuToReturn.Add(new MenuItem("McRib", 2, (decimal)3, 1234));


            MenuToReturn.Add(new MenuItem("McShake", 3, (decimal).50, 120));
            MenuToReturn.Add(new MenuItem("McDouble", 4, (decimal).75, 300));
            return MenuToReturn;
        }

        public MenuItem GetMenuItem(string itemName)
        {
            List<MenuItem> menu = GetMenu();

            return menu.Find(item => item.name.ToLower() == itemName.ToLower());
        }

        public MenuItem GetMenuItemByComboNumber(int number)
        {
            List<MenuItem> menu = GetMenu();

            return menu.Find(item => item.comboNumber == number);
        }

        public decimal GetPriceOfItem(string itemName)
        {
            List<MenuItem> menu = GetMenu();

            return menu.Find(item => item.name == itemName).cost;
        }
    }
}