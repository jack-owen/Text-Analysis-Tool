using System;
using System.Collections.Generic;
using System.Text;

namespace _3CWK50_Text_Analysis_Tool_WFA
{
    class Word : IComparable
    {
        /// <summary>
        /// Constructor used strictly by the Form search methods to create Word with only a name
        /// </summary>
        /// <param name="w"></param>
        public Word(String w)
        {
            this.WordObj = w;
        }

        /// <summary>
        /// Constructor used strictly by the Form search methods to create a Word with a name, a line position and position in line
        /// </summary>
        /// <param name="w">Word string of the object</param>
        /// <param name="lineNo">Line number of Word in file</param>
        /// <param name="pos">Position in line in word file</param>
        public Word(String w, int lineNo, int pos)
        {
            this.WordObj = w;
            AddLocation(lineNo, pos);
        }

        public int Occurrences { get; set; }
        public string WordObj { get; set; }
        internal LinkedList<Location> Locations { get; set; } = new LinkedList<Location>();

        /// <summary>
        /// Adds a new location occurance to existing Word object
        /// </summary>
        /// <param name="lineNo">Line number of Word in file to add</param>
        /// <param name="pos">Position in line in word file to add</param>
        public void AddLocation(int lineNo, int pos)
        {
            Occurrences++;
            Locations.AddLast(new Location(lineNo, pos));
        }

        /// <summary>
        /// Removes an existing location object reference from Word object
        /// </summary>
        /// <param name="l">The location object to remove (selected by user in GUI)</param>
        public void RemoveLocation(Location l) 
        {
            Occurrences--;
            Locations.Remove(l);
        }

        /// <summary>
        /// Removes an existing location object of a Word by searching for the line number and position in line
        /// </summary>
        /// <param name="lineNo">Line number to search for</param>
        /// <param name="pos">Position in line to search for</param>
        public void RemoveLocation(int lineNo, int pos)
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

        /// <summary>
        /// Overrides compare to method to use the word name as the compare value
        /// </summary>
        /// <param name="other">The second Word object to compare to</param>
        /// <returns>The comparison value result</returns>
        public int CompareTo(Object other)
        {
            Word w = (Word) other;
            return WordObj.CompareTo(w.WordObj);
        }

        /// <summary>
        /// Returns Word object word string
        /// </summary>
        /// <returns>Word object word string</returns>
        public override string ToString()
        {
            return WordObj.ToString().ToLower(); // uses word in lowercase for comparison consistency
        }

        /// <summary>
        /// Checks whether two Word object words are equivalent e.g. loo = loo, chair != stool
        /// </summary>
        /// <param name="other">The word to compare to</param>
        /// <returns>True if the words are equivalent</returns>
        public override bool Equals(Object other)
        {
            Word w = (Word)other;
            return WordObj.Equals(w.WordObj);
        }

        /// <summary>
        /// Returns numeric value to identify object in collection
        /// </summary>
        /// <returns>numeric value to identify object</returns>
        public override int GetHashCode()
        {
            return WordObj.GetHashCode();
        }

    }
}
