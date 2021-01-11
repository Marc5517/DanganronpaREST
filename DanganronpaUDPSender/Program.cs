using System;

namespace DanganronpaUDPSender
{
    class Program
    {
        static void Main(string[] args)
        {
            UDPSender worker = new UDPSender();
            worker.Start();


            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}
