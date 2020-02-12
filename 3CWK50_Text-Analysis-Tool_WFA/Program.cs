using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3CWK50_Text_Analysis_Tool_WFA
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());


        // if word does not exist in tree insert new item

        //tree.InsertItem(new Word("Cup", 0, 3));
        //tree.InsertItem(new Word("Elephant", 0, 3));
        //tree.InsertItem(new Word("Basketball", 0, 3));
        // todo 
        // else edit existing item in AVLTree
        // tree.item.add(location)

        /* old Console Application Code 
        // load text file
        string[] lines = System.IO.File.ReadAllLines(@"..\..\..\TextFile_sample-data.txt");

        //foreach (string line in lines)
        for (int i = 0; i < lines.Length - 1; i++)
        {
            string[] words = lines[i].Split(' ');
            for (int j = 0; j < words.Length - 1; j++)
            {
                char[] charsToTrim = { ',', '.', ' ', '\'' };
                //System.Console.WriteLine(word.Trim(charsToTrim));
                tree.InsertItem(new Word(words[j].Trim(charsToTrim), i, j)); // line and pos index start at 0 or 1
            }
        }*/

        }

    }
}
