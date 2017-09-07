using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WebClientDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            
            WebClient client = new WebClient();
            client.Headers.Add("Content-Type", "text/plain; charset=UTF-8");
            client.Encoding = Encoding.UTF8;

            string response = client.DownloadString("http://webservicedemo.datamatiker-skolen.dk/RegneWcfService.svc/RESTjson/Add?a=" + int.Parse(Console.ReadLine()) + "&b=" + int.Parse(Console.ReadLine()));
            Console.WriteLine("The result is " + response);

            Console.ReadLine();


            
        }
    }
}
