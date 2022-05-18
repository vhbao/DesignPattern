using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    interface ILightningPhone
    {
        void ConnectLightning();
        void Recharge();
    }
    interface IUsbPhone
    {
        void ConnectUsb();
        void Recharge();
    }
    class Apple: ILightningPhone
    {
        private bool isConnected = false;
        public void ConnectLightning()
        {
            isConnected = true;
            Console.WriteLine("Apple phone connected");
        }
        public void Recharge()
        {
            if(isConnected)
            {
                Console.WriteLine("Apple phone recharging");
            }
            else
            {
                Console.WriteLine("Connect the Lightning cable the first");
            }            
        }
    }
    class Android : IUsbPhone
    {
        private bool isConnected = false;
        public void ConnectUsb()
        {
            isConnected = true;
            Console.WriteLine("Android phone connected");
        }
        public void Recharge()
        {
            if (isConnected)
            {
                Console.WriteLine("Android phone recharging");
            }
            else
            {
                Console.WriteLine("Connect the Usb cable the first");
            }
        }
    }
    class LightningToUsbAdapter:IUsbPhone
    {
        private bool isConnected = false;
        private readonly ILightningPhone _lightningPhone;
        public LightningToUsbAdapter(ILightningPhone lightningPhone)
        {
            _lightningPhone = lightningPhone;
            _lightningPhone.ConnectLightning();
        }
        public void ConnectUsb()
        {
            isConnected = true;            
            Console.WriteLine("Adapter cable connected");
        }
        public void Recharge()
        {
            if (isConnected)
            {
                _lightningPhone.Recharge();
            }
            else
            {
                Console.WriteLine("Connect the Adapter cable the first");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ILightningPhone iphone = new Apple();
            LightningToUsbAdapter adapter = new LightningToUsbAdapter(iphone);
            adapter.ConnectUsb();
            adapter.Recharge();
            Console.ReadLine();
        }
    }
}
