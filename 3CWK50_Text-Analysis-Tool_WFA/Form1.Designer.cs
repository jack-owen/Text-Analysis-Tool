namespace _3CWK50_Text_Analysis_Tool_WFA
{
    partial class Form1
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button_load = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button_toForm_EditWord = new System.Windows.Forms.Button();
            this.label_qtyUniqueWords = new System.Windows.Forms.Label();
            this.button_remove_word = new System.Windows.Forms.Button();
            this.listView_words = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_collocation_B = new System.Windows.Forms.TextBox();
            this.textBox_collocation_A = new System.Windows.Forms.TextBox();
            this.radioButton_collocation = new System.Windows.Forms.RadioButton();
            this.listView_advancedSearch = new System.Windows.Forms.ListView();
            this.radioBtn_decreasingOrderOccurrence = new System.Windows.Forms.RadioButton();
            this.textBox_uniqueWordsThatOccurMoreThan = new System.Windows.Forms.TextBox();
            this.radioBtn_wordsThatOccurMoreThan = new System.Windows.Forms.RadioButton();
            this.radioBtn_mostCommonUniqueWord = new System.Windows.Forms.RadioButton();
            this.radioBtn_concordance = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_load
            // 
            this.button_load.Location = new System.Drawing.Point(67, 16);
            this.button_load.Name = "button_load";
            this.button_load.Size = new System.Drawing.Size(92, 46);
            this.button_load.TabIndex = 0;
            this.button_load.Text = "Load";
            this.button_load.UseVisualStyleBackColor = true;
            this.button_load.Click += new System.EventHandler(this.button_load_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(8, 27);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(180, 22);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "\r\n";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button_toForm_EditWord
            // 
            this.button_toForm_EditWord.Location = new System.Drawing.Point(194, 27);
            this.button_toForm_EditWord.Name = "button_toForm_EditWord";
            this.button_toForm_EditWord.Size = new System.Drawing.Size(75, 23);
            this.button_toForm_EditWord.TabIndex = 8;
            this.button_toForm_EditWord.Text = "Edit";
            this.button_toForm_EditWord.UseVisualStyleBackColor = true;
            this.button_toForm_EditWord.Click += new System.EventHandler(this.button_editWord_Click);
            // 
            // label_qtyUniqueWords
            // 
            this.label_qtyUniqueWords.AutoSize = true;
            this.label_qtyUniqueWords.Location = new System.Drawing.Point(165, 31);
            this.label_qtyUniqueWords.Name = "label_qtyUniqueWords";
            this.label_qtyUniqueWords.Size = new System.Drawing.Size(151, 17);
            this.label_qtyUniqueWords.TabIndex = 12;
            this.label_qtyUniqueWords.Text = "label_qtyUniqueWords";
            // 
            // button_remove_word
            // 
            this.button_remove_word.Location = new System.Drawing.Point(275, 26);
            this.button_remove_word.Name = "button_remove_word";
            this.button_remove_word.Size = new System.Drawing.Size(75, 23);
            this.button_remove_word.TabIndex = 13;
            this.button_remove_word.Text = "Remove";
            this.button_remove_word.UseVisualStyleBackColor = true;
            this.button_remove_word.Click += new System.EventHandler(this.button_remove_word_Click);
            // 
            // listView_words
            // 
            this.listView_words.FullRowSelect = true;
            this.listView_words.GridLines = true;
            this.listView_words.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView_words.HideSelection = false;
            this.listView_words.Location = new System.Drawing.Point(8, 55);
            this.listView_words.MultiSelect = false;
            this.listView_words.Name = "listView_words";
            this.listView_words.Size = new System.Drawing.Size(365, 342);
            this.listView_words.TabIndex = 18;
            this.listView_words.UseCompatibleStateImageBehavior = false;
            this.listView_words.View = System.Windows.Forms.View.Details;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_collocation_B);
            this.groupBox1.Controls.Add(this.textBox_collocation_A);
            this.groupBox1.Controls.Add(this.radioButton_collocation);
            this.groupBox1.Controls.Add(this.listView_advancedSearch);
            this.groupBox1.Controls.Add(this.radioBtn_decreasingOrderOccurrence);
            this.groupBox1.Controls.Add(this.textBox_uniqueWordsThatOccurMoreThan);
            this.groupBox1.Controls.Add(this.radioBtn_wordsThatOccurMoreThan);
            this.groupBox1.Controls.Add(this.radioBtn_mostCommonUniqueWord);
            this.groupBox1.Controls.Add(this.radioBtn_concordance);
            this.groupBox1.Location = new System.Drawing.Point(457, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(373, 403);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Advanced Search";
            // 
            // textBox_collocation_B
            // 
            this.textBox_collocation_B.Location = new System.Drawing.Point(188, 134);
            this.textBox_collocation_B.Name = "textBox_collocation_B";
            this.textBox_collocation_B.Size = new System.Drawing.Size(78, 22);
            this.textBox_collocation_B.TabIndex = 23;
            // 
            // textBox_collocation_A
            // 
            this.textBox_collocation_A.Location = new System.Drawing.Point(104, 134);
            this.textBox_collocation_A.Name = "textBox_collocation_A";
            this.textBox_collocation_A.Size = new System.Drawing.Size(78, 22);
            this.textBox_collocation_A.TabIndex = 22;
            // 
            // radioButton_collocation
            // 
            this.radioButton_collocation.AutoSize = true;
            this.radioButton_collocation.Location = new System.Drawing.Point(6, 134);
            this.radioButton_collocation.Name = "radioButton_collocation";
            this.radioButton_collocation.Size = new System.Drawing.Size(98, 21);
            this.radioButton_collocation.TabIndex = 21;
            this.radioButton_collocation.TabStop = true;
            this.radioButton_collocation.Text = "Collocation";
            this.radioButton_collocation.UseVisualStyleBackColor = true;
            this.radioButton_collocation.CheckedChanged += new System.EventHandler(this.radioButton_collocation_CheckedChanged);
            // 
            // listView_advancedSearch
            // 
            this.listView_advancedSearch.FullRowSelect = true;
            this.listView_advancedSearch.GridLines = true;
            this.listView_advancedSearch.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView_advancedSearch.HideSelection = false;
            this.listView_advancedSearch.Location = new System.Drawing.Point(6, 162);
            this.listView_advancedSearch.MultiSelect = false;
            this.listView_advancedSearch.Name = "listView_advancedSearch";
            this.listView_advancedSearch.Size = new System.Drawing.Size(361, 235);
            this.listView_advancedSearch.TabIndex = 20;
            this.listView_advancedSearch.UseCompatibleStateImageBehavior = false;
            this.listView_advancedSearch.View = System.Windows.Forms.View.Details;
            // 
            // radioBtn_decreasingOrderOccurrence
            // 
            this.radioBtn_decreasingOrderOccurrence.AutoSize = true;
            this.radioBtn_decreasingOrderOccurrence.Location = new System.Drawing.Point(6, 107);
            this.radioBtn_decreasingOrderOccurrence.Name = "radioBtn_decreasingOrderOccurrence";
            this.radioBtn_decreasingOrderOccurrence.Size = new System.Drawing.Size(236, 21);
            this.radioBtn_decreasingOrderOccurrence.TabIndex = 4;
            this.radioBtn_decreasingOrderOccurrence.TabStop = true;
            this.radioBtn_decreasingOrderOccurrence.Text = "Decreasing Order of Occurrence";
            this.radioBtn_decreasingOrderOccurrence.UseVisualStyleBackColor = true;
            this.radioBtn_decreasingOrderOccurrence.CheckedChanged += new System.EventHandler(this.radioBtn_decreasingOrderOccurrence_CheckedChanged);
            // 
            // textBox_uniqueWordsThatOccurMoreThan
            // 
            this.textBox_uniqueWordsThatOccurMoreThan.Location = new System.Drawing.Point(219, 79);
            this.textBox_uniqueWordsThatOccurMoreThan.Name = "textBox_uniqueWordsThatOccurMoreThan";
            this.textBox_uniqueWordsThatOccurMoreThan.Size = new System.Drawing.Size(24, 22);
            this.textBox_uniqueWordsThatOccurMoreThan.TabIndex = 3;
            // 
            // radioBtn_wordsThatOccurMoreThan
            // 
            this.radioBtn_wordsThatOccurMoreThan.AutoSize = true;
            this.radioBtn_wordsThatOccurMoreThan.Location = new System.Drawing.Point(6, 79);
            this.radioBtn_wordsThatOccurMoreThan.Name = "radioBtn_wordsThatOccurMoreThan";
            this.radioBtn_wordsThatOccurMoreThan.Size = new System.Drawing.Size(213, 21);
            this.radioBtn_wordsThatOccurMoreThan.TabIndex = 2;
            this.radioBtn_wordsThatOccurMoreThan.TabStop = true;
            this.radioBtn_wordsThatOccurMoreThan.Text = "Words That Occur more than";
            this.radioBtn_wordsThatOccurMoreThan.UseVisualStyleBackColor = true;
            this.radioBtn_wordsThatOccurMoreThan.CheckedChanged += new System.EventHandler(this.radioBtn_wordsThatOccurMoreThan_CheckedChanged);
            // 
            // radioBtn_mostCommonUniqueWord
            // 
            this.radioBtn_mostCommonUniqueWord.AutoSize = true;
            this.radioBtn_mostCommonUniqueWord.Location = new System.Drawing.Point(6, 52);
            this.radioBtn_mostCommonUniqueWord.Name = "radioBtn_mostCommonUniqueWord";
            this.radioBtn_mostCommonUniqueWord.Size = new System.Drawing.Size(205, 21);
            this.radioBtn_mostCommonUniqueWord.TabIndex = 1;
            this.radioBtn_mostCommonUniqueWord.TabStop = true;
            this.radioBtn_mostCommonUniqueWord.Text = "Most Common Unique Word";
            this.radioBtn_mostCommonUniqueWord.UseVisualStyleBackColor = true;
            this.radioBtn_mostCommonUniqueWord.CheckedChanged += new System.EventHandler(this.radioBtn_mostCommonUniqueWord_CheckedChanged);
            // 
            // radioBtn_concordance
            // 
            this.radioBtn_concordance.AutoSize = true;
            this.radioBtn_concordance.Location = new System.Drawing.Point(6, 25);
            this.radioBtn_concordance.Name = "radioBtn_concordance";
            this.radioBtn_concordance.Size = new System.Drawing.Size(113, 21);
            this.radioBtn_concordance.TabIndex = 0;
            this.radioBtn_concordance.TabStop = true;
            this.radioBtn_concordance.Text = "Concordance";
            this.radioBtn_concordance.UseVisualStyleBackColor = true;
            this.radioBtn_concordance.CheckedChanged += new System.EventHandler(this.radioBtn_concordance_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listView_words);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.button_toForm_EditWord);
            this.groupBox2.Controls.Add(this.button_remove_word);
            this.groupBox2.Location = new System.Drawing.Point(59, 69);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(380, 403);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search by Prefix";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 621);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label_qtyUniqueWords);
            this.Controls.Add(this.button_load);
            this.Controls.Add(this.groupBox2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button_load;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button_toForm_EditWord;
        private System.Windows.Forms.Label label_qtyUniqueWords;
        private System.Windows.Forms.Button button_remove_word;
        private System.Windows.Forms.ListView listView_words;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioBtn_decreasingOrderOccurrence;
        private System.Windows.Forms.TextBox textBox_uniqueWordsThatOccurMoreThan;
        private System.Windows.Forms.RadioButton radioBtn_wordsThatOccurMoreThan;
        private System.Windows.Forms.RadioButton radioBtn_mostCommonUniqueWord;
        private System.Windows.Forms.RadioButton radioBtn_concordance;
        private System.Windows.Forms.ListView listView_advancedSearch;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton_collocation;
        private System.Windows.Forms.TextBox textBox_collocation_B;
        private System.Windows.Forms.TextBox textBox_collocation_A;
    }
}

