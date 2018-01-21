using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Test_adresse_IP
{
    class Program
    {
        static void Main(string[] args)
        {

            string hôte = Dns.GetHostName();
            IPHostEntry iphe = Dns.Resolve(hôte);
            string ip = iphe.AddressList[0].ToString();
            Console.WriteLine("Votre Ip est : " + ip);

            Console.ReadKey();

        }
    }
}
