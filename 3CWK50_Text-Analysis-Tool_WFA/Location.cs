using System;
using System.Collections.Generic;
using System.Text;

namespace _3CWK50_Text_Analysis_Tool_WFA
{
    class Location
    {
        public Location(int lineNo, int pos)
        {
            this.LineNo = lineNo;
            this.Pos = pos;
        }

        public int LineNo { get; set; }
        public int Pos { get; set; }
    }
}
