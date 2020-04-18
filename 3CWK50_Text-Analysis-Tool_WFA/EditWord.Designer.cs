namespace _3CWK50_Text_Analysis_Tool_WFA
{
    partial class EditWord
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_location_remove = new System.Windows.Forms.Button();
            this.button_location_create = new System.Windows.Forms.Button();
            this.label_word = new System.Windows.Forms.Label();
            this.label_locations = new System.Windows.Forms.Label();
            this.listView_locations = new System.Windows.Forms.ListView();
            this.label_locations_pos = new System.Windows.Forms.Label();
            this.textBox_locations_edit_pos = new System.Windows.Forms.TextBox();
            this.label_locations_lineNo = new System.Windows.Forms.Label();
            this.textBox_locations_edit_lineNo = new System.Windows.Forms.TextBox();
            this.label_occurrences_value = new System.Windows.Forms.Label();
            this.label_occurrences = new System.Windows.Forms.Label();
            this.textBox_word = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_location_remove);
            this.panel1.Controls.Add(this.button_location_create);
            this.panel1.Controls.Add(this.label_word);
            this.panel1.Controls.Add(this.label_locations);
            this.panel1.Controls.Add(this.listView_locations);
            this.panel1.Controls.Add(this.label_locations_pos);
            this.panel1.Controls.Add(this.textBox_locations_edit_pos);
            this.panel1.Controls.Add(this.label_locations_lineNo);
            this.panel1.Controls.Add(this.textBox_locations_edit_lineNo);
            this.panel1.Controls.Add(this.label_occurrences_value);
            this.panel1.Controls.Add(this.label_occurrences);
            this.panel1.Location = new System.Drawing.Point(25, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(419, 351);
            this.panel1.TabIndex = 1;
            // 
            // button_location_remove
            // 
            this.button_location_remove.Location = new System.Drawing.Point(142, 306);
            this.button_location_remove.Name = "button_location_remove";
            this.button_location_remove.Size = new System.Drawing.Size(256, 23);
            this.button_location_remove.TabIndex = 16;
            this.button_location_remove.Text = "Remove Location";
            this.button_location_remove.UseVisualStyleBackColor = true;
            this.button_location_remove.Click += new System.EventHandler(this.button_location_remove_Click);
            // 
            // button_location_create
            // 
            this.button_location_create.Location = new System.Drawing.Point(142, 277);
            this.button_location_create.Name = "button_location_create";
            this.button_location_create.Size = new System.Drawing.Size(256, 23);
            this.button_location_create.TabIndex = 15;
            this.button_location_create.Text = "New Location";
            this.button_location_create.UseVisualStyleBackColor = true;
            this.button_location_create.Click += new System.EventHandler(this.button_location_create_Click);
            // 
            // label_word
            // 
            this.label_word.AutoSize = true;
            this.label_word.Location = new System.Drawing.Point(16, 14);
            this.label_word.Name = "label_word";
            this.label_word.Size = new System.Drawing.Size(42, 17);
            this.label_word.TabIndex = 2;
            this.label_word.Text = "Word";
            // 
            // label_locations
            // 
            this.label_locations.AutoSize = true;
            this.label_locations.Location = new System.Drawing.Point(16, 86);
            this.label_locations.Name = "label_locations";
            this.label_locations.Size = new System.Drawing.Size(79, 17);
            this.label_locations.TabIndex = 4;
            this.label_locations.Text = "Location(s)";
            // 
            // listView_locations
            // 
            this.listView_locations.HideSelection = false;
            this.listView_locations.Location = new System.Drawing.Point(142, 86);
            this.listView_locations.Name = "listView_locations";
            this.listView_locations.Size = new System.Drawing.Size(256, 157);
            this.listView_locations.TabIndex = 14;
            this.listView_locations.UseCompatibleStateImageBehavior = false;
            this.listView_locations.View = System.Windows.Forms.View.Details;
            this.listView_locations.Click += new System.EventHandler(this.listView_locations_Click);
            // 
            // label_locations_pos
            // 
            this.label_locations_pos.AutoSize = true;
            this.label_locations_pos.Location = new System.Drawing.Point(219, 252);
            this.label_locations_pos.Name = "label_locations_pos";
            this.label_locations_pos.Size = new System.Drawing.Size(44, 17);
            this.label_locations_pos.TabIndex = 12;
            this.label_locations_pos.Text = "Pos #";
            // 
            // textBox_locations_edit_pos
            // 
            this.textBox_locations_edit_pos.Location = new System.Drawing.Point(269, 249);
            this.textBox_locations_edit_pos.Name = "textBox_locations_edit_pos";
            this.textBox_locations_edit_pos.Size = new System.Drawing.Size(70, 22);
            this.textBox_locations_edit_pos.TabIndex = 13;
            this.textBox_locations_edit_pos.TextChanged += new System.EventHandler(this.textBox_locations_edit_pos_TextChanged);
            // 
            // label_locations_lineNo
            // 
            this.label_locations_lineNo.AutoSize = true;
            this.label_locations_lineNo.Location = new System.Drawing.Point(88, 252);
            this.label_locations_lineNo.Name = "label_locations_lineNo";
            this.label_locations_lineNo.Size = new System.Drawing.Size(47, 17);
            this.label_locations_lineNo.TabIndex = 8;
            this.label_locations_lineNo.Text = "Line #";
            // 
            // textBox_locations_edit_lineNo
            // 
            this.textBox_locations_edit_lineNo.Location = new System.Drawing.Point(141, 249);
            this.textBox_locations_edit_lineNo.Name = "textBox_locations_edit_lineNo";
            this.textBox_locations_edit_lineNo.Size = new System.Drawing.Size(70, 22);
            this.textBox_locations_edit_lineNo.TabIndex = 8;
            this.textBox_locations_edit_lineNo.TextChanged += new System.EventHandler(this.textBox_locations_edit_lineNo_TextChanged);
            // 
            // label_occurrences_value
            // 
            this.label_occurrences_value.AutoSize = true;
            this.label_occurrences_value.Location = new System.Drawing.Point(139, 48);
            this.label_occurrences_value.Name = "label_occurrences_value";
            this.label_occurrences_value.Size = new System.Drawing.Size(128, 17);
            this.label_occurrences_value.TabIndex = 10;
            this.label_occurrences_value.Text = "occurrences_value";
            // 
            // label_occurrences
            // 
            this.label_occurrences.AutoSize = true;
            this.label_occurrences.Location = new System.Drawing.Point(16, 48);
            this.label_occurrences.Name = "label_occurrences";
            this.label_occurrences.Size = new System.Drawing.Size(89, 17);
            this.label_occurrences.TabIndex = 9;
            this.label_occurrences.Text = "Occurrences";
            // 
            // textBox_word
            // 
            this.textBox_word.Location = new System.Drawing.Point(167, 23);
            this.textBox_word.Name = "textBox_word";
            this.textBox_word.Size = new System.Drawing.Size(198, 22);
            this.textBox_word.TabIndex = 7;
            this.textBox_word.TextChanged += new System.EventHandler(this.textBox_word_TextChanged);
            // 
            // EditWord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 390);
            this.Controls.Add(this.textBox_word);
            this.Controls.Add(this.panel1);
            this.Name = "EditWord";
            this.Text = "Edit Word";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditWord_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_word;
        private System.Windows.Forms.Label label_locations;
        private System.Windows.Forms.Label label_occurrences_value;
        private System.Windows.Forms.Label label_occurrences;
        private System.Windows.Forms.Label label_locations_pos;
        private System.Windows.Forms.TextBox textBox_locations_edit_pos;
        private System.Windows.Forms.Label label_locations_lineNo;
        private System.Windows.Forms.TextBox textBox_locations_edit_lineNo;
        private System.Windows.Forms.TextBox textBox_word;
        private System.Windows.Forms.ListView listView_locations;
        private System.Windows.Forms.Button button_location_create;
        private System.Windows.Forms.Button button_location_remove;
    }
}