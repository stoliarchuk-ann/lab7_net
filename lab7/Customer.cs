using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7
{
    internal class Customer
    {
        public event Action<string>? MessageGenerated;

        public string SendNotification()
        {
            return "Клієнт: отримано сповіщення «Ваше замовлення прибуло!».";
        }

        public void Customer_ArrivedEvent()
        {
            MessageGenerated?.Invoke("Клієнт отримав сигнал від трекера!");
            MessageGenerated?.Invoke(SendNotification());
            MessageGenerated?.Invoke("Клієнт: йду забирати свій товар.");
        }
    }
}
