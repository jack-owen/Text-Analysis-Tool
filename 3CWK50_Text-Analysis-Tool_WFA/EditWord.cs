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
    public partial class EditWord : Form
    {
        Word word;
        Main parent;
        Location locationInEdit = null;

        public EditWord(Object item, Main parent)
        {
            this.word = (Word)item;
            this.parent = parent;
            InitializeComponent();
            textBox_word.Text = word.WordObj;
            listView_locations.FullRowSelect = true;
            listView_locations.GridLines = true;
            listView_locations.Sorting = SortOrder.Ascending;
            listView_locations.Columns.Add("location object", 0, HorizontalAlignment.Left);
            listView_locations.Columns.Add("Line #", -2, HorizontalAlignment.Left);
            listView_locations.Columns.Add("Pos #", -2, HorizontalAlignment.Left);
            refresh_listView_locations();
            refresh_label_occurrences_value();
        }

        /* 2. Manually edit (and save in the data structure) the information of a unique word */
        /// <summary>
        /// Update Word object word string value in the data structure and refresh the listview component 
        /// in the Main form with the updated Word object value.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_word_TextChanged(object sender, EventArgs e)
        {
            //** set word to input value
            //* error window when zero chars?
            word.WordObj = textBox_word.Text;
            parent.refresh_listView_words(string.Empty);
        }

        /// <summary>
        /// Select the user selected Word Location object for editing by updating the locationInEdit reference and line/pos edit fields.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView_locations_Click(object sender, EventArgs e)
        {
            ListViewItem.ListViewSubItem lineNo = listView_locations.SelectedItems[0].SubItems[1]; // line#
            ListViewItem.ListViewSubItem pos = listView_locations.SelectedItems[0].SubItems[2]; // pos#
            LinkedList<Location> locations = word.Locations;
            foreach (Location l in locations)
            {
                if (l.LineNo.ToString().Equals(lineNo.Text) && l.Pos.ToString().Equals(pos.Text))
                {
                    locationInEdit = l;
                    textBox_locations_edit_lineNo.Text = locationInEdit.LineNo.ToString();
                    textBox_locations_edit_pos.Text = locationInEdit.Pos.ToString();
                }
            }
        }
        
        /// <summary>
        /// Updates Location object lineNo value when lineNo field is changed in EditWord form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_locations_edit_lineNo_TextChanged(object sender, EventArgs e)
        {
            if (locationInEdit != null)
            {
                try
                {
                    locationInEdit.LineNo = Int32.Parse(textBox_locations_edit_lineNo.Text);
                }
                catch (FormatException)
                {
                    Console.WriteLine("wrong input exception"); // throw new exception
                    string message = textBox_locations_edit_lineNo.Text + " is not a valid line number";
                    string caption = "Wrong input format";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    _ = MessageBox.Show(message, caption, buttons);
                }
                catch (NullReferenceException)
                {
                    throw new NullReferenceException("NullReferenceException for position in line");// Console.WriteLine("wrong input exception"); // throw new exception
                }
                refresh_listView_locations();
            }
            else
            {
                if (textBox_locations_edit_lineNo.Text == string.Empty) return; // this can be when a Location is Removed

                string message = "Select a Word Location first";
                string caption = "Location not selected";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                _ = MessageBox.Show(message, caption, buttons);
            }
        }

        /// <summary>
        /// Updates Location object pos value when pos field is changed in EditWord form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_locations_edit_pos_TextChanged(object sender, EventArgs e)
        {
            if (locationInEdit != null)
            {
                try
                {
                    locationInEdit.Pos = Int32.Parse(textBox_locations_edit_pos.Text);
                }
                catch (FormatException)
                {
                    Console.WriteLine("wrong input exception"); // throw new exception
                    string message = textBox_locations_edit_pos.Text + " is not a valid position";
                    string caption = "Wrong input format";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    _ = MessageBox.Show(message, caption, buttons);
                }
                catch (NullReferenceException)
                {
                    throw new NullReferenceException("NullReferenceException for position in line");// Console.WriteLine("wrong input exception"); // throw new exception
                }
                refresh_listView_locations();
            }
            else
            {
                if (textBox_locations_edit_pos.Text == string.Empty) return; // this can be when a Location is Removed

                string message = "Select a Word Location first";
                string caption = "Location not selected";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                _ = MessageBox.Show(message, caption, buttons);
            }

        }

        /// <summary>
        /// Simply set the occurence label value to the Word object location quantity
        /// </summary>
        public void refresh_label_occurrences_value()
        {
            label_occurrences_value.Text = word.Locations.Count.ToString();
        }

        /// <summary>
        /// Removes Location object from Word object and refreshes label occurence and listview location values.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_location_remove_Click(object sender, EventArgs e)
        {
            word.RemoveLocation(locationInEdit);
            refresh_label_occurrences_value();
            refresh_listView_locations();
            locationInEdit = null;
            textBox_locations_edit_lineNo.Text = string.Empty;
            textBox_locations_edit_pos.Text = string.Empty;
        }

        /// <summary>
        /// Fetches Word Location objects and overwrites existing listView_locations values.
        /// </summary>
        public void refresh_listView_locations()
        {
            ListViewItem[] list = new ListViewItem[word.Locations.Count];
            int i = 0;
            listView_locations.Items.Clear();
            foreach (Location location in word.Locations)
            {
                list[i] = new ListViewItem(i.ToString());
                list[i].SubItems.Add(location.LineNo.ToString());
                list[i].SubItems.Add(location.Pos.ToString());
                i++;
            }
            listView_locations.Items.AddRange(list);
        }

        /// <summary>
        /// Creates a new form to add another location to the Word object
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_location_create_Click(object sender, EventArgs e)
        {
            AddLocation editWordForm = new AddLocation(word, this);
            editWordForm.Show();
        }
    }
        
}
