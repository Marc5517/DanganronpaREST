using DanganronpaREST.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace DanganronpaUDPSender
{
    internal class UDPSender
    {
        public UDPSender()
        {

        }

        public void Start()
        {
            UdpClient client = new UdpClient(); // modtage pakker på 7007 port nummer

            byte[] buffer;

            Character character = new Character(206, "Nagito", "Komaeda", "Lucky Student", 77);

            // Sender
            IPEndPoint modtagerEP = new IPEndPoint(IPAddress.Loopback, 7007);
            String str = character.ToString();
            byte[] outbuffer = Encoding.UTF8.GetBytes(str.ToCharArray());
            client.Send(outbuffer, outbuffer.Length, modtagerEP);



            // Modtager
            IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 0);
            buffer = client.Receive(ref remoteEP);

            Console.WriteLine($"har modtaget en pakke kommer fra IP {remoteEP.Address} og port {remoteEP.Port}");
            string incommingstr = Encoding.UTF8.GetString(buffer);

            Console.WriteLine("tekst modtaget = " + incommingstr);
        }
    }
}
