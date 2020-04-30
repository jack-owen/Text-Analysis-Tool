using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3CWK50_Text_Analysis_Tool_WFA
{
    public partial class Main : Form
    {
        private AVLTree<Word> tree = new AVLTree<Word>();

        public Main()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load a text file and store the unique words in an AVL Tree
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_load_Click(object sender, EventArgs e)
        {
            int c = 0;
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Check result
            {
                try
                {
                    using (StreamReader sr = new StreamReader(openFileDialog1.FileName))
                    {
                        string line;
                        int i = 0; // file line counter
                        while ((line = sr.ReadLine()) != null)
                        {
                            i++;
                            string[] words = line.Split(' ');
                            for (int j = 0; j < words.Length; j++)
                            {
                                char[] charsToTrim = { ',', '.', '\'' };
                                if (tree.Contains(new Word(words[j].ToLower().Trim(charsToTrim)))) {
                                    Word word = tree.Find(new Word(words[j].ToLower().Trim(charsToTrim))).Data;
                                    word.AddLocation(i,j);
                                }
                                else
                                {
                                    tree.InsertItem(new Word(words[j].ToLower().Trim(charsToTrim), i, j)); // line and pos index start at 0 or 1
                                }
                            }
                        }
                    }
                }
                catch (Exception e2)
                {
                    Console.WriteLine("The file could not be read:");
                    Console.WriteLine(e2.Message);
                }
            }
            updateWordCounter();
            refresh_listView_words(string.Empty);
            Console.WriteLine(tree.Count()+" words added");
        }

        /// <summary>
        /// Manually edit (and save in the data structure) the information of a unique word
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_editWord_Click(object sender, EventArgs e)
        {
            if (!checkForLoadedWords())
            {
                return;
            }
            if (listView_words.SelectedItems.Count == 0) // when no word is selected
            {
                string message = "Please select a Word";
                string caption = "Selection Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                _ = MessageBox.Show(message, caption, buttons);
                return;
            }
            Word master = null;
            string wordToSearch = listView_words.SelectedItems[0].Text;
            try
            {
                master = tree.Find(new Word(wordToSearch.Trim())).Data;
            }
            catch (Exception e2)
            {
                Console.WriteLine(e2.StackTrace);
            }
            Console.WriteLine(master.WordObj);

            EditWord editWordForm = new EditWord(master, this);
            editWordForm.Show();
        }

        /// <summary>
        /// Display the number of unique words present in the text
        /// </summary>
        private void updateWordCounter()
        {
            label_qtyUniqueWords.Text = " Word Count:" + tree.Count().ToString();
        }

        /// <summary>
        /// Remove a unique word from the data structure
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_remove_word_Click(object sender, EventArgs e)
        {
            if (!checkForLoadedWords())
            {
                return;
            }
            if (listView_words.SelectedItems.Count == 0) // when no word is selected
            {
                _ = MessageBox.Show("Please select a Word", "Selection Error", MessageBoxButtons.OK);
                return;
            }
            string wordToSearch = listView_words.SelectedItems[0].Text;
            string message = "Do you want to remove the word "+ wordToSearch + "?";
            string caption = "Confirmation";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);
            if (result == DialogResult.Yes)
            {
                Word word = null;
                try
                {
                    word = tree.Find(new Word(wordToSearch.Trim())).Data;
                }
                catch (Exception e2)
                {
                    Console.WriteLine(e2.StackTrace); // throw wordNotFoundException (needs to be created first)..
                }
                tree.RemoveItem(word);
                updateWordCounter();
                refresh_listView_words(string.Empty); //* look at using the original search param instead of .empty
            }
        }

         /// <summary>
         /// Word input search
         /// (Supports task requirement No.1)
         /// </summary>
         /// <param name="sender"></param>
         /// <param name="e"></param>
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            //update_listBox_words(textBox.Text);
            refresh_listView_words(textBox.Text);
        }

        /// <summary>
        /// Overwrites the listView_words component with the words stored in the AVL Tree
        /// (Supports task requirement No.1)
        /// </summary>
        /// <param name="wordToSearch"></param>
        public void refresh_listView_words(string wordToSearch)
        {
            
            ListViewItem[] list = new ListViewItem[tree.GetAllNodes().Length];
            listView_words.Items.Clear();
            foreach (Word w in tree.GetAllNodes())
            {
                if (w.WordObj.StartsWith(wordToSearch.Trim()))
                {
                    ListViewItem i = new ListViewItem(w.WordObj.ToString());
                    i.SubItems.Add(w.Occurrences.ToString());
                    IList<string> locations = new List<string>();

                    foreach (Location l in w.Locations)
                    {
                        locations.Add(l.LineNo + ":" + l.Pos);
                    }
                    string concat = string.Join(", ", locations);
                    i.SubItems.Add(concat);
                    listView_words.Items.Add(i);
                }
            }
            if (listView_words.Items.Count == 0)
            {
                string message = "No word(s) found";
                string caption = "Error Detected in Input";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                _ = MessageBox.Show(message, caption, buttons);
            }
            listView_words.Columns.Add("Word", -2, HorizontalAlignment.Left);
            listView_words.Columns.Add("Occurrences", -2, HorizontalAlignment.Left);
            listView_words.Columns.Add("LineNo:Position", -2, HorizontalAlignment.Left);
            listView_words.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView_words.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        /// <summary>
        /// Overwrites listView component by displaying the concordance of the text stored in the AVL Tree
        /// (show all the unique words present in the text in alphabetic order and the corresponding number of times in which they occur in the text).
        /// (Supports task requirement No.5)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioBtn_concordance_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (!rb.Checked) return; // button set to false => do nothing
            if (!checkForLoadedWords())
            {
                radioBtn_concordance.Checked = false;
                return;
            }
            listView_advancedSearch.Columns.Clear();
            listView_advancedSearch.Columns.Add("Word", 100, HorizontalAlignment.Left);
            listView_advancedSearch.Columns.Add("Occurrences", -2, HorizontalAlignment.Left);
            Word[] words = tree.Concordance();
            ListViewItem[] list = new ListViewItem[words.Length];
            listView_advancedSearch.Items.Clear();
            foreach (Word w in words)
            {
                ListViewItem i = new ListViewItem(w.WordObj.ToString());
                i.SubItems.Add(w.Occurrences.ToString());
                listView_advancedSearch.Items.Add(i);
            }
        }

        /// <summary>
        /// Writes the most common unique word present in AVLTree to the listView component
        /// (Supports task requirement No.7)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioBtn_mostCommonUniqueWord_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (!rb.Checked) return; // button set to false do nothing
            if (!checkForLoadedWords())
            {
                radioBtn_mostCommonUniqueWord.Checked = false;
                return;
            }
            Word[] words = tree.GetAllNodes();
            Word mostCommon = words[0];
            foreach (Word w in words)
            {
                if (w.Occurrences > mostCommon.Occurrences) mostCommon = w;
            }
            listView_advancedSearch.Columns.Clear();
            listView_advancedSearch.Items.Clear();
            listView_advancedSearch.Columns.Add("Word", 100, HorizontalAlignment.Left);
            listView_advancedSearch.Columns.Add("Occurrences", -2, HorizontalAlignment.Left);
            ListViewItem i = new ListViewItem(mostCommon.WordObj.ToString());
            i.SubItems.Add(mostCommon.Occurrences.ToString());
            listView_advancedSearch.Items.Add(i);
            
        }

        /// <summary>
        /// Writes the words which occur more than a specified number of times in AVLTree to the listView component
        /// (Supports task requirement No.7)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioBtn_wordsThatOccurMoreThan_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (!rb.Checked) return; // button set to false do nothing
            if (!checkForLoadedWords())
            {
                radioBtn_wordsThatOccurMoreThan.Checked = false;
                return;
            }
            listView_advancedSearch.Columns.Clear();
            listView_advancedSearch.Columns.Add("Word", 100, HorizontalAlignment.Left);
            listView_advancedSearch.Columns.Add("Occurrences", -2, HorizontalAlignment.Left);
            listView_advancedSearch.Items.Clear();
            int x;
            try
            {
                x = Int32.Parse(textBox_uniqueWordsThatOccurMoreThan.Text);
            }
            catch (FormatException)
            {
                string message = "Search value not entered";
                string caption = "Error Detected in Input";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                _ = MessageBox.Show(message, caption, buttons);
                radioBtn_wordsThatOccurMoreThan.Checked = false;
                return;
            }
            Word[] words = tree.GetAllNodes();
            ListViewItem[] list = new ListViewItem[words.Length];
            foreach (Word w in words)
            {
                if (w.Occurrences > x)
                {
                    ListViewItem i = new ListViewItem(w.WordObj.ToString());
                    i.SubItems.Add(w.Occurrences.ToString());
                    listView_advancedSearch.Items.Add(i);
                }
            }
            if (listView_advancedSearch.Items.Count == 0)
            {
                string message = "No Words found that occur more than "+x+" times";
                string caption = "No Words found";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                _ = MessageBox.Show(message, caption, buttons);
                radioBtn_wordsThatOccurMoreThan.Checked = false;
                return;
            }
        }

        /// <summary>
        /// Writes the unique words present in the AVLTree in decreasing order of occurrence to the listView component
        /// (Supports task requirement No.8)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioBtn_decreasingOrderOccurrence_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (!rb.Checked) return; // button set to false do nothing
            if (!checkForLoadedWords())
            {
                radioBtn_decreasingOrderOccurrence.Checked = false;
                return;
            }

            listView_advancedSearch.Columns.Clear();
            listView_advancedSearch.Columns.Add("Word", 100, HorizontalAlignment.Left);
            listView_advancedSearch.Columns.Add("Occurrences", -2, HorizontalAlignment.Left);
            Word[] words = tree.GetAllNodes();
            ListViewItem[] list = new ListViewItem[words.Length];
            listView_advancedSearch.Items.Clear();

            // insertion sort
            for (int i = 1; i < words.Length; i++)
            {
                Word value = words[i];
                int j = i;

                for (; j > 0 && words[j - 1].Occurrences.CompareTo(value.Occurrences) < 0; j--)
                {
                    words[j] = words[j - 1];
                }
                words[j] = value;
            }
            // add Words to List View table
            foreach (Word w in words)
            {
                ListViewItem i = new ListViewItem(w.WordObj.ToString());
                i.SubItems.Add(w.Occurrences.ToString());
                listView_advancedSearch.Items.Add(i);
            }
        }

        /// <summary>
        /// Writes the Collocation matching results stored in the AVL Tree to the listView component - 
        /// for a specified pair of unique words display the number of times they 
        /// appear next to each other(for example “pound note”) from searching the implemented data 
        /// structure. Assume they must exist on the same line.
        /// (Supports task requirement No.9)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton_collocation_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (!rb.Checked) return; // button set to false do nothing
            if (!checkForLoadedWords())
            {
                radioButton_collocation.Checked = false;
                return;
            }
            listView_advancedSearch.Columns.Clear();
            listView_advancedSearch.Columns.Add("Word", 100, HorizontalAlignment.Left);
            listView_advancedSearch.Columns.Add("Collocation qty", -2, HorizontalAlignment.Left);
            listView_advancedSearch.Items.Clear();
            Word wordA = null;
            try
            {
                wordA = tree.Find(new Word(textBox_collocation_A.Text.ToString())).Data;
            }
            catch (NullReferenceException)
            {
                string message;
                if (textBox_collocation_A.Text == string.Empty)
                {
                    message = "Search value not entered";
                }
                else
                {
                    message = textBox_collocation_A.Text + " not found, please check the Word is loaded";
                }
                string caption = "Error Detected in Input";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                _ = MessageBox.Show(message, caption, buttons);
                radioButton_collocation.Checked = false;
                return;
            }
            Word wordB = null;
            try
            {
                wordB = tree.Find(new Word(textBox_collocation_B.Text.ToString())).Data;
            }
            catch (NullReferenceException)
            {
                string message;
                if (textBox_collocation_B.Text == string.Empty)
                {
                    message = "Search value not entered";
                }
                else
                {
                    message = textBox_collocation_B.Text + " not found, please check the Word is loaded";
                }
                string caption = "Error Detected in Input";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                _ = MessageBox.Show(message, caption, buttons);
                radioButton_collocation.Checked = false;
                return;
            }
            int collocationQty = 0;
            foreach (Location locationA in wordA.Locations)
            {
                foreach (Location locationB in wordB.Locations)
                {
                    if (locationA.LineNo.Equals(locationB.LineNo))
                    {
                        if (locationA.Pos.Equals(locationB.Pos - 1))
                        {
                            // A appears before B
                            collocationQty++;
                        }
                        if (locationB.Pos.Equals(locationA.Pos - 1))
                        {
                            // A appears after B
                            collocationQty++;
                        }
                    }
                }
            }
            if (collocationQty == 0)
            {
                string message = "No Collocation found for word pair '"+ textBox_collocation_A.Text +"' and '"+ textBox_collocation_B.Text+"'";
                string caption = "No Collocation found";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                _ = MessageBox.Show(message, caption, buttons);
                radioButton_collocation.Checked = false;
                return;
            }
            else
            {
                ListViewItem i = new ListViewItem(wordA.WordObj.ToString() + " " + wordB.WordObj.ToString());
                i.SubItems.Add(collocationQty.ToString());
                listView_advancedSearch.Items.Add(i);
            }
        }

        /// <summary>
        /// Checks if the AVL Tree contains any Word objects, if not display an error message to user.
        /// </summary>
        /// <returns></returns>
        private bool checkForLoadedWords()
        {
            Word[] words = tree.GetAllNodes();
            if (words.Length == 0)
            {
                string message = "Please check you have loaded your text file";
                string caption = "No Word(s) found";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                _ = MessageBox.Show(message, caption, buttons);
                return false;
            }
            return true;
        }

    }
}
