
namespace SLR_parser {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.InputBox = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.ErrorBox = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.FirstSetBox = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.FollowSetBox = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.DFABox = new System.Windows.Forms.RichTextBox();
            this.GotoBox = new System.Windows.Forms.RichTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.Ptable = new System.Windows.Forms.DataGridView();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.NumberedBox = new System.Windows.Forms.RichTextBox();
            this.ClearAll = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ParsingBox = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.InputString = new System.Windows.Forms.TextBox();
            this.ParseButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Ptable)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ParsingBox)).BeginInit();
            this.SuspendLayout();
            // 
            // InputBox
            // 
            this.InputBox.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputBox.Location = new System.Drawing.Point(6, 14);
            this.InputBox.Name = "InputBox";
            this.InputBox.Size = new System.Drawing.Size(229, 264);
            this.InputBox.TabIndex = 0;
            this.InputBox.Text = "";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(129, 397);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 50);
            this.button1.TabIndex = 1;
            this.button1.Text = "RUN";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ErrorBox
            // 
            this.ErrorBox.BackColor = System.Drawing.SystemColors.Info;
            this.ErrorBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrorBox.ForeColor = System.Drawing.Color.Red;
            this.ErrorBox.Location = new System.Drawing.Point(12, 465);
            this.ErrorBox.Name = "ErrorBox";
            this.ErrorBox.Size = new System.Drawing.Size(1325, 31);
            this.ErrorBox.TabIndex = 2;
            this.ErrorBox.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.FirstSetBox);
            this.groupBox1.Location = new System.Drawing.Point(259, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 131);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "First Set";
            // 
            // FirstSetBox
            // 
            this.FirstSetBox.Location = new System.Drawing.Point(6, 19);
            this.FirstSetBox.Name = "FirstSetBox";
            this.FirstSetBox.Size = new System.Drawing.Size(188, 106);
            this.FirstSetBox.TabIndex = 0;
            this.FirstSetBox.Text = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.FollowSetBox);
            this.groupBox2.Location = new System.Drawing.Point(259, 165);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 131);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Follow Set";
            // 
            // FollowSetBox
            // 
            this.FollowSetBox.Location = new System.Drawing.Point(6, 19);
            this.FollowSetBox.Name = "FollowSetBox";
            this.FollowSetBox.Size = new System.Drawing.Size(188, 106);
            this.FollowSetBox.TabIndex = 5;
            this.FollowSetBox.Text = "";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.DFABox);
            this.groupBox3.Location = new System.Drawing.Point(468, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(257, 447);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "DFA";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // DFABox
            // 
            this.DFABox.Location = new System.Drawing.Point(6, 19);
            this.DFABox.Name = "DFABox";
            this.DFABox.Size = new System.Drawing.Size(245, 422);
            this.DFABox.TabIndex = 0;
            this.DFABox.Text = "";
            // 
            // GotoBox
            // 
            this.GotoBox.Location = new System.Drawing.Point(6, 19);
            this.GotoBox.Name = "GotoBox";
            this.GotoBox.Size = new System.Drawing.Size(188, 106);
            this.GotoBox.TabIndex = 5;
            this.GotoBox.Text = "";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.GotoBox);
            this.groupBox4.Location = new System.Drawing.Point(259, 322);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 131);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "GOTO States";
            // 
            // Ptable
            // 
            this.Ptable.AllowUserToAddRows = false;
            this.Ptable.AllowUserToDeleteRows = false;
            this.Ptable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Ptable.Location = new System.Drawing.Point(5, 6);
            this.Ptable.Name = "Ptable";
            this.Ptable.ReadOnly = true;
            this.Ptable.Size = new System.Drawing.Size(419, 402);
            this.Ptable.TabIndex = 0;
            this.Ptable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Ptable_CellContentClick);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.NumberedBox);
            this.groupBox6.Controls.Add(this.InputBox);
            this.groupBox6.Location = new System.Drawing.Point(12, 12);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(241, 379);
            this.groupBox6.TabIndex = 4;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Grammar";
            // 
            // NumberedBox
            // 
            this.NumberedBox.Location = new System.Drawing.Point(7, 285);
            this.NumberedBox.Name = "NumberedBox";
            this.NumberedBox.Size = new System.Drawing.Size(228, 88);
            this.NumberedBox.TabIndex = 1;
            this.NumberedBox.Text = "";
            // 
            // ClearAll
            // 
            this.ClearAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearAll.ForeColor = System.Drawing.Color.Red;
            this.ClearAll.Location = new System.Drawing.Point(18, 397);
            this.ClearAll.Name = "ClearAll";
            this.ClearAll.Size = new System.Drawing.Size(71, 50);
            this.ClearAll.TabIndex = 8;
            this.ClearAll.Text = "CLEAR";
            this.ClearAll.UseVisualStyleBackColor = true;
            this.ClearAll.Click += new System.EventHandler(this.ClearAll_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(732, 17);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(437, 442);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Ptable);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(429, 416);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Parsing Table";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ParseButton);
            this.tabPage2.Controls.Add(this.InputString);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.ParsingBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(429, 416);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Input Parsing";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ParsingBox
            // 
            this.ParsingBox.AllowUserToAddRows = false;
            this.ParsingBox.AllowUserToDeleteRows = false;
            this.ParsingBox.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ParsingBox.Location = new System.Drawing.Point(5, 31);
            this.ParsingBox.Name = "ParsingBox";
            this.ParsingBox.ReadOnly = true;
            this.ParsingBox.Size = new System.Drawing.Size(419, 377);
            this.ParsingBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Input String";
            // 
            // InputString
            // 
            this.InputString.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputString.Location = new System.Drawing.Point(89, 5);
            this.InputString.Name = "InputString";
            this.InputString.Size = new System.Drawing.Size(261, 20);
            this.InputString.TabIndex = 3;
            // 
            // ParseButton
            // 
            this.ParseButton.Location = new System.Drawing.Point(359, 5);
            this.ParseButton.Name = "ParseButton";
            this.ParseButton.Size = new System.Drawing.Size(65, 20);
            this.ParseButton.TabIndex = 4;
            this.ParseButton.Text = "Parse";
            this.ParseButton.UseVisualStyleBackColor = true;
            this.ParseButton.Click += new System.EventHandler(this.ParseButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1170, 508);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.ClearAll);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ErrorBox);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Ptable)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ParsingBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox InputBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox ErrorBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox FirstSetBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox FollowSetBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox DFABox;
        private System.Windows.Forms.RichTextBox GotoBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView Ptable;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button ClearAll;
        private System.Windows.Forms.RichTextBox NumberedBox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView ParsingBox;
        private System.Windows.Forms.TextBox InputString;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ParseButton;
    }
}

