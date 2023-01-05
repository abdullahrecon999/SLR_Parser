
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
            this.ParseButton = new System.Windows.Forms.Button();
            this.InputString = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ParsingBox = new System.Windows.Forms.DataGridView();
            this.tokenGridView = new System.Windows.Forms.DataGridView();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.tokenGridView)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // InputBox
            // 
            this.InputBox.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputBox.Location = new System.Drawing.Point(8, 17);
            this.InputBox.Margin = new System.Windows.Forms.Padding(4);
            this.InputBox.Name = "InputBox";
            this.InputBox.Size = new System.Drawing.Size(304, 324);
            this.InputBox.TabIndex = 0;
            this.InputBox.Text = "";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(172, 489);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 62);
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
            this.ErrorBox.Location = new System.Drawing.Point(16, 572);
            this.ErrorBox.Margin = new System.Windows.Forms.Padding(4);
            this.ErrorBox.Name = "ErrorBox";
            this.ErrorBox.Size = new System.Drawing.Size(1765, 37);
            this.ErrorBox.TabIndex = 2;
            this.ErrorBox.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.FirstSetBox);
            this.groupBox1.Location = new System.Drawing.Point(598, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(267, 161);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "First Set";
            // 
            // FirstSetBox
            // 
            this.FirstSetBox.Location = new System.Drawing.Point(8, 23);
            this.FirstSetBox.Margin = new System.Windows.Forms.Padding(4);
            this.FirstSetBox.Name = "FirstSetBox";
            this.FirstSetBox.Size = new System.Drawing.Size(249, 130);
            this.FirstSetBox.TabIndex = 0;
            this.FirstSetBox.Text = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.FollowSetBox);
            this.groupBox2.Location = new System.Drawing.Point(598, 203);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(267, 161);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Follow Set";
            // 
            // FollowSetBox
            // 
            this.FollowSetBox.Location = new System.Drawing.Point(8, 23);
            this.FollowSetBox.Margin = new System.Windows.Forms.Padding(4);
            this.FollowSetBox.Name = "FollowSetBox";
            this.FollowSetBox.Size = new System.Drawing.Size(249, 130);
            this.FollowSetBox.TabIndex = 5;
            this.FollowSetBox.Text = "";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.DFABox);
            this.groupBox3.Location = new System.Drawing.Point(877, 15);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(343, 550);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "DFA";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // DFABox
            // 
            this.DFABox.Location = new System.Drawing.Point(8, 23);
            this.DFABox.Margin = new System.Windows.Forms.Padding(4);
            this.DFABox.Name = "DFABox";
            this.DFABox.Size = new System.Drawing.Size(325, 518);
            this.DFABox.TabIndex = 0;
            this.DFABox.Text = "";
            // 
            // GotoBox
            // 
            this.GotoBox.Location = new System.Drawing.Point(8, 23);
            this.GotoBox.Margin = new System.Windows.Forms.Padding(4);
            this.GotoBox.Name = "GotoBox";
            this.GotoBox.Size = new System.Drawing.Size(249, 130);
            this.GotoBox.TabIndex = 5;
            this.GotoBox.Text = "";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.GotoBox);
            this.groupBox4.Location = new System.Drawing.Point(598, 396);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(267, 161);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "GOTO States";
            // 
            // Ptable
            // 
            this.Ptable.AllowUserToAddRows = false;
            this.Ptable.AllowUserToDeleteRows = false;
            this.Ptable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Ptable.Location = new System.Drawing.Point(7, 7);
            this.Ptable.Margin = new System.Windows.Forms.Padding(4);
            this.Ptable.Name = "Ptable";
            this.Ptable.ReadOnly = true;
            this.Ptable.RowHeadersWidth = 51;
            this.Ptable.Size = new System.Drawing.Size(559, 495);
            this.Ptable.TabIndex = 0;
            this.Ptable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Ptable_CellContentClick);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.NumberedBox);
            this.groupBox6.Controls.Add(this.InputBox);
            this.groupBox6.Location = new System.Drawing.Point(16, 15);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox6.Size = new System.Drawing.Size(321, 466);
            this.groupBox6.TabIndex = 4;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Grammar";
            // 
            // NumberedBox
            // 
            this.NumberedBox.Location = new System.Drawing.Point(9, 351);
            this.NumberedBox.Margin = new System.Windows.Forms.Padding(4);
            this.NumberedBox.Name = "NumberedBox";
            this.NumberedBox.Size = new System.Drawing.Size(303, 107);
            this.NumberedBox.TabIndex = 1;
            this.NumberedBox.Text = "";
            // 
            // ClearAll
            // 
            this.ClearAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearAll.ForeColor = System.Drawing.Color.Red;
            this.ClearAll.Location = new System.Drawing.Point(24, 489);
            this.ClearAll.Margin = new System.Windows.Forms.Padding(4);
            this.ClearAll.Name = "ClearAll";
            this.ClearAll.Size = new System.Drawing.Size(95, 62);
            this.ClearAll.TabIndex = 8;
            this.ClearAll.Text = "CLEAR";
            this.ClearAll.UseVisualStyleBackColor = true;
            this.ClearAll.Click += new System.EventHandler(this.ClearAll_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(1229, 21);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(583, 544);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Ptable);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(575, 515);
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
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(575, 515);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Input Parsing";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ParseButton
            // 
            this.ParseButton.Location = new System.Drawing.Point(479, 6);
            this.ParseButton.Margin = new System.Windows.Forms.Padding(4);
            this.ParseButton.Name = "ParseButton";
            this.ParseButton.Size = new System.Drawing.Size(87, 25);
            this.ParseButton.TabIndex = 4;
            this.ParseButton.Text = "Parse";
            this.ParseButton.UseVisualStyleBackColor = true;
            this.ParseButton.Click += new System.EventHandler(this.ParseButton_Click);
            // 
            // InputString
            // 
            this.InputString.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputString.Location = new System.Drawing.Point(119, 6);
            this.InputString.Margin = new System.Windows.Forms.Padding(4);
            this.InputString.Name = "InputString";
            this.InputString.Size = new System.Drawing.Size(347, 24);
            this.InputString.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Input String";
            // 
            // ParsingBox
            // 
            this.ParsingBox.AllowUserToAddRows = false;
            this.ParsingBox.AllowUserToDeleteRows = false;
            this.ParsingBox.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ParsingBox.Location = new System.Drawing.Point(7, 38);
            this.ParsingBox.Margin = new System.Windows.Forms.Padding(4);
            this.ParsingBox.Name = "ParsingBox";
            this.ParsingBox.ReadOnly = true;
            this.ParsingBox.RowHeadersWidth = 51;
            this.ParsingBox.Size = new System.Drawing.Size(559, 464);
            this.ParsingBox.TabIndex = 1;
            // 
            // tokenGridView
            // 
            this.tokenGridView.AllowUserToOrderColumns = true;
            this.tokenGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tokenGridView.Location = new System.Drawing.Point(6, 21);
            this.tokenGridView.Name = "tokenGridView";
            this.tokenGridView.RowHeadersWidth = 51;
            this.tokenGridView.RowTemplate.Height = 24;
            this.tokenGridView.Size = new System.Drawing.Size(230, 437);
            this.tokenGridView.TabIndex = 10;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tokenGridView);
            this.groupBox5.Location = new System.Drawing.Point(345, 15);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(244, 466);
            this.groupBox5.TabIndex = 11;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Tokens";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1874, 625);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.ClearAll);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ErrorBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox5);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
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
            ((System.ComponentModel.ISupportInitialize)(this.tokenGridView)).EndInit();
            this.groupBox5.ResumeLayout(false);
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
        private System.Windows.Forms.DataGridView tokenGridView;
        private System.Windows.Forms.GroupBox groupBox5;
    }
}

