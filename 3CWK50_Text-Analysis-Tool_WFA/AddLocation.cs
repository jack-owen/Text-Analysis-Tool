using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3CWK50_Text_Analysis_Tool_WFA
{
    public partial class AddLocation : Form
    {
        Word word;
        EditWord parent;

        /// <summary>
        /// Initialise Word and EditWord objects.
        /// </summary>
        /// <param name="w"></param>
        /// <param name="parent"></param>
        public AddLocation(object w, EditWord parent)
        {
            this.word = (Word)w;
            this.parent = parent;
            InitializeComponent();
        }

        /// <summary>
        /// Adds new Location object to the Word Locations LinkedList by reading the line number and position values entered in the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_add_Click(object sender, EventArgs e)
        {
            word.AddLocation(Int32.Parse(textBox_locations_add_lineNo.Text), Int32.Parse(textBox_locations_add_pos.Text));
            Close();
            parent.refresh_listView_locations();
            parent.refresh_label_occurrences_value();
        }

    }
}
