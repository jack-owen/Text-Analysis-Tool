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
        Form1 parent;
        public EditWord(Object item, Form1 parent)
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


        private void textBox_word_TextChanged(object sender, EventArgs e)
        {
            //** set word to input value
            //* error window when zero chars?
            string old = word.WordObj;
            word.WordObj = textBox_word.Text;
            parent.refresh_listView_words(string.Empty);
            Console.WriteLine(old + " changed to " + word.WordObj);
        }

        Location locationInEdit = null;
        private void listView_locations_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ListViewItem _ = listView_locations.SelectedItems[0];
            //Location _2 = (Location)_;

            //Console.WriteLine(_);

            //textBox_locations_edit_lineNo.Text = 
        }

        private void listView_locations_Click(object sender, EventArgs e)
        {
            ListViewItem.ListViewSubItem lineNo = listView_locations.SelectedItems[0].SubItems[1]; // line#
            ListViewItem.ListViewSubItem pos = listView_locations.SelectedItems[0].SubItems[2]; // pos#
            LinkedList<Location> locations = word.Locations;
            foreach (Location l in locations)
            {
                //Console.WriteLine(l.LineNo.ToString() + " " + lineNo.Text);
                if (l.LineNo.ToString().Equals(lineNo.Text) && l.Pos.ToString().Equals(pos.Text))
                {
                    Console.WriteLine("line number match");
                    locationInEdit = l;
                    setLocationEdit();
                }
            }
        }


        private void setLocationEdit()
        {
            textBox_locations_edit_lineNo.Text = locationInEdit.LineNo.ToString();
            textBox_locations_edit_pos.Text = locationInEdit.Pos.ToString();
        }

        private void textBox_locations_edit_lineNo_TextChanged(object sender, EventArgs e)
        {
            //* try catch to verify entry text is between 1 and eg 1000
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
                string message = "Select a Word Location first";
                string caption = "Location not selected";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                _ = MessageBox.Show(message, caption, buttons);
            }
        }

        private void textBox_locations_edit_pos_TextChanged(object sender, EventArgs e)
        {
            //* add validation methods
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
                string message = "Select a Word Location first";
                string caption = "Location not selected";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                _ = MessageBox.Show(message, caption, buttons);
            }

        }

        private void refresh_label_occurrences_value()
        {
            label_occurrences_value.Text = word.Locations.Count.ToString();
        }

        private void button_location_remove_Click(object sender, EventArgs e)
        {
            word.RemoveLocation(locationInEdit);
            refresh_label_occurrences_value();
            refresh_listView_locations();
            locationInEdit = null;
            textBox_locations_edit_lineNo.Text = string.Empty;
            textBox_locations_edit_pos.Text = string.Empty;
        }

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

        private void EditWord_FormClosing(object sender, FormClosingEventArgs e)
        {
            Console.WriteLine("form closing");
            //update_listBox_words();
        }

        private void button_location_create_Click(object sender, EventArgs e)
        {
            AddLocation editWordForm = new AddLocation(word, this);
            editWordForm.Show();
        }
    }
        
}
