using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{

    using _3CWK50_Text_Analysis_Tool_WFA;  // this allows to use Library and Book class
    using NUnit.Framework;

    [TestFixture]  // denotes the class that contains tests
    class BSTreeTest 
    {
        BSTree<Word> tree;
        Word word, word2, word3;

        [OneTimeSetUp] //executed once before any test
        public void TestFixtureSetUp()
        {
            word = new Word("Sweets");
            word2 = new Word("Chocolate");
            word3 = new Word("Lolly");


        }

        [SetUp]  //executed just before each test
        public void SetUp() // review
        {
            tree = new AVLTree<Word>();
            tree.InsertItem(word);
            tree.InsertItem(word2);
            tree.InsertItem(word3);
            
        }


        [Test]
        public void TestInsertItem() 
        {
            string s = null;
            tree.PreOrder(ref s);

            string answer = "sweets, chocolate, lolly, ";

            Assert.AreEqual(answer, s, "Tree insert item result incorrect");
        }

        [Test]
        public void TestHeight()
        {
            Assert.AreEqual(3, tree.Height(), "Tree height wrong");
        }

        [Test]
        public void TestCount()
        {
            Assert.AreEqual(3, tree.Count(), "Tree count quantity wrong");
        }

        [Test]
        public void TestContains()
        {
            Assert.AreEqual(true, tree.Contains(word), "Tree doesn't contain expected word");
            Assert.AreEqual(false, tree.Contains(new Word("stranger")), "Tree contains word that wasn't inserted");
            Assert.AreEqual(false, tree.Contains(new Word("")), "Tree contains word that wasn't inserted");
        }

        [Test]
        // remove an item from tree
        public void TestRemoveItem()
        {
            tree.RemoveItem(word2);
            string s = null;
            tree.PreOrder(ref s);

            string answer = "sweets, lolly, ";

            Assert.AreEqual(answer, s, "Tree remove item result incorrect");
        }

        [Test]
        // attempt to remove an item that is not in tree
        public void TestRemoveItemException()
        {
            Assert.Throws<Exception>(() =>
            {
                tree.RemoveItem(new Word("candy"));
            });
        }

        [Test]
        // test correct Word object is returned by tree find function
        public void TestFind()
        {
            // Word inserted into tree
            Assert.AreEqual(word2, tree.Find(new Word("Chocolate")).Data, "Returned incorrect node object");

            // Word not inserted into tree
            Assert.AreEqual(null, tree.Find(new Word("")), "Returned incorrect node object");

        }

        [Test]
        // check correct sequence of all tree Word objects are returned
        public void TestGetAllNodes()
        {
            Word[] array = new Word[3] { word3, word2, word };
            Assert.AreEqual(array, tree.GetAllNodes(), "Incorrect sequence of Word objects returned");
        }

        [Test]
        // Check the correct  list of Word objects is returned in ascending Alphabetical order
        public void TestConcodrance()
        {
            Word[] array = new Word[3] { word2, word3, word };
            Assert.AreEqual(array, tree.Concordance(), "Incorrect concordance returned");
        }

    }
}
