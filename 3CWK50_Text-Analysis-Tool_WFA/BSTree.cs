using System;
using System.Collections.Generic;
using System.Text;

namespace _3CWK50_Text_Analysis_Tool_WFA
{
    class BSTree<T> : BinTree<T> where T : IComparable
    {
        /// <summary>
        /// Constructor to create an empty Tree
        /// </summary>
        public BSTree()
        {
            root = null;
        }

        /// <summary>
        /// Insert new Generic item to Binary Search Tree
        /// </summary>
        /// <param name="item">The item to insert into Tree</param>
        public void InsertItem(T item)
        {
            insertItem(item, ref root);
        }

        /// <summary>
        /// Add new item into Binary Search Tree in the correct position
        /// </summary>
        /// <param name="item"></param>
        /// <param name="tree"></param>
        private void insertItem(T item, ref Node<T> tree)
        {
            if (tree == null)
            {
                tree = new Node<T>(item);
            }
            else if (item.CompareTo(tree.Data) < 0)
            {
                insertItem(item, ref tree.Left);
            }
            else if (item.CompareTo(tree.Data) > 0)
            {
                insertItem(item, ref tree.Right);
            }
        }

        /// <summary>
        /// Returns height of Binary Search Tree
        /// </summary>
        /// <returns></returns>
        public int Height()
        {
            return height(ref root);
        }

        /// <summary>
        /// Calculates the total height of a Tree recursively
        /// </summary>
        /// <param name="tree">The root node of the Tree to calculate height</param>
        /// <returns>Height of Tree</returns>
        protected int height(ref Node<T> tree)
        {
            if (tree == null) { return 0; }
            else
            {
                return Math.Max(height(ref tree.Left), height(ref tree.Right)) + 1;
            }
        }

        /// <summary>
        /// Returns total number of nodes in Tree
        /// </summary>
        /// <returns>Number of nodes in Tree</returns>
        public new int Count()
        {
            return base.Count();
        }

        /// <summary>
        /// Check whether the Tree already contains an item node
        /// </summary>
        /// <param name="item">Item to search the Tree for</param>
        /// <returns>True if Tree contains item</returns>
        public Boolean Contains(T item)
        {
            return contains(item, root);
        }

        /// <summary>
        /// Searches the Tree for an item's presence
        /// </summary>
        /// <param name="item">Item to search the Tree for</param>
        /// <param name="tree">The root node of tree/sub tree to search</param>
        /// <returns>Returns true if Tree contains item</returns>
        private Boolean contains(T item, Node<T> tree)
        {
            if (tree == null)
            {
                return false;
            }

            if (item.Equals(tree.Data))
            {
                return true;
            }
            else
            {
                if (item.CompareTo(tree.Data) < 0)
                {
                    return contains(item, tree.Left);
                }
                else
                {
                    return contains(item, tree.Right);
                }
            }
        }

        /// <summary>
        /// Removes an item from Tree
        /// </summary>
        /// <param name="item"></param>
        public void RemoveItem(T item)
        {
            removeItem(item, ref root);
        }

        /// <summary>
        /// Searches for an item in a Tree recursively by passing the tree/sub tree by reference and removes item if found and rejoins tree branches if required
        /// </summary>
        /// <param name="item">item to remove</param>
        /// <param name="tree">root of Tree/sub Tree to search for item</param>
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
                if (item.Equals(tree.Data)) {
                    if (tree.Left == null)
                    {
                        tree = tree.Right;
                    }
                    else if (tree.Right == null)
                    {
                        tree = tree.Left;
                    }
                    else
                    {
                        T newRoot = leastItem(tree.Right);
                        tree.Data = newRoot;
                        removeItem(newRoot, ref tree.Right);
                    }
                }
            }
            else
            {
                throw new Exception("Item doesn't exist in tree");
            }
        }

        /// <summary>
        /// Returns smallest item (left most item) in Tree
        /// </summary>
        /// <param name="tree">Tree node to start search</param>
        /// <returns>Left most item data in Tree</returns>
        protected T leastItem(Node<T> tree)
        {
            if (tree.Left == null)
            {
                return tree.Data;
            }
            else
            {
                return leastItem(tree.Left);
            }
        }

        /// <summary>
        /// Finds the Node object by item value
        /// </summary>
        /// <param name="item">The Generic value to search for</param>
        /// <returns>Node object</returns>
        public Node<T> Find(T item)
        {
            return find(item, root);
        }

        /// <summary>
        /// Searches Tree for a Node object that matches item value and returns it
        /// </summary>
        /// <param name="item">Generic item to search for</param>
        /// <param name="tree">Tree to search Node objects</param>
        /// <returns>Node object result</returns>
        private Node<T> find(T item, Node<T> tree)
        {
            if (tree == null)
            {
                return null;
            }
            
            if (item.Equals(tree.Data))
            {
                return tree;
            }
            else
            {
                if (item.CompareTo(tree.Data) < 0)
                {
                    return find(item, tree.Left);
                }
                else
                {
                    return find(item, tree.Right);
                }
            }
        }

        /// <summary>
        /// Get all nodes in Tree in a Post Order traversal
        /// </summary>
        /// <returns>Array of all Tree Node Data values</returns>
        public T[] GetAllNodes()
        {
            List<T> list = new List<T>();
            getAllNodes(root, ref list);
            T[] res = list.ToArray();
            return res;
        }

        /// <summary>
        /// Collates all Node object Data values into an Array recursively
        /// </summary>
        /// <param name="tree">Tree to search</param>
        /// <param name="list">List to store the Node values in</param>
        private void getAllNodes(Node<T> tree, ref List<T> list)
        {
            if (tree != null)
            {
                getAllNodes(tree.Left, ref list);
                getAllNodes(tree.Right, ref list);
                list.Add(tree.Data);
            }
        }

        /// <summary>
        /// Get List of Tree nodes in ascending Alphabetical order, using Insertion Sort for small sets and Quick Sort for larger sets to increase efficiency
        /// </summary>
        /// <returns>List of Tree node values</returns>
        public T[] Concordance()
        {
            List<T> list = new List<T>();
            getAllNodes(root, ref list);
            T[] res = list.ToArray();
            if (res.Length < 6)
            {
                InsertionSort(ref res);
            }
            else
            {
                QuickSort(ref res, 0, res.Length - 1);
            }
            return res;
        }

        /// <summary>
        /// Insertion Sort algorithm in ascending order
        /// </summary>
        /// <param name="a">Items to sort</param>
        private void InsertionSort(ref T[] a)
        {
            for (int i = 1; i < a.Length; i++)
            {
                T value = a[i];
                int j = i;

                for (; j > 0 && value.CompareTo(a[j - 1]) < 0; j--)
                {
                    a[j] = a[j - 1];
                }
                a[j] = value;
            }
        }

        /// <summary>
        /// Quick Sort algorithm in ascending order
        /// </summary>
        /// <param name="items">Items to sort</param>
        /// <param name="left">Start position of set</param>
        /// <param name="right">End position of set</param>
        private void QuickSort(ref T[] items, int left, int right)
        {
            int i, j;
            i = left; j = right;
            T pivot = items[left];

            while (i <= j)
            {
                for (; (items[i].CompareTo(pivot) < 0) && (i < right); i++) ;
                for (; (pivot.CompareTo(items[j]) < 0) && (j > left); j--) ;

                if (i <= j)
                    swap(ref items[i++], ref items[j--]);
            }

            if (left < j) QuickSort(ref items, left, j);
            if (i < right) QuickSort(ref items, i, right);
        }

        /// <summary>
        /// Swaps the the positions of two values by reference
        /// </summary>
        /// <param name="a">First variable to swap</param>
        /// <param name="b">Second variable to swap</param>
        private void swap(ref T a, ref T b)
        {
            T tmp = a;
            a = b;
            b = tmp;
        }
    }
    
}


