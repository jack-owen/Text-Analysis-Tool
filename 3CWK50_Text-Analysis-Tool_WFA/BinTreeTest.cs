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
    class BinTreeTest 
    {
        Node<Word> root;
        BinTree<Word> tree, tree2;
        Word word, word2, word3;

        [OneTimeSetUp]
        public void TestFixtureSetUp()
        {
            word = new Word("Sweets");
            word2 = new Word("Chocolate");
            word3 = new Word("Lolly");


        }

        /// <summary>
        /// Constructors a Tree with 3 nodes and one empty Tree
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            root = new Node<Word>(word);
            tree = new BinTree<Word>(root);
            root.Left = new Node<Word>(word2);
            root.Left.Right = new Node<Word>(word3);

            tree2 = new BinTree<Word>();

        }

        /// <summary>
        /// Test to check Word object creation is correct for each node in Tree
        /// </summary>
        [Test]
        public void TestWordNamesAndLinks() 
        {
            Assert.AreEqual(word.WordObj, root.Data.WordObj, "Wrong word");
            Assert.AreEqual(word2.WordObj, root.Left.Data.WordObj, "Wrong word");
            Assert.AreEqual(word3.WordObj, root.Left.Right.Data.WordObj, "Wrong word");
        }

        /// <summary>
        /// Test to check Pre Order Traversal algorithm is result is correct
        /// </summary>
        [Test]
        public void TestPreOrderTraversal()
        {
            string s = null;
            tree.PreOrder(ref s);

            string answer = word + ", " + word2 + ", " + word3 + ", ";

            Assert.AreEqual(answer, s, "Pre Order Traversal incorrect");
        }

        /// <summary>
        /// Test copy whole Tree function result accuracy
        /// </summary>
        [Test]
        public void TestCopy()
        {
            tree2.Copy(tree);
            string s = null;
            tree.PreOrder(ref s);
            string d = null;
            tree2.PreOrder(ref d);

            Assert.AreEqual(s, d, "Copy unsuccessful");
        }

        /// <summary>
        /// Test the Tree count function result accuracy
        /// </summary>
        [Test]
        public void TestCount()
        {
            Assert.AreEqual(3, tree.Count(), "Count incorrect");
            Assert.AreEqual(0, tree2.Count(), "Count incorrect");
        }
    }
}
