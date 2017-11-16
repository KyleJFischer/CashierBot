using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CashierBot.Models;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;

namespace CashierBot.Services
{
    public static class MainService
    {
        public static IDatabase database = new TestDatabase();

        public static Response AddItemToOrder(LuisResult result)
        {
            Response response = new Response();
            if (result.Entities.Count > 0)
            {
                MenuItem item = database.GetMenuItem(result.Entities[0].Entity.ToString());
                if (item == null)
                {
                    if (result.Entities[0].Type.ToString() == "builtin.number")
                    {
                        //I just want it to work to test azure out. 
                        //if (int.TryParse(result.Entities[0].Entity.ToString(), out int requestedNumber)){
                        //    item = database.GetMenuItemByComboNumber(requestedNumber);
                        //    response.Message = "Ok, I have added a " + item.name + " to your cart.";
                        //    response.item = item;
                        //    return response;
                        //}
                        
                    }
                    response = new Response("Your requested item is not on the menu. Please give me another item", null);
                    return response;

                } else
                {
                    response = new Response("Ok, I have added a " + item.name + " to your cart.", item);
                    return response;
                }
                
            }
            else
            {
                response = new Response("Please tell me what you want", null);
                return response;
            }

        }
        
        public static string GetMenu()
        {
            List<MenuItem> menu = database.GetMenu();
            string message = "";
            foreach(MenuItem item in menu)
            {
                message += "" + item.comboNumber + ": " + item.name + " for " + item.cost.ToString() + '\n'+ '\n';
            }

            return message;
        }

    }
}