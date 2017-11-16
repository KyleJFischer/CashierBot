using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashierBot.Models;

namespace CashierBot.Services
{
    public interface IDatabase
    {
        MenuItem GetMenuItem(string itemName);
        List<MenuItem> GetMenu();
        Decimal GetPriceOfItem(string itemName);
        MenuItem GetMenuItemByComboNumber(int number);

        
    }
}
