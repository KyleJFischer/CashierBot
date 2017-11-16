using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CashierBot.Models
{
    public class Response
    {
        public string Message;
        public object item;
        public int StatusCode;
        public Response(string message, object item)
        {
            this.Message = message;
            this.item = item;
        }
        public Response()
        {

        }
    }

 
}