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
    class BinTreeTest 
    {
        Node<Word> root;
        BinTree<Word> tree, tree2;
        Word word, word2, word3;

        [OneTimeSetUp] //executed once before any test
        public void TestFixtureSetUp()
        {
            word = new Word("Sweets");
            word2 = new Word("Chocolate");
            word3 = new Word("Lolly");


        }

        //[OneTimeTearDown] //executed once after all tests
        //public void TestFixtureTearDown()
        //{

        //}

        [SetUp]  //executed just before each test
        public void SetUp() // review
        {
            // construct tree with 3 nodes
            root = new Node<Word>(word);
            tree = new BinTree<Word>(root);
            root.Left = new Node<Word>(word2);
            root.Left.Right = new Node<Word>(word3);

            // construct empty tree
            tree2 = new BinTree<Word>();

        }


        //[TearDown] // executed just after each test
        //public void TearDown()
        //{

        //}

        [Test] // denotes a test case; this test case checks that the getBook method works as expected: 
        // recovers the correct Title and Author of a Book
        public void TestWordNamesAndLinks() 
        {
            Assert.AreEqual(word.WordObj, root.Data.WordObj, "Wrong word");
            Assert.AreEqual(word2.WordObj, root.Left.Data.WordObj, "Wrong word");
            Assert.AreEqual(word3.WordObj, root.Left.Right.Data.WordObj, "Wrong word");
        }

        [Test]
        public void TestPreOrderTraversal()
        {
            string s = null;
            tree.PreOrder(ref s);

            string answer = word + ", " + word2 + ", " + word3 + ", ";

            Assert.AreEqual(answer, s, "Pre Order Traversal incorrect");
        }

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

        [Test]
        public void TestCount()
        {
            Assert.AreEqual(3, tree.Count(), "Count incorrect");
            Assert.AreEqual(0, tree2.Count(), "Count incorrect");
        }
    }
}
