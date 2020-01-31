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
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.wordOutput = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.output_word = new System.Windows.Forms.Label();
            this.output_occurrences = new System.Windows.Forms.Label();
            this.output_location_lineNo = new System.Windows.Forms.Label();
            this.output_location_pos = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(599, 89);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 46);
            this.button1.TabIndex = 0;
            this.button1.Text = "Load";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(65, 45);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(180, 22);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(270, 45);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Edit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // wordOutput
            // 
            this.wordOutput.Location = new System.Drawing.Point(0, 0);
            this.wordOutput.Name = "wordOutput";
            this.wordOutput.Size = new System.Drawing.Size(100, 23);
            this.wordOutput.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // output_word
            // 
            this.output_word.AutoSize = true;
            this.output_word.Location = new System.Drawing.Point(65, 149);
            this.output_word.Name = "output_word";
            this.output_word.Size = new System.Drawing.Size(86, 17);
            this.output_word.TabIndex = 4;
            this.output_word.Text = "output_word";
            // 
            // output_occurrences
            // 
            this.output_occurrences.AutoSize = true;
            this.output_occurrences.Location = new System.Drawing.Point(68, 180);
            this.output_occurrences.Name = "output_occurrences";
            this.output_occurrences.Size = new System.Drawing.Size(134, 17);
            this.output_occurrences.TabIndex = 5;
            this.output_occurrences.Text = "output_occurrences";
            // 
            // output_location_lineNo
            // 
            this.output_location_lineNo.AutoSize = true;
            this.output_location_lineNo.Location = new System.Drawing.Point(68, 210);
            this.output_location_lineNo.Name = "output_location_lineNo";
            this.output_location_lineNo.Size = new System.Drawing.Size(153, 17);
            this.output_location_lineNo.TabIndex = 6;
            this.output_location_lineNo.Text = "output_location_lineNo";
            // 
            // output_location_pos
            // 
            this.output_location_pos.AutoSize = true;
            this.output_location_pos.Location = new System.Drawing.Point(68, 239);
            this.output_location_pos.Name = "output_location_pos";
            this.output_location_pos.Size = new System.Drawing.Size(136, 17);
            this.output_location_pos.TabIndex = 7;
            this.output_location_pos.Text = "output_location_pos";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.output_location_pos);
            this.Controls.Add(this.output_location_lineNo);
            this.Controls.Add(this.output_occurrences);
            this.Controls.Add(this.output_word);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.wordOutput);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label wordOutput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label output_word;
        private System.Windows.Forms.Label output_occurrences;
        private System.Windows.Forms.Label output_location_lineNo;
        private System.Windows.Forms.Label output_location_pos;
    }
}

