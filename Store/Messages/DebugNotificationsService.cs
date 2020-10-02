using System.Diagnostics;

namespace Store.Messages
{
    public class DebugNotificationsService : INotificationService
    {
        public void SendConfirmation(string cellPhone, int code)
        {
            Debug.WriteLine($"CellPhone: {0}, code: {1}", cellPhone, code);
        }
    }
}
