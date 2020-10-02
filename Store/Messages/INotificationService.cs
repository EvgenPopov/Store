using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Messages
{
   public interface INotificationService
    {
        void SendConfirmation(string cellPhone, int code);
    }
}
