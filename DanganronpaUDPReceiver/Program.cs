using System;

namespace DanganronpaUDPReceiver
{
    class Program
    {
        static void Main(string[] args)
        {
            UDPReceiver worker = new UDPReceiver();
            worker.Start();


            Console.WriteLine("Hello World!");
        }
    }
}
