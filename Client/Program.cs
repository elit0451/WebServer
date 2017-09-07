using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient listener = new TcpClient("webservicedemo.datamatiker-skolen.dk", 80);

            NetworkStream ns = listener.GetStream();
            StreamWriter sw = new StreamWriter(ns);
            StreamReader sr = new StreamReader(ns);


            sw.WriteLine("GET /RegneWcfService.svc/RESTjson/Add?a=" + int.Parse(Console.ReadLine()) + "&b=" + int.Parse(Console.ReadLine()) + " HTTP/1.1");
            sw.WriteLine("Host: webservicedemo.datamatiker-skolen.dk");
            sw.WriteLine();
            sw.Flush();

            string response = "";
            

            while(sr.Peek() > -1)
            {
                response += (char) sr.Read();

            }
            Console.WriteLine(response);

            listener.Close();

            Console.ReadKey();

        }
    }
}
