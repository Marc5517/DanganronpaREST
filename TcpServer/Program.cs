using System;

namespace TcpServer
{
    class Program
    {
        static void Main(string[] args)
        {
            DanganronpaServer dServer = new DanganronpaServer();
            dServer.Start();

            Console.WriteLine("Press return-button to close the program");
            Console.ReadLine();
        }
    }
}
