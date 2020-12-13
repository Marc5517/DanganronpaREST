using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DanganronpaREST.Controllers;
using DanganronpaREST.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDanganronpaCharacters
{
    [TestClass]
    public class UnitTest1
    {
        private CharactersController cntr = null;

        [TestInitialize]
        public void BeforeEachTest()
        {
            cntr = new CharactersController();
        }


        [TestMethod]
        public void TestMethod1()
        {
            List<Character> cListe = new List<Character>(cntr.GetAllCharacters());

            Assert.AreEqual(6, cListe.Count);
        }


    }
}
