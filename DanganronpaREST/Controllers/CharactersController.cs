using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DanganronpaREST.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DanganronpaREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private static readonly List<Character> Characters = new List<Character>()
        {
            new Character(101, "Makoto", "Naegi", "Lucky Student", 78),
            new Character(109, "Kyoko", "Kirigiri", "Detective", 78),
            new Character(201, "Hajime", "Hinata", "???", 77),
            new Character(216, "Chiaki", "Nanami", "Gamer", 77),
            new Character(301, "Shuichi", "Saihara", "Detective", 79),
            new Character(309, "Kaede", "Akamatsu", "Pianist", 79)
        };


        // GET: api/<CharactersController>
        [HttpGet]
        public IEnumerable<Character> GetAllCharacters()
        {
            return Characters;
        }

        // GET api/<CharactersController>/5
        [HttpGet]
        [Route("{studentId}")]
        public Character GetByStudnetID(int studentId)
        {
            return Characters.Find(c => c.StudentId == studentId);
        }

        [HttpGet]
        [Route("Talent/{talent}")]
        public IEnumerable<Character> GetCharacterByTalent(string talent)
        {
            List<Character> lCharacter = Characters.FindAll(c => c.Talent.Contains(talent));
            return lCharacter;
        }

        // POST api/<CharactersController>
        [HttpPost]
        public int AddCharacter([FromBody] Character character)
        {
            Characters.Add(character);
            int newId = Characters.Max(c => c.StudentId) + 1;
            character.StudentId = newId;
            return newId;
        }

        // PUT api/<CharactersController>/5
        [HttpPut]
        [Route("{id}")]
        public void Put(int id, [FromBody] Character value)
        {
            Character c = GetByStudnetID(id);
            if (c == null)
                return;

            c.FirstName = value.FirstName;
            c.LastName = value.LastName;
            c.Talent = value.Talent;
            c.ClassNo = value.ClassNo;
        }

        // DELETE api/<CharactersController>/5
        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
            Character c = GetByStudnetID(id);
            if (c == null)
                return;

            Characters.Remove(c);
        }
    }
}
