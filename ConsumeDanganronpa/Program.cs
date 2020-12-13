using System;

namespace ConsumeDanganronpa
{
    class Program
    {

        static void Main(string[] args)
        { 
            DanganronpaWorker dWorker = new DanganronpaWorker(); 
            dWorker.Start();

            Console.ReadLine();
        }
        
    }
}
