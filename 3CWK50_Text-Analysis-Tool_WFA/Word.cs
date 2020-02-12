﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _3CWK50_Text_Analysis_Tool_WFA
{
    class Word : IComparable
    {
        // Constructor used strictly by the Form search methods
        public Word(String w)
        {
            this.WordObj = w;
        }
        public Word(String w, int lineNo, int pos)
        {
            this.WordObj = w;

            AddLocation(lineNo, pos);
        }

        public int Occurrences { get; set; }
        public string WordObj { get; set; }
        internal LinkedList<Location> Locations { get; set; } = new LinkedList<Location>();

        public void AddLocation(int lineNo, int pos)
        {
            Occurrences++;
            Locations.AddLast(new Location(lineNo, pos));
        }

        public void RemoveLocation(Location l) 
        {
            Occurrences--;
            Locations.Remove(l);
        }

        public void RemoveLocation(int lineNo, int pos) // remove by lineNo & pos reference
        {
            Occurrences--;
            foreach (Location l in Locations)
            {
                if (l.LineNo.Equals(lineNo) && l.Pos.Equals(pos))
                {
                    Locations.Remove(l);
                    Console.WriteLine(l + " removed");
                }
            }
        }

        public int CompareTo(Object other) //* compare with prefix of word not just EQUALS
        {
            Word w = (Word) other;
            return WordObj.CompareTo(w.WordObj);
        }

        public int CompareTo2(Object other) //* compare with prefix of word not just EQUALS
        {
            Word w = (Word)other;
            string str = w.WordObj;
            if (WordObj.StartsWith(str))
            {
                return 1;
            }
            else return -1;
        }

        public override string ToString()
        {
            return WordObj.ToString().ToLower(); // uses word in lowercase for comparison
        }

        public override bool Equals(Object other)
        {
            Word w = (Word)other;
            return WordObj.Equals(w.WordObj);
        }
        public override int GetHashCode()
        {
            return WordObj.GetHashCode();
        }

        

        //private new Node<Word> find(Word item, Node<Word> tree)
        //{
        //    if (tree == null)
        //    {
        //        return null;
        //    }
        //    if (tree.Data.WordObj.StartsWith(item.WordObj))
        //    {
        //        return tree;
        //    }
        //    else
        //    {
        //        if (item.CompareTo(tree.Data) < 0)
        //        {
        //            return find(item, tree.Left);
        //        }
        //        else
        //        {
        //            return find(item, tree.Right);
        //        }
        //    }
        //}


    }
}
