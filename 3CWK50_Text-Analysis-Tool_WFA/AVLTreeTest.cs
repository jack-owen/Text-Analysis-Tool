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
    class AVLTreeTest 
    {
        AVLTree<Word> tree;
        Word word, word2, word3;

        [OneTimeSetUp] //executed once before any test
        public void TestFixtureSetUp()
        {
            word = new Word("sweets");
            word2 = new Word("chocolate");
            word3 = new Word("lolly");


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
        // check order of items in tree to ensure each item was added to the tree correctly
        // by accurately calculating the balance factor and rotate the tree if <= 2 and >= 2
        public void TestInsertItemAndBalanceFactorRotations() 
        {
            string s = null;
            tree.PreOrder(ref s);

            string answer = "lolly, chocolate, sweets, ";

            Assert.AreEqual(answer, s, "Tree insert item result incorrect");
        }

        [Test]
        // remove an item from tree
        public void TestRemoveItem()
        {
            tree.RemoveItem(word2);
            string s = null;
            tree.PreOrder(ref s);

            string answer = word3 + ", " + word + ", ";
            
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
    }
}
