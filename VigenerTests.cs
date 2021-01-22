using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TestTaskCRT;


namespace TestAppCRTFuncTests
{
    [TestClass]
    public class VigenerTests
    {
        [TestMethod]
        public void Source_WithKey_GetsEncrypted()
        {
            string source = "ATTACKATDAWN";
            string key = "LEMON";
            string expected = "LXFOPVEFRNHR";
            Vigener vigener = new Vigener();

            string actual = vigener.Encrypt(source, key);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void Encrypted_WithKey_GetsDecrypted()
        {
            string encrypted = "LXFOPVEFRNHR";
            string key = "LEMON";
            string expected = "ATTACKATDAWN";
            Vigener vigener = new Vigener();

            string actual = vigener.Decrypt(encrypted, key);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void SourceEnumerable_WithKey_GetsEncrypted()
        {
            var sources = new string[] { "BANANA", "APPLE", "GUITAR", "AGAIN" };
            string key = "LEMON";
            var expected = new string[] { "MEZOAL", "LTBZR", "RYUHNC", "LKMWA" };
            Vigener vigener = new Vigener();

            var actual = vigener.Encrypt(sources, key);
            CollectionAssert.AreEqual(expected, actual.ToList());
        }


        [TestMethod]
        public void EncryptedEnumerable_WithKey_GetsDecrypted()
        {
            var encrypted = new string[] { "MEZOAL", "LTBZR", "RYUHNC", "LKMWA" };
            string key = "LEMON";
            var expected = new string[] { "BANANA", "APPLE", "GUITAR", "AGAIN" };
            Vigener vigener = new Vigener();

            var actual = vigener.Decrypt(encrypted, key);
            CollectionAssert.AreEqual(expected, actual.ToList());
        }
    }
}
