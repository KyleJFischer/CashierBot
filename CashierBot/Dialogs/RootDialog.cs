using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CashierBot.Models;
using CashierBot.Services;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;

namespace CashierBot.Dialogs
{
    [LuisModel("c000a0b0-d391-4230-be28-009e538a895a", "b78c49ff0b0540749f106cbcfd08e888")]
    [Serializable]
    public class RootDialog : LuisDialog<object>
    {
        Cart usersCart = new Cart();


        [LuisIntent("OrderItem")]
        public async Task OrderItem(IDialogContext context, LuisResult result)
        {

            string phrase = "";
            var res = MainService.AddItemToOrder(result);
            phrase = res.Message;
            if (res.item != null)
            {
                usersCart.addItemToCart(res.item as MenuItem);
                phrase += " Your total is now: " + usersCart.GetCost().ToString();
            }


            var message = context.MakeMessage();



            message.Text = phrase;
            message.Speak = phrase;


            await context.PostAsync(message);

            context.Wait(this.MessageReceived);
        }

        [LuisIntent("GetMenu")]
        public async Task GetMenu(IDialogContext context, LuisResult result)
        {
            string phrase = MainService.GetMenu();
            var message = context.MakeMessage();

            message.Text = phrase;
            message.Speak = phrase;


            await context.PostAsync(message);

            context.Wait(this.MessageReceived);
        }

        [LuisIntent("Welcome")]
        public async Task WelcomeCall(IDialogContext context, LuisResult result)
        {
            string menu = MainService.GetMenu();
            string phrase = "Hi and Welcome to McFisch. There are a few bugs but hey, they just add protein.\n\n";
            phrase += "You can see the menu using phrases such as \"Can I see the menu?\" and add items with \"I would like a McChicken\". \n\n";

            var message = context.MakeMessage();

            message.Text = phrase;
            message.Speak = phrase;


            await context.PostAsync(message);

            context.Wait(this.MessageReceived);
        }


        [LuisIntent("Checkout")]
        public async Task Checkout(IDialogContext context, LuisResult result)
        {

            var message = context.MakeMessage();
            string phrase = "";
            if (usersCart.NumberOfItemsInCart() > 0)
            {
                var heroCard = new HeroCard
                {
                    Title = "McFisch",
                    Subtitle = "Thanks for choosing McFisch",
                    Text = $"Thanks for you order. Your total is " + usersCart.GetCost(),
                    Images = new List<CardImage> { new CardImage("https://upload.wikimedia.org/wikipedia/commons/thumb/4/4d/Cheeseburger.jpg/1200px-Cheeseburger.jpg") },
                    Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl, "Place Order!", value: "https://www.youtube.com/watch?v=dQw4w9WgXcQ") }
                };
                var attachment = heroCard.ToAttachment();





                message.Attachments.Add(attachment);
            } else
            {
                message.Text = "You have to order something.";
            }
     
            message.Speak = phrase;


            await context.PostAsync(message);

            context.Wait(this.MessageReceived);
        }



        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;

            // calculate something for us to return
            int length = (activity.Text ?? string.Empty).Length;

            // return our reply to the user
            await context.PostAsync($"You sent {activity.Text} which was {length} characters");

            context.Wait(MessageReceivedAsync);
        }
    }
}