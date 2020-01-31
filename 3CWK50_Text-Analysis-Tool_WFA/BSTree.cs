using System;
using System.Collections.Generic;
using System.Text;

namespace _3CWK50_Text_Analysis_Tool_WFA
{
    class BSTree<T> : BinTree<T> where T : IComparable
    {  //root declared as protected in Parent Class – Binary Tree
        public BSTree()
        {
            root = null;
        }

        public void InsertItem(T item)
        {
            insertItem(item, ref root);
        }

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

        public int Height()
        {
            return height(ref root);
        }

        protected int height(ref Node<T> tree)
        {
            if (tree == null) { return 0; }
            else
            {
                return Math.Max(height(ref tree.Left), height(ref tree.Right)) + 1;
            }
        }

        public new int Count()
        {
            return base.Count();
        }

        public Boolean Contains(T item)
        {
            return contains(item, root);
        }

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

        //private Boolean contains2(T item, ref Node<T> tree)
        //{
        //    if (tree != null)
        //    {
        //        if (tree.Data.Equals(item))
        //        {
        //            return true;
        //        }
        //        contains2(item, ref tree.Left);
        //        contains2(item, ref tree.Right);
        //    }
        //    return false;
        //}

        public void RemoveItem(T item)
        {
            removeItem(item, ref root);
        }

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

        }
        private T leastItem(Node<T> tree)
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

        public Node<T> Find(T item)
        {
            return find(item, root);
        }

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

    }
    
}


