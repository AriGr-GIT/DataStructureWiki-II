using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

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
        private static int currentIndex = 0;
        private string fileName = "Wiki.dat";

        private void FormDataStructureWiki_Load(object sender, EventArgs e)
        {
            PopulateDropdown();
            PopulateWiki();
            DisplayList();
        }

        #region util
        private void ClearAll()
        {
            textBoxName.Clear();
            comboBoxCategory.Text = "Category";
            radioButtonLinear.Checked = false;
            radioButtonNonLinear.Checked = false;
            textBoxDefiniton.Clear();
        }

        #endregion

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (ValidName(textBoxName.Text))
            {
                Information tempInfo = GetNewInformation();
                Wiki.Add(tempInfo);
                ClearAll();
            }
            else
                toolStripStatusLabel1.Text = textBoxName.Text + " Already Exists.";

            DisplayList();
        }

        private void PopulateDropdown()
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

        private string SelectedRadioButton()
        {
            string currentRadio = "";
            if (radioButtonLinear.Checked)
                currentRadio = "Linear";
            else if (radioButtonNonLinear.Checked)
                currentRadio = "Non-Linear";
            return currentRadio;
        }

        private void SelectRadioButton(string structure)
        {
            if (structure == "Linear")
                radioButtonLinear.Checked = true;
            else if (structure == "Non-Linear")
                radioButtonNonLinear.Checked = true;
            
        }

        private void DisplayList()
        {
            Wiki.Sort();
            listViewDefinitions.Clear();
            listViewDefinitions.MultiSelect = false;
            listViewDefinitions.View = View.Details;
            listViewDefinitions.FullRowSelect = true;
            listViewDefinitions.Columns.Add("Name", 80, HorizontalAlignment.Left);
            listViewDefinitions.Columns.Add("Category", 80, HorizontalAlignment.Left);
            foreach (Information info in Wiki)
            {
                ListViewItem colPop = new ListViewItem(info.getName);
                colPop.SubItems.Add(info.getCategory);
                listViewDefinitions.Items.Add(colPop);
            }
        }

        private void SelectedIndex()
        {
            ListView.SelectedIndexCollection indices = listViewDefinitions.SelectedIndices;
            currentIndex = indices[0];
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Yes, I want to delete this item", 
                "No, I do not want to delete this item", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
                Wiki.RemoveAt(currentIndex);
            DisplayList();
        }
        //just for testing
        private void PopulateWiki()
        {
            Information info1 = new Information();
            Information info2 = new Information();
            Information info3 = new Information();
            Information info4 = new Information();
            info1.setName("aa");
            info1.setCategory("Hash");
            info1.setStructure("Linear");
            info1.setDefinition("It is a");

            info2.setName("bb");
            info2.setCategory("Array");
            info2.setStructure("Linear");
            info2.setDefinition("It is b");

            info3.setName("cc");
            info3.setCategory("Graph");
            info3.setStructure("Non-Linear");
            info3.setDefinition("It is c");

            info4.setName("dd");
            info4.setCategory("List");
            info4.setStructure("Linear");
            info4.setDefinition("It is d");

            Wiki.Add(info1);
            Wiki.Add(info2);
            Wiki.Add(info3);
            Wiki.Add(info4);
        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            ClearAll();
            Information info = new Information();
            info.setName(textBoxSearch.Text);
            int index = Wiki.BinarySearch(info);
            if (index >= 0)
            {
                info = Wiki[index];
                toolStripStatusLabel1.Text = "Found: " + textBoxSearch.Text;
                textBoxName.Text = info.getName;
                comboBoxCategory.Text = info.getCategory;
                SelectRadioButton(info.getStructure);
                textBoxDefiniton.Text = info.getDefinition;
            }
            else
            {
                toolStripStatusLabel1.Text = "Could Not Find: " + textBoxSearch.Text;
            }
        }

        private void ListViewDefinitions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewDefinitions.SelectedItems.Count != 0)
            {
                SelectedIndex();
                textBoxName.Text = Wiki[currentIndex].getName;
                comboBoxCategory.Text = Wiki[currentIndex].getCategory;
                SelectRadioButton(Wiki[currentIndex].getStructure);
                textBoxDefiniton.Text = Wiki[currentIndex].getDefinition;
            }
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            Information tempInfo = GetNewInformation();
            SelectedIndex();
            Wiki[currentIndex] = tempInfo;
            ClearAll();
            DisplayList();
        }

        private Information GetNewInformation()
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

                tempInfo.setStructure(SelectedRadioButton());

                tempInfo.setDefinition(textBoxDefiniton.Text);
            }
            else
                toolStripStatusLabel1.Text = "Please enter a value for each field";

            return tempInfo;
        }

        private void TextBoxName_DoubleClick(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            using (var stream = File.Open(fileName, FileMode.Create))
            {
                using (var writer = new BinaryWriter(stream, Encoding.UTF8, false))
                {
                    foreach (var info in Wiki)
                    {
                        writer.Write(info.getName);
                        writer.Write(info.getCategory);
                        writer.Write(info.getStructure);
                        writer.Write(info.getCategory);
                    }
                }
                
            }
        }
    }
}
