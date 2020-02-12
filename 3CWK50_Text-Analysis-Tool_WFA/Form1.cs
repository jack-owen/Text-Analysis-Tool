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
    public partial class Form1 : Form
    {
        private AVLTree<Word> tree;

        public Form1()
        {
            InitializeComponent();
            tree = new AVLTree<Word>();
            //string _ = "It was one January morning, very early, a pinching, frosty morning. The cove all grey with hoar frost,";
            string _ = "frost";
            char[] chars = { ',', ' ', '.' };
            string[] e = _.Split(chars);
            for (int i = 0; i < e.Length; i++)
            {
                tree.InsertItem(new Word(e[i], 1, 1));
            }
            listView_words.Columns.Add("Word", -2, HorizontalAlignment.Left);
            listView_words.Columns.Add("Occurrences", -2, HorizontalAlignment.Left);
            listView_words.Columns.Add("LineNo:Position", -2, HorizontalAlignment.Left);
            refresh_listView_words(string.Empty);
            updateWordCounter();
        }

        /* 1. Load a text file and store the unique words (AVL Tree) */
        private void button1_Click(object sender, EventArgs e)
        {
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
                            for (int j = 0; j < words.Length - 1; j++)
                            {
                                char[] charsToTrim = { ',', '.', ' ', '\'' };
                                if (tree.Contains(new Word(words[j].Trim(charsToTrim)))) {
                                    Word word = tree.Find(new Word(words[j].Trim(charsToTrim))).Data;
                                    word.AddLocation(i,j);
                                }
                                else
                                {
                                    tree.InsertItem(new Word(words[j].Trim(charsToTrim), i, j)); // line and pos index start at 0 or 1
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
        }

        /* 2. Manually edit (and save in the data structure) the information of a unique word */
        private void button_toForm_EditWord_Click(object sender, EventArgs e)
        {
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

        /* 3. Display the number of unique words present in the text */
        private void updateWordCounter()
        {
            label_qtyUniqueWords.Text = " Word Count:" + tree.Count().ToString();
        }

        /* 4. Remove a unique word from the data structure */
        private void button_remove_word_Click(object sender, EventArgs e)
        {
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

     

        /* Word input search 
         * Supports Point No.1 */
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            //update_listBox_words(textBox.Text);
            refresh_listView_words(textBox.Text);
        }

        /* A private function called when the Tree of objects is changed to update the listView_words component
         * Supports Point No.1 */
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
            else if (listView_words.Items.Count > 0)
            {
                //listView_words.Items[0].Focused;
                //listView_words.Items[0].Selected;
            }
        }

        /* 5. Display the concordance of the text – i.e. show all the unique words present in the text in
                alphabetic order and the corresponding number of times in which they occur in the text */
        private void radioBtn_concordance_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (!rb.Checked) return; // button set to false do nothing
                                     /* show all the unique words present in the text in alphabetic order and the
                                     corresponding number of times in which they occur in the text */
            update_concordance();
        }
        

        private void update_concordance()
        {
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

        /* 7a the most common unique word present in the text */
        private void radioBtn_mostCommonUniqueWord_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (!rb.Checked) return; // button set to false do nothing
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

        /* 7b unique words which occur more than a specified number of times */
        private void radioBtn_wordsThatOccurMoreThan_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (!rb.Checked) return; // button set to false do nothing
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
        }

        /* all the unique words present in the text in decreasing order of occurrence */
        private void radioBtn_decreasingOrderOccurrence_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (!rb.Checked) return; // button set to false do nothing
            listView_advancedSearch.Columns.Clear();
            listView_advancedSearch.Columns.Add("Word", 100, HorizontalAlignment.Left);
            listView_advancedSearch.Columns.Add("Occurrences", -2, HorizontalAlignment.Left);
            Word[] words = tree.GetAllNodes();
            ListViewItem[] list = new ListViewItem[words.Length];
            listView_advancedSearch.Items.Clear();

            //?* methods to get Words in Occurence order descending. which is more maintainable?
            // 1. getAllNodes (preorder) -> then sort locally -> then populate List View
            // 2. getAllNodes from tree -> sort nodes in tree method + lambda CompareTo method -> populate List View

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
            // add to List View table
            foreach (Word w in words)
            {
                ListViewItem i = new ListViewItem(w.WordObj.ToString());
                i.SubItems.Add(w.Occurrences.ToString());
                listView_advancedSearch.Items.Add(i);
            }
        }

        /* for a specified pair of unique words display the number of times they
        appear next to each other (for example “pound note”) from searching the implemented data
        structure. Assume they must exist on the same line. */
        
        //? is a nested for loop search on all nodes the most efficient method to use
        
        private void radioButton_collocation_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (!rb.Checked) return; // button set to false do nothing
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
                string message = "No Collocation found for word pair "+ textBox_collocation_A.Text +" and "+ textBox_collocation_B.Text;
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

        //private void update_listBox_words(string wordToSearch)
        //{
        //    listBox_words.Items.Clear();
        //    Word[] words = tree.GetAllNodes();
        //    foreach (Word w in words)
        //    {
        //        if (w.WordObj.StartsWith(wordToSearch.Trim()))
        //        {
        //            listBox_words.Items.Add(w.WordObj.ToString());
        //        }
        //    }
        //    //* instead of finding one Word in the Tree, search through the tree for matches.
        //    //master = tree.Find(new Word(wordToSearch.Trim())).Data; // old method used to search for words
        //    //listBox_words.Items.Add(master.WordObj.ToString());
        //    if (listBox_words.Items.Count == 0)
        //    {
        //        string message = "Word not found";
        //        string caption = "Error Detected in Input";
        //        MessageBoxButtons buttons = MessageBoxButtons.OK;
        //        _ = MessageBox.Show(message, caption, buttons);
        //    }
        //    else if (listBox_words.Items.Count > 0) listBox_words.SelectedIndex = 0;
        //}


        //private void listBox_words_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //* is there a way to pass Word object from the selected item
        //    //Console.WriteLine(listBox_words.SelectedItem);
        //    string wordToSearch = listBox_words.SelectedItem.ToString();
        //    Word word = null;
        //    try
        //    {
        //        word = tree.Find(new Word(wordToSearch.Trim())).Data;
        //    }
        //    catch (Exception e2)
        //    {
        //        Console.WriteLine(e2.StackTrace);
        //    }
        //    updateOutputWordInfo(word);
        //}

        //private void updateOutputWordInfo(Word word)
        //{
        //    output_word.Text = word.WordObj.ToString();
        //    output_occurrences.Text = word.Occurrences.ToString();
        //    listBox_word_location.Items.Clear();
        //    foreach (Location location in word.Locations)
        //    {
        //        listBox_word_location.Items.Add("Line Number: "+location.LineNo.ToString()+", position: "+location.Pos.ToString());
        //    }
        //    // listBox_word_location
        //    //+ list of locations.
        //    //output_location_lineNo.Text = word.Locations.First.Value.LineNo.ToString(); //+ loop the dif values in Locations linkedlist
        //    //output_location_pos.Text = word.Locations.First.Value.Pos.ToString(); //+ loop the dif values in Locations linkedlist
        //}


    }
}
