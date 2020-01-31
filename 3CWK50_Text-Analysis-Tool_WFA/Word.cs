using System;
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

        public int CompareTo(Object other)
        {
            Word w = (Word) other;
            return WordObj.CompareTo(w.WordObj);
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


    }
}
