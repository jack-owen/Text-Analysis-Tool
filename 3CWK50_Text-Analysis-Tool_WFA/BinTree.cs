using System;
using System.Collections.Generic;
using System.Text;

namespace _3CWK50_Text_Analysis_Tool_WFA
{
    class BinTree<T> where T : IComparable
    {
        protected Node<T> root;

        /// <summary>
        /// Create an empty tree
        /// </summary>
        public BinTree()  //creates an empty tree
        {
            root = null;
        }

        /// <summary>
        /// Create a tree with a root
        /// </summary>
        /// <param name="node">Generic node to by used as root</param>
        public BinTree(Node<T> node)
        {
            root = node;
        }

        /// <summary>
        /// Calls a Pre Order Traversal of the whole Tree
        /// </summary>
        /// <param name="buffer">Variable passed by reference to store the result of the traversal</param>
        public void PreOrder(ref string buffer)
        {
            preOrder(root, ref buffer);
        }

        /// <summary>
        /// Creates a Pre Order Traversal of the whole Tree
        /// </summary>
        /// <param name="tree">Root node of the Tree to start the Traversal</param>
        /// <param name="buffer">Variable passed by reference to store the result of the traversal</param>
        private void preOrder(Node<T> tree, ref string buffer)
        {
            if (tree != null)
            {
                buffer += tree.Data.ToString() + ", ";
                preOrder(tree.Left, ref buffer);
                preOrder(tree.Right, ref buffer);
            }
        }

        /// <summary>
        /// Copies the parsed BinaryTree to this Tree
        /// </summary>
        /// <param name="tree2">The Tree to Copy to this Tree</param>
        public void Copy(BinTree<T> tree2)
        {
            copy(ref root, tree2.root);
        }

        /// <summary>
        /// Copies the parsed BinaryTree to the target Tree
        /// </summary>
        /// <param name="tree">The target Tree to copy</param>
        /// <param name="tree2">The source Tree to copy</param>
        private void copy(ref Node<T> tree, Node<T> tree2)
        {
            tree = tree2;
        }

        /// <summary>
        /// Returns the total number of items in the Tree
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            int c = 0;
            count(root, ref c);
            return c;
        }

        /// <summary>
        /// Counts the total number of items in the Tree by traversing each branch
        /// </summary>
        /// <param name="tree">Root node to search</param>
        /// <param name="c">Item counter passed by reference</param>
        private void count(Node<T> tree, ref int c)
        {
            if (tree != null)
            {
                c += 1;
                count(tree.Left, ref c);
                count(tree.Right, ref c);
            }
        }


    }

}
