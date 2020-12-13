using DanganronpaREST.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsumeDanganronpa
{
    internal class DanganronpaWorker
    {
        private const string URI = "https://danganronpaservice.azurewebsites.net/api/Characters";

        public DanganronpaWorker()
        {

        }

        public async void Start()
        {
            PrintHeader("Get all Characters");
            IList<Character> allCharacters = await GetAllCharactersAsync();
            foreach (Character character in allCharacters)
            {
                Console.WriteLine(character);
            }


            PrintHeader("Gets character with StudentId 101");
            try
            {
                Character character1 = await GetOneCharactersAsync(101);
                Console.WriteLine("character= " + character1);
            }
            catch (KeyNotFoundException knfe)
            {
                Console.WriteLine(knfe.Message);
            }

            PrintHeader("Gets character with StudentId 201");
            try
            {
                Character character1 = await GetOneCharactersAsync(201);
                Console.WriteLine("character= " + character1);
            }
            catch (KeyNotFoundException knfe)
            {
                Console.WriteLine(knfe.Message);
            }


            //PrintHeader("Create a Character");
            //Character newCharacter = new Character(116, "Junko", "Enoshima", "Despair", 78);
            //await CreateNewCharacter(newCharacter);

            //// udskriver alle Items
            //allItems = await GetAllItemsAsync();
            //foreach (Item item in allItems)
            //{
            //    Console.WriteLine(item);
            //}


            //PrintHeader("Ændre Item id nummer 7");
            //nyItem.Quality = "Really High";
            //await OpdatereItem(nyItem);

            //// udskriver alle Items
            //allItems = await GetAllItemsAsync();
            //foreach (Item item in allItems)
            //{
            //    Console.WriteLine(item);
            //}


            //PrintHeader("Sletter nr 7");
            //await SletItem(7);

            //// udskriver alle Items
            //allItems = await GetAllItemsAsync();
            //foreach (Item item in allItems)
            //{
            //    Console.WriteLine(item);
            //}

            //Console.ReadLine();
        }

        private void PrintHeader(string txt)
        {
            Console.WriteLine("=========================");
            Console.WriteLine(txt);
            Console.WriteLine("=========================");

        }


        public async Task<IList<Character>> GetAllCharactersAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync(URI);
                IList<Character> cList = JsonConvert.DeserializeObject<IList<Character>>(content);
                return cList;
            }
        }

        public async Task<Character> GetOneCharactersAsync(int studentId)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage resp = await client.GetAsync(URI + studentId);

                if (resp.IsSuccessStatusCode)
                {
                    string json = await resp.Content.ReadAsStringAsync();
                    Character character = JsonConvert.DeserializeObject<Character>(json);
                    return character;
                }
                // Else
                throw new KeyNotFoundException(
                    $"Fejl code={resp.StatusCode} message={await resp.Content.ReadAsStringAsync()}");
            }

        }

        //public async Task CreateNewCharacter(Character character)
        //{
        //    using (HttpClient client = new HttpClient())
        //    {
        //        StringContent content = new StringContent(
        //            JsonConvert.SerializeObject(character),
        //            Encoding.UTF8,
        //            "application/json");

        //        HttpResponseMessage resp = await client.PostAsync(URI, content);
        //        if (resp.IsSuccessStatusCode)
        //        {
        //            return;
        //        }
        //        // Else
        //        throw new ArgumentException("Opret fejlede");
        //    }
        //}
    }
}
