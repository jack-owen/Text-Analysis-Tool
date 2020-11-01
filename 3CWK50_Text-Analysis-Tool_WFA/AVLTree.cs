using System;
using System.Collections.Generic;
using System.Text;

namespace _3CWK50_Text_Analysis_Tool_WFA
{
    class AVLTree<T> : BSTree<T> where T : IComparable
    {
        /// <summary>
        /// Add item to Tree
        /// </summary>
        /// <param name="item">Generic object to add to tree</param>
        public new void InsertItem(T item)
        {
            insertItem(item, ref root);
        }

        /// <summary>
        /// Add item to Tree 
        /// </summary>
        /// <param name="item">Generic object to add to tree</param>
        /// <param name="tree">Generic root node</param>
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

        /// <summary>
        /// Rotation technique used to re balance the tree when balance factor is <= -2
        /// </summary>
        /// <param name="tree">Generic root node</param>
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

        /// <summary>
        /// Rotation technique used to re balance the tree when balance factor is >= 2
        /// </summary>
        /// <param name="tree">Generic root node</param>
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

        /// <summary>
        /// Remove item from Tree
        /// </summary>
        /// <param name="item">Generic object to remove from tree</param>
        public new void RemoveItem(T item)
        {
            removeItem(item, ref root);
        }

        /// <summary>
        /// Search for item in tree recursively and checks balance factor of tree after item is removed.
        /// </summary>
        /// <param name="item">Generic object to remove from tree</param>
        /// <param name="tree">Generic root node</param>
        private void removeItem(T item, ref Node<T> tree)
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
                if (item.Equals(tree.Data))
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
            else
            {
                throw new Exception("Item doesn't exist in tree");
            }


        }

    }


}
