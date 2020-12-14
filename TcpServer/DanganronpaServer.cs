using DanganronpaREST.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TcpServer
{
    public class DanganronpaServer
    {
        private const int PORT = 4455;

        // statisk liste til data
        private readonly static List<Character> Characters = new List<Character>()
        {
            new Character(1, "Makoto", "Naegi", "Lucky Student", 78),
            new Character(2, "Kyoko", "Kirigiri", "Detective", 78),
            new Character(3, "Byakuya", "Togami", "Affluent Progeny", 78),
            new Character(4, "Toko", "Fukawa", "Writting Prodigy", 78),
            new Character(5, "Aoi", "Asahina", "Swimming Pro", 78),
            new Character(6, "Yasuhiro", "Hagakure", "Clairvoyant", 78),

        };


        public DanganronpaServer()
        {
        }

        public void Start()
        {
            TcpListener server = new TcpListener(IPAddress.Loopback, PORT);
            server.Start();

            while (true) // håndtere flere clienter
            {
                TcpClient socket = server.AcceptTcpClient();

                // håndtere samtidigt
                Task.Run(() =>
                    {
                        TcpClient tmpSocket = socket;
                        DoClient(socket);
                    }
                );

            }
        }

        private void DoClient(TcpClient socket)
        {
            using (StreamReader sr = new StreamReader(socket.GetStream()))
            using (StreamWriter sw = new StreamWriter(socket.GetStream()))
            {
                sw.AutoFlush = true;

                String cmdStr = sr.ReadLine();
                String data = sr.ReadLine();

                switch (cmdStr)
                {
                    case "HentAlle":
                        String json = JsonConvert.SerializeObject(Characters);
                        sw.WriteLine(json);
                        break;

                    //case "Hent":
                    //    int id = Int32.Parse(data);
                    //    Character character = Character.Find(c => c.Id == id);
                    //    String jsonACharacter = JsonConvert.SerializeObject(character);
                    //    sw.WriteLine(jsonACharacter);
                    //    break;

                    //case "Gem":
                    //    Character newCharacter = JsonConvert.DeserializeObject<Character>(data);
                    //    CharacterAdd(newCharacter);
                    //    break;

                    default:
                        sw.WriteLine("Ikke en tilladt kommando");
                        break;
                }


            } // med using implicit close af sr og sw

            socket?.Close();
        }
    }
}
