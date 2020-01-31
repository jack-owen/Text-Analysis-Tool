using System;
using System.Collections.Generic;
using System.Text;

namespace _3CWK50_Text_Analysis_Tool_WFA
{
    class BinTree<T> where T : IComparable
    {
        protected Node<T> root;
        public BinTree()  //creates an empty tree
        {
            root = null;
        }
        public BinTree(Node<T> node)  //creates a tree with node as the root
        {
            root = node;
        }


        // Pre Order traversal
        public void PreOrder(ref string buffer)
        {
            preOrder(root, ref buffer);
        }

        private void preOrder(Node<T> tree, ref string buffer)
        {
            if (tree != null)
            {
                buffer += tree.Data.ToString() + ", ";
                preOrder(tree.Left, ref buffer);
                preOrder(tree.Right, ref buffer);
            }
        }

        // In Order traversal
        public void InOrder(ref string buffer)
        {
            inOrder(root, ref buffer);
        }
        private void inOrder(Node<T> tree, ref string buffer)
        {
            if (tree != null)
            {
                inOrder(tree.Left, ref buffer);
                buffer += tree.Data.ToString() + ", ";
                inOrder(tree.Right, ref buffer);
            }
        }

        // Post Order traversal       
        public void PostOrder(ref string buffer)
        {
            postOrder(root, ref buffer);
        }

        private void postOrder(Node<T> tree, ref string buffer)
        {
            if (tree != null)
            {
                postOrder(tree.Left, ref buffer);
                postOrder(tree.Right, ref buffer);
                buffer += tree.Data.ToString() + ", ";
            }
        }

        public void Copy(BinTree<T> tree2)
        {
            copy(ref root, tree2.root);
        }
        private void copy(ref Node<T> tree, Node<T> tree2)
        {
            tree = tree2;
        }

        public int Count()
        {
            int c = 0;
            count(root, ref c);
            return c;
        }

        private void count(Node<T> tree, ref int c)
        {
            if (tree != null)
            {
                c += 1;
                count(tree.Left, ref c);
                count(tree.Right, ref c);
            }
        }

        public Node<T> getRoot() // tmp
        {
            return root;
        }

        

    }

}
