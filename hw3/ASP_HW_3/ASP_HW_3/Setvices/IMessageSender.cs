using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_HW_3.wwwroot.Setvices
{
    interface IMessageSender
    {
        public interface IMessageSender 
        {
            string Send();
        }
        public class EmailMessageSender : IMessageSender
        {
            public string Send()
            {
                return "Sent by Email";
            }
        }
        public class SmsMessageSender : IMessageSender
        {
            public string Send()
            {
                return "Sent by Sms";
            }
        }
    }
}
