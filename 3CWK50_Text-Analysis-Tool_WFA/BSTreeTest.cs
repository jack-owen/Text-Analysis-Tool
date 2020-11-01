using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{

    using _3CWK50_Text_Analysis_Tool_WFA;
    using NUnit.Framework;

    [TestFixture]
    class BSTreeTest 
    {
        BSTree<Word> tree;
        Word word, word2, word3;

        [OneTimeSetUp]
        public void TestFixtureSetUp()
        {
            word = new Word("Sweets");
            word2 = new Word("Chocolate");
            word3 = new Word("Lolly");
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
        /// Test Binary Search Tree insert item operation
        /// </summary>
        [Test]
        public void TestInsertItem() 
        {
            string s = null;
            tree.PreOrder(ref s);
            string answer = "sweets, chocolate, lolly, ";
            Assert.AreEqual(answer, s, "Tree insert item result incorrect");
        }

        /// <summary>
        /// Test Tree height function accuracy
        /// </summary>
        [Test]
        public void TestHeight()
        {
            Assert.AreEqual(3, tree.Height(), "Tree height wrong");
        }

        /// <summary>
        /// Test Tree node count function accuracy
        /// </summary>
        [Test]
        public void TestCount()
        {
            Assert.AreEqual(3, tree.Count(), "Tree count quantity wrong");
        }

        /// <summary>
        /// Test Contains function accuracy with Words inserted and not inserted into Tree
        /// </summary>
        [Test]
        public void TestContains()
        {
            Assert.AreEqual(true, tree.Contains(word), "Tree doesn't contain expected word");
            Assert.AreEqual(false, tree.Contains(new Word("stranger")), "Tree contains word that wasn't inserted");
            Assert.AreEqual(false, tree.Contains(new Word("")), "Tree contains word that wasn't inserted");
        }

        /// <summary>
        /// Check Remove Item from Tree is accurate
        /// </summary>
        [Test]
        public void TestRemoveItem()
        {
            tree.RemoveItem(word2);
            string s = null;
            tree.PreOrder(ref s);
            string answer = "sweets, lolly, ";

            Assert.AreEqual(answer, s, "Tree remove item result incorrect");
        }

        /// <summary>
        /// Check that an exception is thrown when an attempt is made to remove an item not in the Tree
        /// </summary>
        [Test]
        public void TestRemoveItemException()
        {
            Assert.Throws<Exception>(() =>
            {
                tree.RemoveItem(new Word("candy"));
            });
        }

        /// <summary>
        /// Test correct Word object is returned by tree find function
        /// </summary>
        [Test]
        public void TestFind()
        {
            // Word inserted into tree
            Assert.AreEqual(word2, tree.Find(new Word("Chocolate")).Data, "Returned incorrect node object");

            // Word not inserted into tree
            Assert.AreEqual(null, tree.Find(new Word("")), "Returned incorrect node object");
        }

        /// <summary>
        /// Check correct sequence of all tree Word objects are returned
        /// </summary>
        [Test]
        public void TestGetAllNodes()
        {
            Word[] array = new Word[3] { word3, word2, word };
            Assert.AreEqual(array, tree.GetAllNodes(), "Incorrect sequence of Word objects returned");
        }

        /// <summary>
        /// Check the correct  list of Word objects is returned in ascending Alphabetical order
        /// </summary>
        [Test]
        public void TestConcodrance()
        {
            Word[] array = new Word[3] { word2, word3, word };
            Assert.AreEqual(array, tree.Concordance(), "Incorrect concordance returned");
        }

    }
}
