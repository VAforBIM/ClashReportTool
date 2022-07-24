using VA_Helpers.Methods;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VA_ClashReport
{
    public partial class ClashesForm : Form
    {
        public ClashesForm()
        {
            InitializeComponent();
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "TextFiles| *.txt";
            openFileDialog1.ShowDialog();
            FileLocationTextBox.Text = openFileDialog1.FileName;
        }

        private bool ValidateForm()
        {
            
            if( openFileDialog1.FileName.Length == 0)
            {
                // Надо загрзуить отчет кализии 
                MessageBox.Show("You need to load a clash report file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (Item1checkBox.Checked && Item2checkBox.Checked)
            {
                MessageBox.Show("You can't have two item checked at once, check only one of them.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Item1checkBox.CheckState = 0;
                Item2checkBox.CheckState = 0;
                return false;
            }
            if (!Item1checkBox.Checked && !Item2checkBox.Checked)
            {
                MessageBox.Show("You can't have items unchecked, check only one of them.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
           
            if(RangeTextBox.TextLength != 0)
            {
                if (rangefrom() == 999 || rangeto() == 0 || !RangeTextBox.Text.Contains("-"))
                {
                    MessageBox.Show("Please renter your ranges correctly ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    RangeTextBox.Text = "";
                    return false;
                }
            }
            return true;
        }
        private int rangefrom()
        {
            int output = 999;
            string[] cols = RangeTextBox.Text.Split('-');
            bool rangefromvalidnumber = int.TryParse(cols[0], out output);
            return output;
        }
        private int rangeto()
        {
            int output = 0;
            string[] cols = RangeTextBox.Text.Split('-');
            bool rangetovalidnumber = int.TryParse(cols[1], out output);
            return output;
        }

        private void CreateClashesButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                createclashinfo();
                Close();
            }
        }
        public ClashFromInfo createclashinfo()
        {
            ClashFromInfo info = new ClashFromInfo();
            if (Item1checkBox.Checked)
            {
                info.Itemnumber = 1;
            }
            else
            {
                info.Itemnumber = 2;
            }
            info.FilePath = FileLocationTextBox.Text;
            if (RangeTextBox.TextLength == 0)
            {
                info.RangeFrom = 0;
                info.RangeTo = 0;
            }
            else
            {
                info.RangeFrom = rangefrom();
                info.RangeTo = rangeto();
            }
                
            return info;
        }

        private void ClashesForm_Load(object sender, EventArgs e)
        {

        }
    }



    
}
