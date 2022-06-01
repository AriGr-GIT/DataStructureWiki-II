using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataStructureWiki_II
{
    public partial class FormDataStructureWiki : Form
    {
        public FormDataStructureWiki()
        {
            InitializeComponent();
        }
        private List<Information> Wiki = new List<Information>();
        private string[] Categories = new string[6] {"Array", "List", "Tree", "Graph", "Abstract", "Hash"};

        private void FormDataStructureWiki_Load(object sender, EventArgs e)
        {
            populateDropdown();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Information tempInfo = new Information();
            if (!string.IsNullOrEmpty(textBoxName.Text) &&
                    (radioButtonLinear.Checked || radioButtonNonLinear.Checked) &&
                        !string.IsNullOrEmpty(textBoxDefiniton.Text))
            {
                if (ValidName(textBoxName.Text))
                    tempInfo.setName(textBoxName.Text);
                else
                    toolStripStatusLabel1.Text = textBoxName.Text + " already exists";

                tempInfo.setCategory(comboBoxCategory.Text);

                if (radioButtonLinear.Checked)
                    tempInfo.setStructure("Linear");
                if (radioButtonNonLinear.Checked)
                    tempInfo.setStructure("Non-Linear");

                tempInfo.setDefinition(textBoxDefiniton.Text);
            }
            else
                toolStripStatusLabel1.Text = "Please enter a value for each field";

            Wiki.Add(tempInfo);
        }

        private void populateDropdown()
        {
            comboBoxCategory.Items.Clear();
            for (int i = 0; i < 6; i++)
            {
                comboBoxCategory.Items.Add(Categories[i]);
            }
        }

        private bool ValidName(string currentName)
        {
            if (Wiki.Exists(x => x.getName == currentName))
            {
                return false;
            } 
            else
            {
                return true;
            }
        }

        #region util
        private void clearAll()
        {
            textBoxName.Clear();
            textBoxDefiniton.Clear();
        }


        #endregion

    }
}
