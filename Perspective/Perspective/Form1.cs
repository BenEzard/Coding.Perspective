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
            m_chart = new PerspectiveChart(m_dataModel);

            m_chart.CELL_BACKGROUND_COLOR = Color.Yellow;
            m_chart.CELL_HORIZONTAL_SPACING = 10;
            m_chart.CELL_BORDER_WIDTH = 1;
            m_chart.CELL_HORIZONTAL_GAP = 5;
            m_chart.CELL_HORIZONTAL_SPACING = 10;
            m_chart.CELL_VERTICAL_GAP = 5;
            m_chart.CELL_VERTICAL_SPACING = 10;

            m_chart.initialise();


            m_chart.DrawImage();
        }

        private string GetCleanPerspectives() {
            string rValue = povListTextBox.Text;

            rValue = rValue.Trim(new char[] { '\r', '\n' });
            rValue = rValue.TrimEnd(' ');

            return rValue;
        }

    }
}
