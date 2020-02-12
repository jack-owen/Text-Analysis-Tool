﻿using System;
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
        public AddLocation(object w, EditWord parent)
        {
            this.word = (Word)w;
            this.parent = parent;
            InitializeComponent();


        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            word.AddLocation(Int32.Parse(textBox_locations_add_lineNo.Text), Int32.Parse(textBox_locations_add_pos.Text));
            Close();
            parent.refresh_listView_locations();
        }

        private void AddLocation_FormClosing(object sender, FormClosingEventArgs e)
        {
            //    string message = "Do you want to contiue without adding a new location to "+word.WordObj;
            //    string caption = "Confirmation";
            //    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            //    DialogResult res = MessageBox.Show(message, caption, buttons);

            //    e.Cancel = (res == DialogResult.No);

            //}
        }
    }
}