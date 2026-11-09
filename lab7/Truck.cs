using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7
{
    internal class Truck : IUnload, INotify, IDrive
    {
        public event Action<string> MessageGenerated;

        public string PrepareUnloading()
        {
            return "Вантажівка: відкриваю кузов, готуюсь до розвантаження.";
        }

        public string SendNotification()
        {
            return "Вантажівка: смс клієнту відправлено успішно.";
        }

        public string Drive()
        {
            return "Машина в дорозі.";
        }

        public void Truck_ArrivedEvent()
        {
            MessageGenerated?.Invoke("Вантажівка: я на місці!");

            MessageGenerated?.Invoke(SendNotification());
            MessageGenerated?.Invoke(PrepareUnloading());
        }
    }
}
