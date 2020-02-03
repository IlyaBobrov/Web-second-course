using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_HW_3.Services
{
    public class EmailMessageSender : IMessageSender
    {
        public string Send(HttpContext context)
        {
            if (context.Session.Keys.Contains("name"))
                return($"you {context.Session.GetString("name")}!");
            else
            {
                context.Session.SetString("name", "Ilya");
                return("text empty(email)");
            }
        }
    }
}
