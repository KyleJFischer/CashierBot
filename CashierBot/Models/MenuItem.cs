using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CashierBot.Models
{
    [Serializable]
    public class MenuItem
    {
        public string name;
        public int comboNumber;
        public decimal cost;
        public List<string> ingredients;
        public int calories;

        public MenuItem(string name, int comboNumber, decimal cost, List<string> ingredients, int calories)
        {
            this.name = name;
            this.comboNumber = comboNumber;
            this.cost = cost;
            this.ingredients = ingredients;
            this.calories = calories;
        }
        public MenuItem(string name, int comboNumber, decimal cost, int calories)
        {
            this.name = name;
            this.comboNumber = comboNumber;
            this.cost = cost;    
            this.calories = calories;
        }
    }
}