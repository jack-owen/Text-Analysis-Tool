namespace _3CWK50_Text_Analysis_Tool_WFA
{
    partial class AddLocation
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
            this.label_locations_pos = new System.Windows.Forms.Label();
            this.textBox_locations_add_pos = new System.Windows.Forms.TextBox();
            this.label_locations_lineNo = new System.Windows.Forms.Label();
            this.textBox_locations_add_lineNo = new System.Windows.Forms.TextBox();
            this.btn_add = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_locations_pos
            // 
            this.label_locations_pos.AutoSize = true;
            this.label_locations_pos.Location = new System.Drawing.Point(177, 47);
            this.label_locations_pos.Name = "label_locations_pos";
            this.label_locations_pos.Size = new System.Drawing.Size(44, 17);
            this.label_locations_pos.TabIndex = 16;
            this.label_locations_pos.Text = "Pos #";
            // 
            // textBox_locations_add_pos
            // 
            this.textBox_locations_add_pos.Location = new System.Drawing.Point(227, 44);
            this.textBox_locations_add_pos.Name = "textBox_locations_add_pos";
            this.textBox_locations_add_pos.Size = new System.Drawing.Size(70, 22);
            this.textBox_locations_add_pos.TabIndex = 17;
            // 
            // label_locations_lineNo
            // 
            this.label_locations_lineNo.AutoSize = true;
            this.label_locations_lineNo.Location = new System.Drawing.Point(46, 47);
            this.label_locations_lineNo.Name = "label_locations_lineNo";
            this.label_locations_lineNo.Size = new System.Drawing.Size(47, 17);
            this.label_locations_lineNo.TabIndex = 14;
            this.label_locations_lineNo.Text = "Line #";
            // 
            // textBox_locations_add_lineNo
            // 
            this.textBox_locations_add_lineNo.Location = new System.Drawing.Point(99, 44);
            this.textBox_locations_add_lineNo.Name = "textBox_locations_add_lineNo";
            this.textBox_locations_add_lineNo.Size = new System.Drawing.Size(70, 22);
            this.textBox_locations_add_lineNo.TabIndex = 15;
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(49, 83);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(248, 31);
            this.btn_add.TabIndex = 18;
            this.btn_add.Text = "Add";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // AddLocation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 450);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.label_locations_pos);
            this.Controls.Add(this.textBox_locations_add_pos);
            this.Controls.Add(this.label_locations_lineNo);
            this.Controls.Add(this.textBox_locations_add_lineNo);
            this.Name = "AddLocation";
            this.Text = "AddLocation";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddLocation_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_locations_pos;
        private System.Windows.Forms.TextBox textBox_locations_add_pos;
        private System.Windows.Forms.Label label_locations_lineNo;
        private System.Windows.Forms.TextBox textBox_locations_add_lineNo;
        private System.Windows.Forms.Button btn_add;
    }
}