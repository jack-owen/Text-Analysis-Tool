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
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Show the dialog and get result.
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                try
                {
                    // Create an instance of StreamReader to read from a file.
                    // The using statement also closes the StreamReader.
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
                    // Let the user know what went wrong.
                    Console.WriteLine("The file could not be read:");
                    Console.WriteLine(e2.Message);
                }
            }
            //Console.WriteLine(result); // <-- For debugging use.
            Console.WriteLine(tree.Count() + " words added");
        }

        // find a way to return an object from the 'key' value
        string wordToSearch;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox) sender;
            wordToSearch = textBox.Text;

            //Word wordSearch = tree.Find(new Word(wordToSearch)).Data;
            //Node<Word> wordSearch = tree.Find(new Word(wordToSearch));
            Word master = null;
            try
            {
                master = tree.Find(new Word(wordToSearch.Trim())).Data;
            }
            catch (Exception e2)
            {
                Console.WriteLine(e2.StackTrace);
            }
            if (master != null)
            {
                Debug.WriteLine(tree.Contains(master) + " " + wordToSearch + " found in tree");

                //node = tree.Find(new Word("one", 1, 1));

                label1.Text = wordToSearch; // search value
                output_word.Text = master.WordObj.ToString();
                output_occurrences.Text = master.Occurrences.ToString();
                output_location_lineNo.Text = master.Locations.First.Value.LineNo.ToString(); //+ loop the dif values in Locations linkedlist
                output_location_pos.Text = master.Locations.First.Value.Pos.ToString(); //+ loop the dif values in Locations linkedlist
            }
            else
            {
                label1.Text = wordToSearch;
                output_word.Text = output_occurrences.Text = output_location_lineNo.Text = output_location_pos.Text = "n/a";
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Console.WriteLine(wordToSearch.);
            //label1.Text = wordToSearch;
            
        }
        //public string label1 { get; set; }
    }
}
