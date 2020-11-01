using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{

    using _3CWK50_Text_Analysis_Tool_WFA;  // this allows to use Library and Book class
    using NUnit.Framework;

    [TestFixture]
    class AVLTreeTest 
    {
        AVLTree<Word> tree;
        Word word, word2, word3;

        
        [OneTimeSetUp]
        public void TestFixtureSetUp()
        {
            word = new Word("sweets");
            word2 = new Word("chocolate");
            word3 = new Word("lolly");

        }

        [SetUp]
        public void SetUp()
        {
            tree = new AVLTree<Word>();
            tree.InsertItem(word);
            tree.InsertItem(word2);
            tree.InsertItem(word3);
        }

        /// <summary>
        /// check order of items in tree to ensure each item was added to the tree correctly 
        /// by accurately calculating the balance factor and rotate the tree if <= 2 and >= 2
        /// </summary>
        [Test]
        public void TestInsertItemAndBalanceFactorRotations() 
        {
            string s = null;
            tree.PreOrder(ref s);

            string answer = "lolly, chocolate, sweets, ";

            Assert.AreEqual(answer, s, "Tree insert item result incorrect");
        }

        /// <summary>
        /// Test remove item from Tree
        /// </summary>
        [Test]
        public void TestRemoveItem()
        {
            tree.RemoveItem(word2);
            string s = null;
            tree.PreOrder(ref s);

            string answer = word3 + ", " + word + ", ";
            
            Assert.AreEqual(answer, s, "Tree remove item result incorrect");
        }

        /// <summary>
        /// Test that removing an item from tree that doesn't exist throws an exception
        /// </summary>
        [Test]
        public void TestRemoveItemException()
        {
            Assert.Throws<Exception>(() =>
            {
                tree.RemoveItem(new Word("candy"));
            });
        }
    }
}
