using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    interface NetworkClient
    {
        void call(string URL);
    }
    class FreeNetWorkClient: NetworkClient
    {
        public void call(string URL)
        {
            Console.WriteLine("It is response from " + URL);
        }
    }
    class ProxyNetWorkClient: NetworkClient
    {
        private List<string> blackList = new List<string>(); 
        private NetworkClient networkClient;
        public ProxyNetWorkClient(NetworkClient _networkClient)
        {
            networkClient = _networkClient;
        }
        public void addBlackList(string URL)
        {
            blackList.Add(URL);
        }
        public void call(string URL)
        {
            if(blackList.Contains(URL))
            {
                Console.WriteLine(URL + " is in black list ");
            }   
            else
            {
                networkClient.call(URL);
            }                
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            FreeNetWorkClient freeNetWorkClient = new FreeNetWorkClient();
            Console.WriteLine("freeNetWorkClient");
            freeNetWorkClient.call("abc.com");
            ProxyNetWorkClient proxyNetWorkClient = new ProxyNetWorkClient(freeNetWorkClient);
            proxyNetWorkClient.addBlackList("abc.com");
            Console.WriteLine("proxyNetWorkClient");
            proxyNetWorkClient.call("abc.com");
            Console.ReadKey();
        }
    }
}
