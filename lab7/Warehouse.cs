using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7
{
    internal class Warehouse : IUnload
    {
        public event Action<string> MessageGenerated;

        public string PrepareUnloading()
        {
            return "Склад: ворота №3 відкрито. Вантажники почали приймати товар.";
        }

        public void Warehouse_ArrivedEvent()
        {
            MessageGenerated?.Invoke("Склад отримав сигнал про прибуття машини!");

            MessageGenerated?.Invoke(PrepareUnloading());
        }
    }
}
