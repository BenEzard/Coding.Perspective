using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Perspective
{
    public partial class MainForm : Form
    {
        // Right spot? Or Program.cs?
        private DataModel m_dataModel = null;
        private PerspectiveChart m_chart = null;

        public MainForm()
        {
            InitializeComponent();
            povListTextBox.Text = "Terefi,Narrator,Terefi;"
            + "Three,Menas,Danyel,Terefi;"
            + "Menas,Captain Yates, Danyel, Captain Yates,Danyel;"
            + "Cameus,Jessica,Danyel,Captain Yates;"
            + "Danyel,Unnamed,Danyel,Danyel";

            cellBackgroundColorButton.BackColor = Color.FromArgb(153, 204, 255);
            BlankCellBackgroundColorButton.BackColor = Color.LightGray;
            titleTextBox.Text = "Vengeance Will Come (Draft)";

            object[] fontList = GetFontList();
            titleFontCombo.Items.AddRange(fontList);
            normalCellFontCombo.Items.AddRange(fontList);
            normalCellFontCombo.Text = "Calibri";
            object[] fontSizes = { 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22 };
            normalCellFontSizeCombo.Items.AddRange(fontSizes);
            normalCellFontSizeCombo.Text = "10";
        }

        /// <summary>
        /// Get the list of TrueType fonts.
        /// </summary>
        /// <returns></returns>
        private object[] GetFontList()
        {
            int fontCount = System.Drawing.FontFamily.Families.Length;
            object[] rValue = new object[fontCount];

            for (int counter = 0; counter < fontCount; counter++)
            {
                rValue[counter] = System.Drawing.FontFamily.Families[counter].Name;
            }
            return rValue;
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            // TODO: Check if there is any text in the field first.
            if (povListTextBox.Text.Length == 0)
            {
                DialogResult result = MessageBox.Show("You must have entered a list of Points-Of-View first", "I will not comply!", MessageBoxButtons.OK);
            }

            // Load the data into the model
            m_dataModel = new DataModel(GetCleanPerspectives());
            m_chart = new PerspectiveChart(m_dataModel, "","");

            m_chart.SetNormalCellStyle(cellBackgroundColorButton.BackColor, normalCellTextColorButton.ForeColor, new Font(new FontFamily(normalCellFontCombo.Text), Convert.ToSingle(normalCellFontSizeCombo.Text), FontStyle.Regular));
            m_chart.SetCellSpacing(int.Parse(cellGapHorizontalText.Text), int.Parse(cellGapHorizontalText.Text), 
                int.Parse(cellPaddingHorizontalText.Text), int.Parse(cellPaddingVerticalText.Text));
            m_chart.BlankCellPainting(blankCellPaintCheckBox.Checked, BlankCellBackgroundColorButton.BackColor);
            m_chart.CELL_BORDER_WIDTH = 1;
            m_chart.SetTitles(titleTextBox.Text, subTitleTextBox.Text);


            m_chart.initialise();

            pictureBox.Image = m_chart.DrawImage();
        }

        private string GetCleanPerspectives() {
            string rValue = povListTextBox.Text;

            rValue = rValue.Trim(new char[] { '\r', '\n' });
            rValue = rValue.TrimEnd(' ');

            return rValue;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                cellBackgroundColorButton.BackColor = colorDialog.Color;
            }            
        }

        private void normalCellTextColorButton_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                normalCellTextColorButton.ForeColor = colorDialog.Color;
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void BlankCellBackgroundColorButton_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                BlankCellBackgroundColorButton.BackColor = colorDialog.Color;
            }
        }
    }
}
