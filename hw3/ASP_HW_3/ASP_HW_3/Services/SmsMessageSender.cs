using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_HW_3.Services
{
    public class SmsMessageSender : IMessageSender
    {
        public string Send(HttpContext context)
        {
            if (context.Request.Cookies.ContainsKey("name"))
            {
                string name = context.Request.Cookies["name"];
                return($"Hello {name}!");
            }
            else
            {
                context.Response.Cookies.Append("name", "Ilya");
                return ("Text empty(sms)!");
            }
        }
    }
}
