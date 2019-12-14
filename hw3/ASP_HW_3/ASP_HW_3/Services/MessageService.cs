using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ASP_HW_3.Services
{
    public class MessageService
    {
        IMessageSender _sender;
        public MessageService(IMessageSender sender)
        {
            _sender = sender;
        }
        public string Send(HttpContext context)
        {
            return _sender.Send(context);
        }
    }
}
