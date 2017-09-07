using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;
using System.Net;

namespace NetworkExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener listener = new TcpListener(IPAddress.Any, 1234);
            listener.Start();
            Socket client = listener.AcceptSocket();
            

            NetworkStream ns = new NetworkStream(client);
            StreamWriter sw = new StreamWriter(ns);
            StreamReader sr = new StreamReader(ns);
            sw.AutoFlush = true;
            
            while(true)
            {
                string clientMessage = sr.ReadLine();

                switch(clientMessage)
                {
                    case "GET /date HTTP/1.1":
                        sw.WriteLine("HTTP/1.1 200 OK");
                        sw.WriteLine("Content-Type: text/plain");
                        sw.WriteLine("Content-Length: " + DateTime.Now.Date.ToString().Length);
                        sw.WriteLine();
                        sw.WriteLine(DateTime.Now.Date.ToString());
                        break;
                    case "GET /time HTTP/1.1":
                        sw.WriteLine("HTTP/1.1 200 OK");
                        sw.WriteLine("Content-Type: text/plain");
                        sw.WriteLine("Content-Length: " + DateTime.Now.TimeOfDay.ToString().Length);
                        sw.WriteLine();
                        sw.WriteLine(DateTime.Now.TimeOfDay.ToString());
                        break;
                }
            }





        }
    }
}
