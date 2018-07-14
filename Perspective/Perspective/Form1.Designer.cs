namespace Perspective
{
    partial class MainForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.povListTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.settingsTab = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.activeCellTextColorButton = new System.Windows.Forms.Button();
            this.activeCellBackgroundColorButton = new System.Windows.Forms.Button();
            this.blankCellPaintCheckBox = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cellPaddingHorizontalText = new System.Windows.Forms.TextBox();
            this.cellPaddingVerticalText = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cellGapHorizontalText = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cellGapVerticalText = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.normalCellTextColorButton = new System.Windows.Forms.Button();
            this.normalCellFontSizeCombo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.normalCellFontCombo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cellBackgroundColorButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.titleFontCombo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.subTitleTextBox = new System.Windows.Forms.TextBox();
            this.generateButton = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.BlankCellBackgroundColorButton = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.settingsTab.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.settingsTab);
            this.tabControl1.Location = new System.Drawing.Point(5, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(795, 410);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.povListTextBox);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(787, 384);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Generate";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pictureBox);
            this.panel1.Location = new System.Drawing.Point(306, 59);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(473, 222);
            this.panel1.TabIndex = 5;
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(3, 3);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(467, 216);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox.TabIndex = 4;
            this.pictureBox.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(289, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Separate scenes with comma and chapters with semi-colon.";
            // 
            // povListTextBox
            // 
            this.povListTextBox.Location = new System.Drawing.Point(10, 59);
            this.povListTextBox.Multiline = true;
            this.povListTextBox.Name = "povListTextBox";
            this.povListTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.povListTextBox.Size = new System.Drawing.Size(289, 165);
            this.povListTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Point-Of-View List";
            // 
            // settingsTab
            // 
            this.settingsTab.Controls.Add(this.groupBox2);
            this.settingsTab.Controls.Add(this.groupBox1);
            this.settingsTab.Location = new System.Drawing.Point(4, 22);
            this.settingsTab.Name = "settingsTab";
            this.settingsTab.Padding = new System.Windows.Forms.Padding(3);
            this.settingsTab.Size = new System.Drawing.Size(787, 384);
            this.settingsTab.TabIndex = 1;
            this.settingsTab.Text = "Settings";
            this.settingsTab.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BlankCellBackgroundColorButton);
            this.groupBox2.Controls.Add(this.activeCellTextColorButton);
            this.groupBox2.Controls.Add(this.activeCellBackgroundColorButton);
            this.groupBox2.Controls.Add(this.blankCellPaintCheckBox);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.cellPaddingHorizontalText);
            this.groupBox2.Controls.Add(this.cellPaddingVerticalText);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.cellGapHorizontalText);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.cellGapVerticalText);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.normalCellTextColorButton);
            this.groupBox2.Controls.Add(this.normalCellFontSizeCombo);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.normalCellFontCombo);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cellBackgroundColorButton);
            this.groupBox2.Location = new System.Drawing.Point(6, 79);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(726, 211);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cells";
            // 
            // activeCellTextColorButton
            // 
            this.activeCellTextColorButton.Location = new System.Drawing.Point(205, 123);
            this.activeCellTextColorButton.Name = "activeCellTextColorButton";
            this.activeCellTextColorButton.Size = new System.Drawing.Size(90, 23);
            this.activeCellTextColorButton.TabIndex = 24;
            this.activeCellTextColorButton.Text = "Text Colour...";
            this.activeCellTextColorButton.UseVisualStyleBackColor = true;
            // 
            // activeCellBackgroundColorButton
            // 
            this.activeCellBackgroundColorButton.Location = new System.Drawing.Point(75, 123);
            this.activeCellBackgroundColorButton.Name = "activeCellBackgroundColorButton";
            this.activeCellBackgroundColorButton.Size = new System.Drawing.Size(123, 23);
            this.activeCellBackgroundColorButton.TabIndex = 23;
            this.activeCellBackgroundColorButton.Text = "Background Colour...";
            this.activeCellBackgroundColorButton.UseVisualStyleBackColor = true;
            // 
            // blankCellPaintCheckBox
            // 
            this.blankCellPaintCheckBox.AutoSize = true;
            this.blankCellPaintCheckBox.Location = new System.Drawing.Point(205, 156);
            this.blankCellPaintCheckBox.Name = "blankCellPaintCheckBox";
            this.blankCellPaintCheckBox.Size = new System.Drawing.Size(50, 17);
            this.blankCellPaintCheckBox.TabIndex = 22;
            this.blankCellPaintCheckBox.Text = "Paint";
            this.blankCellPaintCheckBox.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 157);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 13);
            this.label12.TabIndex = 21;
            this.label12.Text = "Blank Cell:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 128);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Active Cell:";
            // 
            // cellPaddingHorizontalText
            // 
            this.cellPaddingHorizontalText.Location = new System.Drawing.Point(238, 62);
            this.cellPaddingHorizontalText.Name = "cellPaddingHorizontalText";
            this.cellPaddingHorizontalText.Size = new System.Drawing.Size(34, 20);
            this.cellPaddingHorizontalText.TabIndex = 19;
            this.cellPaddingHorizontalText.Text = "5";
            // 
            // cellPaddingVerticalText
            // 
            this.cellPaddingVerticalText.Location = new System.Drawing.Point(164, 62);
            this.cellPaddingVerticalText.Name = "cellPaddingVerticalText";
            this.cellPaddingVerticalText.Size = new System.Drawing.Size(34, 20);
            this.cellPaddingVerticalText.TabIndex = 17;
            this.cellPaddingVerticalText.Text = "5";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 69);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(139, 13);
            this.label13.TabIndex = 15;
            this.label13.Text = "Padding within Cells (pixels):";
            // 
            // cellGapHorizontalText
            // 
            this.cellGapHorizontalText.Location = new System.Drawing.Point(238, 38);
            this.cellGapHorizontalText.Name = "cellGapHorizontalText";
            this.cellGapHorizontalText.Size = new System.Drawing.Size(34, 20);
            this.cellGapHorizontalText.TabIndex = 14;
            this.cellGapHorizontalText.Text = "5";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(235, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "Horizontal";
            // 
            // cellGapVerticalText
            // 
            this.cellGapVerticalText.Location = new System.Drawing.Point(164, 38);
            this.cellGapVerticalText.Name = "cellGapVerticalText";
            this.cellGapVerticalText.Size = new System.Drawing.Size(34, 20);
            this.cellGapVerticalText.TabIndex = 12;
            this.cellGapVerticalText.Text = "5";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(161, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Vertical";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(134, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Gap between Cells (pixels):";
            // 
            // normalCellTextColorButton
            // 
            this.normalCellTextColorButton.Location = new System.Drawing.Point(205, 95);
            this.normalCellTextColorButton.Name = "normalCellTextColorButton";
            this.normalCellTextColorButton.Size = new System.Drawing.Size(90, 23);
            this.normalCellTextColorButton.TabIndex = 9;
            this.normalCellTextColorButton.Text = "Text Colour...";
            this.normalCellTextColorButton.UseVisualStyleBackColor = true;
            this.normalCellTextColorButton.Click += new System.EventHandler(this.normalCellTextColorButton_Click);
            // 
            // normalCellFontSizeCombo
            // 
            this.normalCellFontSizeCombo.FormattingEnabled = true;
            this.normalCellFontSizeCombo.Location = new System.Drawing.Point(474, 97);
            this.normalCellFontSizeCombo.Name = "normalCellFontSizeCombo";
            this.normalCellFontSizeCombo.Size = new System.Drawing.Size(42, 21);
            this.normalCellFontSizeCombo.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(310, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Font:";
            // 
            // normalCellFontCombo
            // 
            this.normalCellFontCombo.FormattingEnabled = true;
            this.normalCellFontCombo.Location = new System.Drawing.Point(347, 97);
            this.normalCellFontCombo.Name = "normalCellFontCombo";
            this.normalCellFontCombo.Size = new System.Drawing.Size(121, 21);
            this.normalCellFontCombo.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Normal Cell:";
            // 
            // cellBackgroundColorButton
            // 
            this.cellBackgroundColorButton.Location = new System.Drawing.Point(75, 95);
            this.cellBackgroundColorButton.Name = "cellBackgroundColorButton";
            this.cellBackgroundColorButton.Size = new System.Drawing.Size(123, 23);
            this.cellBackgroundColorButton.TabIndex = 4;
            this.cellBackgroundColorButton.Text = "Background Colour...";
            this.cellBackgroundColorButton.UseVisualStyleBackColor = true;
            this.cellBackgroundColorButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.titleFontCombo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.titleTextBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.subTitleTextBox);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(726, 67);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Titles";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(292, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Font:";
            // 
            // titleFontCombo
            // 
            this.titleFontCombo.FormattingEnabled = true;
            this.titleFontCombo.Location = new System.Drawing.Point(329, 12);
            this.titleFontCombo.Name = "titleFontCombo";
            this.titleFontCombo.Size = new System.Drawing.Size(121, 21);
            this.titleFontCombo.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Title:";
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(57, 13);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(223, 20);
            this.titleTextBox.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Subtitle:";
            // 
            // subTitleTextBox
            // 
            this.subTitleTextBox.Location = new System.Drawing.Point(57, 39);
            this.subTitleTextBox.Name = "subTitleTextBox";
            this.subTitleTextBox.Size = new System.Drawing.Size(223, 20);
            this.subTitleTextBox.TabIndex = 2;
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(721, 424);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(75, 23);
            this.generateButton.TabIndex = 2;
            this.generateButton.Text = "Generate...";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // BlankCellBackgroundColorButton
            // 
            this.BlankCellBackgroundColorButton.Location = new System.Drawing.Point(75, 152);
            this.BlankCellBackgroundColorButton.Name = "BlankCellBackgroundColorButton";
            this.BlankCellBackgroundColorButton.Size = new System.Drawing.Size(123, 23);
            this.BlankCellBackgroundColorButton.TabIndex = 25;
            this.BlankCellBackgroundColorButton.Text = "Background Colour...";
            this.BlankCellBackgroundColorButton.UseVisualStyleBackColor = true;
            this.BlankCellBackgroundColorButton.Click += new System.EventHandler(this.BlankCellBackgroundColorButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.generateButton);
            this.Name = "MainForm";
            this.Text = "Perspective (Character Point-Of-View Charts)";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.settingsTab.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.TextBox povListTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage settingsTab;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Button cellBackgroundColorButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox subTitleTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox titleFontCombo;
        private System.Windows.Forms.ComboBox normalCellFontCombo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox normalCellFontSizeCombo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button normalCellTextColorButton;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox cellPaddingHorizontalText;
        private System.Windows.Forms.TextBox cellPaddingVerticalText;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox cellGapHorizontalText;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox cellGapVerticalText;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button activeCellTextColorButton;
        private System.Windows.Forms.Button activeCellBackgroundColorButton;
        private System.Windows.Forms.CheckBox blankCellPaintCheckBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BlankCellBackgroundColorButton;
    }
}

