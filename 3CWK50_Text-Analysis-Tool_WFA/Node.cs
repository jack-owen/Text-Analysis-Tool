using System;
using System.Collections.Generic;
using System.Text;

namespace _3CWK50_Text_Analysis_Tool_WFA
{
    class Node<T> where T : IComparable
    {
        public Node<T> Left, Right;

        /// <summary>
        /// Constructor for Node object that takes a Generic item value
        /// </summary>
        /// <param name="item">Generic value of the Node being created</param>
        public Node(T item)
        {
            Data = item;
            Left = null;
            Right = null;
        }
        public T Data { set; get; }

        public int BalanceFactor { set; get; } = 0;

    }

}
