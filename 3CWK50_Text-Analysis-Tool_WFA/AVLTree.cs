using System;
using System.Collections.Generic;
using System.Text;

namespace _3CWK50_Text_Analysis_Tool_WFA
{
    class AVLTree<T> : BSTree<T> where T : IComparable
    {

        public new void InsertItem(T item)
        {
            insertItem(item, ref root);
        }

        private void insertItem(T item, ref Node<T> tree)
        {
            if (tree == null)
                tree = new Node<T>(item);
            else if (item.CompareTo(tree.Data) < 0)
                insertItem(item, ref tree.Left);
            else if (item.CompareTo(tree.Data) > 0)
                insertItem(item, ref tree.Right);

            tree.BalanceFactor = height(ref tree.Left) - height(ref tree.Right);

            if (tree.BalanceFactor <= -2)
                rotateLeft(ref tree);
            if (tree.BalanceFactor >= 2)
                rotateRight(ref tree);
        }

        private void rotateLeft(ref Node<T> tree)
        {
            if (tree.Right.BalanceFactor > 0)  //double rotate
                rotateRight(ref tree.Right);

            Node<T> oldRoot = tree;
            Node<T> newRoot = tree.Right;
            oldRoot.Right = newRoot.Left;
            newRoot.Left = oldRoot;
            tree = newRoot;
        }

        private void rotateRight(ref Node<T> tree)
        {
            if (tree.Left.BalanceFactor < 0)  //double rotate
                rotateLeft(ref tree.Left);

            Node<T> oldRoot = tree;
            Node<T> newRoot = tree.Left;
            oldRoot.Left = newRoot.Right;
            newRoot.Right = oldRoot;
            tree = newRoot;
        }

        /* override BSTree RemoveItem to use Balance Factoring */
        public new void RemoveItem(T item)
        {
            removeItem(item, ref root);
        }

        private void removeItem(T item, ref Node<T> tree) //* testing required
        {
            if (tree != null)
            {
                if (item.CompareTo(tree.Data) < 0)
                {
                    removeItem(item, ref tree.Left);
                }
                if (item.CompareTo(tree.Data) > 0)
                {
                    removeItem(item, ref tree.Right);
                }
                if (item.Equals(tree.Data)) // true
                {
                    if (tree.Left == null)
                        tree = tree.Right;
                    else if (tree.Right == null)
                        tree = tree.Left;
                    else
                    {
                        T newRoot = leastItem(tree.Right); // find smallest item in right
                        tree.Data = newRoot;
                        removeItem(newRoot, ref tree.Right);
                        tree.BalanceFactor = height(ref tree.Left) - height(ref tree.Right);
                        Console.WriteLine(tree.BalanceFactor);
                        if (tree.BalanceFactor <= -2)
                            rotateLeft(ref tree);
                        if (tree.BalanceFactor >= 2)
                            rotateRight(ref tree);
                    }
                }
            }


        }

    }


}
