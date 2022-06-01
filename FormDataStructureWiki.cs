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
using System.Diagnostics;

// Ari Graham
// 26/05/2022
// Data Structure Wiki II
// This program serves to be an interactable wiki containing a number of common data structure types and their associated information.
namespace DataStructureWiki_II
{
    public partial class FormDataStructureWiki : Form
    {
        public FormDataStructureWiki()
        {
            InitializeComponent();
        }
        // "6.2 Create a global List<T> of type Information called Wiki."
        private List<Information> Wiki = new List<Information>();
        // "6.4 Create and initialise a global string array with the six categories as indicated in the Data Structure Matrix.
        private string[] Categories = new string[6] {"Array", "List", "Tree", "Graph", "Abstract", "Hash"};
        // Static currentIndex variable serves to hold the index of whatever the currently selected item is.
        private static int currentIndex = 0;
        // Default file name
        private string defaultFileName = "default.bin";
        // "6.4 Create a custom method to populate the ComboBox when the Form Load method is called."
        private void FormDataStructureWiki_Load(object sender, EventArgs e)
        {
            PopulateDropdown();
            PopulateWiki();
            DisplayList();
        }
        // Quality of life method/s
        #region QOL
        // "6.12 Create a custom method that will clear and reset the TextBboxes, ComboBox and Radio button"
        private void ClearAll()
        {
            textBoxName.Clear();
            comboBoxCategory.Text = "Category";
            radioButtonLinear.Checked = false;
            radioButtonNonLinear.Checked = false;
            textBoxDefinition.Clear();
        }

        private void textBoxName_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text == "Name")
                textBoxName.Clear();
        }

        private void textBoxDefinition_Click(object sender, EventArgs e)
        {
            if (textBoxDefinition.Text == "Definition")
                textBoxDefinition.Clear();
        }

        #endregion
        // "6.3 Create a button method to ADD a new item to the list. Use a TextBox for the Name input, ComboBox for the Category,
        // Radio group for the Structure and Multiline TextBox for the Definition."
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxName.Text) && !string.IsNullOrEmpty(comboBoxCategory.Text) &&
                    !string.IsNullOrEmpty(textBoxDefinition.Text))
            {
                // Check to ensure entry doesnt already exist.
                if (ValidName(textBoxName.Text))
                {
                    Information tempInfo = GetNewInformation(); // Sets tempInfo var to whatever is currently entered into the inputs.
                    Wiki.Add(tempInfo); // Adds entry to list
                    ClearAll();
                    toolStripStatusLabel1.Text = "Succesfully Added " + textBoxName.Text;
                }
                else
                    toolStripStatusLabel1.Text = textBoxName.Text + " Already Exists.";
            }
            else
            {
                toolStripStatusLabel1.Text = "Please enter values into the text boxes.";
            }
            DisplayList();
        }
        // "6.4 Create a custom method to populate the ComboBox when the Form Load method is called."
        private void PopulateDropdown()
        {
            comboBoxCategory.Items.Clear();
            for (int i = 0; i < 6; i++)
            {
                comboBoxCategory.Items.Add(Categories[i]);
            }
        }
        // "6.5 Create a custom ValidName method which will take a parameter string value from the Textbox Name and returns a Boolean after checking for duplicates.
        // Use the built in List<T> method “Exists” to answer this requirement."
        private bool ValidName(string currentName)
        {
            Trace.WriteLine("Initial trace for ValidName method:");
            foreach (Information inf in Wiki)
            {
                Trace.WriteLine("Current Wiki Items: " + inf.getName);
            }
            Trace.WriteLine("Item currently being added: " + currentName);
            // Linq compares currentName string to each entry in wiki list and returns a bool dependant on whether it was found or not.
            if (Wiki.Exists(x => x.getName == currentName))
            {
                Trace.WriteLine("Item: " + currentName + " already exists, returning false.");
                return false;
            } 
            else
            {
                Trace.WriteLine("Item: " + currentName + " doesnt exist, returning true.");
                return true;
            }
        }
        // "6.6 Create two methods to highlight and return the values from the Radio button GroupBox.
        // The first method must return a string value from the selected radio button (Linear or Non-Linear)."
        private string SelectedRadioButton()
        {
            string currentRadio = "";
            if (radioButtonLinear.Checked)
                currentRadio = "Linear";
            else if (radioButtonNonLinear.Checked)
                currentRadio = "Non-Linear";
            return currentRadio;
        }
        // "6.6 Create two methods to highlight and return the values from the Radio button GroupBox.
        // The second method must send an integer index which will highlight an appropriate radio button."
        private void SelectRadioButton(string structure)
        {
            if (structure == "Linear")
                radioButtonLinear.Checked = true;
            else if (structure == "Non-Linear")
                radioButtonNonLinear.Checked = true;
            
        }
        // "6.9 Create a single custom method that will sort and then display the Name and Category from the wiki information in the list."
        private void DisplayList()
        {
            Wiki.Sort();
            listViewDefinitions.Clear();
            listViewDefinitions.MultiSelect = false; // Only one entry may be selected at a time.
            listViewDefinitions.View = View.Details; // Listview detail view.
            listViewDefinitions.FullRowSelect = true; // Sets listView to select all subitems in the row as well as parent item.
            // Formatted name and category columns.
            listViewDefinitions.Columns.Add("Name", 160, HorizontalAlignment.Left);
            listViewDefinitions.Columns.Add("Category", 80, HorizontalAlignment.Left);
            // Foreach loop adds each entry in wiki to the listView, name is input as parent item with category being entered as subitem.
            foreach (Information info in Wiki)
            {
                ListViewItem colPop = new ListViewItem(info.getName);
                colPop.SubItems.Add(info.getCategory);
                listViewDefinitions.Items.Add(colPop);
            }
        }
        // Selected index method is used to keep track of the currently selected row in the listview
        private void SelectedIndex()
        {
            ListView.SelectedIndexCollection indices = listViewDefinitions.SelectedIndices;
            currentIndex = indices[0];
        }
        // "6.10 Create a button method that will use the builtin binary search to find a Data Structure name.
        // If the record is found the associated details will populate the appropriate input controls and highlight the name in the ListView.
        private void SelectIndex(int index)
        {
            currentIndex = index;
            listViewDefinitions.Items[currentIndex].Selected = true;
        }
        // "6.7 Create a button method that will delete the currently selected record in the ListView.
        // Ensure the user has the option to backout of this action by using a dialog box.
        // Display an updated version of the sorted list at the end of this process."
        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            Trace.WriteLine("ButtonDelete initial trace\nCurrently Selected index: " + currentIndex.ToString());
            // Confirmation dialog box
            DialogResult dialogResult = MessageBox.Show("Do you really want to delete " + Wiki[currentIndex].getName, 
                "WARNING", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                toolStripStatusLabel1.Text = Wiki[currentIndex].getName + " Deleted";
                Trace.WriteLine("Message box, yes selected, deleting: " + Wiki[currentIndex].getName);
                Wiki.RemoveAt(currentIndex);
                
            }
                
            DisplayList();
        }
        //just for testing
        private void PopulateWiki()
        {
            Information info1 = new Information();
            Information info2 = new Information();
            Information info3 = new Information();
            Information info4 = new Information();
            Information info5 = new Information();
            Information info6 = new Information();
            Information info7 = new Information();
            Information info8 = new Information();
            Information info9 = new Information();
            Information info10 = new Information();
            Information info11 = new Information();
            Information info12 = new Information();
            info1.setName("Array");
            info1.setCategory("Array");
            info1.setStructure("Linear");
            info1.setDefinition("An array data structure consists of a collection of elements (values or variables), " +
                "each identified by at least one array index or key. An array is stored such that the position of each element can be computed from " +
                "its index tuple by a mathematical formula.");

            info2.setName("Two Dimensional Array");
            info2.setCategory("Array");
            info2.setStructure("Linear");
            info2.setDefinition("A two-dimensional array can be visualised as a grid (or table) with rows and columns. " +
                "Positions in a two dimensional array are referenced like a map using horizontal and vertical reference numbers. " +
                "They are sometimes called matrices.");

            info3.setName("List");
            info3.setCategory("List");
            info3.setStructure("Linear");
            info3.setDefinition("A list or sequence is an abstract data type that represents a finite number of ordered values, " +
                "where the same value may occur more than once.");

            info4.setName("Linked List");
            info4.setCategory("List");
            info4.setStructure("Linear");
            info4.setDefinition("A linked list is a linear collection of data elements whose order is not given by their physical placement in memory. " +
                "Instead, each element points to the next. It is a data structure consisting of a collection of nodes which together represent a sequence.");

            info5.setName("Self-Balance Tree");
            info5.setCategory("Tree");
            info5.setStructure("Non-Linear");
            info5.setDefinition("A self-balancing tree is any node-based binary search tree that automatically keeps its height " +
                "(maximal number of levels below the root) small in the face of arbitrary item insertions and deletions.");

            info6.setName("Heap");
            info6.setCategory("Tree");
            info6.setStructure("Non-Linear");
            info6.setDefinition("A heap is a specialized tree-based data structure which is essentially an almost complete tree that satisfies the " +
                "heap property. The heap is one maximally efficient implementation of an abstract data type called a priority queue, priority queues " +
                "are often referred to as 'heaps'.");

            info7.setName("Binary Search Tree");
            info7.setCategory("Tree");
            info7.setStructure("Non-Linear");
            info7.setDefinition("A binary search tree (BST), also called an ordered or sorted binary tree, is a rooted binary tree data structure whose " +
                "internal nodes each store a key greater than all the keys in the node’s left subtree and less than those in its right subtree.");

            info8.setName("Graph");
            info8.setCategory("Graphs");
            info8.setStructure("Non-Linear");
            info8.setDefinition("A graph data structure consists of a finite set of vertices, together with a set of unordered pairs of these vertices " +
                "for an undirected graph or a set of ordered pairs for a directed graph to implement the undirected graph and directed graph concepts " +
                "from the field of graph theory within mathematics.");

            info9.setName("Set");
            info9.setCategory("Abstract");
            info9.setStructure("Non-Linear");
            info9.setDefinition("A set is an abstract data type that can store unique values, without any particular order. It is a computer " +
                "implementation of the mathematical concept of a finite set. Unlike most other collection types, rather than retrieving a specific " +
                "element from a set, one typically tests a value for membership in a set.");

            info10.setName("Queue");
            info10.setCategory("Abstract");
            info10.setStructure("Linear");
            info10.setDefinition("A queue is a collection of entities that are maintained in a sequence and can be modified by the addition of " +
                "entities at one end of the sequence and the removal of entities from the other end of the sequence.");
            
            info11.setName("Stack");
            info11.setCategory("Abstract");
            info11.setStructure("Linear");
            info11.setDefinition("A stack is an abstract data type that serves as a collection of elements, with two main principal operations: " +
                "Push, which adds an element to the collection, and Pop, which removes the most recently added element that was not yet removed.");

            info12.setName("Hash Table");
            info12.setCategory("Hash");
            info12.setStructure("Non-Linear");
            info12.setDefinition("A hash table is a data structure that implements an associative array abstract data type, a structure that can map " +
                "keys to values. A hash table uses a hash function to compute an index, also called a hash code, into an array of buckets or slots, " +
                "from which the desired value can be found.");
           
            Wiki.Add(info1);
            Wiki.Add(info2);
            Wiki.Add(info3);
            Wiki.Add(info4);
            Wiki.Add(info5);
            Wiki.Add(info6);
            Wiki.Add(info7);
            Wiki.Add(info8);
            Wiki.Add(info9);
            Wiki.Add(info10);
            Wiki.Add(info11);
            Wiki.Add(info12);
        }
        // "6.10 Create a button method that will use the builtin binary search to find a Data Structure name.
        // If the record is found the associated details will populate the appropriate input controls and highlight the name in the ListView.
        // At the end of the search process the search input TextBox must be cleared."
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
                textBoxDefinition.Text = info.getDefinition;
                SelectIndex(index);
            }
            else
            {
                toolStripStatusLabel1.Text = "Could Not Find: " + textBoxSearch.Text;
            }
        }
        // "6.11 Create a ListView event so a user can select a Data Structure Name from the list of Names
        // and the associated information will be displayed in the related text boxes combo box and radio button."
        private void ListViewDefinitions_SelectedIndexChanged(object sender, EventArgs e)
        {
            // if statment prevents null errors while index is changing
            if (listViewDefinitions.SelectedItems.Count != 0)
            {
                SelectedIndex();
                textBoxName.Text = Wiki[currentIndex].getName;
                comboBoxCategory.Text = Wiki[currentIndex].getCategory;
                SelectRadioButton(Wiki[currentIndex].getStructure);
                textBoxDefinition.Text = Wiki[currentIndex].getDefinition;
            }
        }
        // "6.8 Create a button method that will save the edited record of the currently selected item in the ListView.
        // All the changes in the input controls will be written back to the list. Display an updated version of the sorted list at the end of this process."
        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            Trace.WriteLine("ButtonEdit_Click initial trace.");
            // tempInfo var set to whatever is currently input to text boxes.
            Information tempInfo = GetNewInformation();
            if (tempInfo.getName != null) 
            {
                // Gets index of currently selected item
                SelectedIndex();
                Trace.WriteLine("Currently selected item:\nIndex: " + currentIndex.ToString() + "\n" + Wiki[currentIndex].getName + "\n" + Wiki[currentIndex].getCategory + "\n" +
                    Wiki[currentIndex].getStructure + "\n" + Wiki[currentIndex].getDefinition);
                Trace.WriteLine("Editing selected item to:\n" + tempInfo.getName + "\n" + tempInfo.getCategory + "\n" + tempInfo.getStructure + "\n" +
                    tempInfo.getDefinition);
                Wiki[currentIndex] = tempInfo;
                Trace.WriteLine("Wiki item: " + currentIndex.ToString() + " Succesfully edited.");
                ClearAll();
                DisplayList();
            }
            else
            {
                Trace.WriteLine(textBoxName.Text + " Already exists");
                toolStripStatusLabel1.Text = textBoxName.Text + " Already Exists.";
            }
        }
        // GetNewInformation method assigns an Information type var to whatever is currently input in the text boxes.
        private Information GetNewInformation()
        {
            Information tempInfo = new Information();
            if (!string.IsNullOrEmpty(textBoxName.Text) &&
                    (radioButtonLinear.Checked || radioButtonNonLinear.Checked) &&
                        !string.IsNullOrEmpty(textBoxDefinition.Text))
            {
                if (ValidName(textBoxName.Text))
                    tempInfo.setName(textBoxName.Text);
                else
                    toolStripStatusLabel1.Text = textBoxName.Text + " already exists";

                tempInfo.setCategory(comboBoxCategory.Text);

                tempInfo.setStructure(SelectedRadioButton());

                tempInfo.setDefinition(textBoxDefinition.Text);
            }
            else
                toolStripStatusLabel1.Text = "Please enter a value for each field";

            return tempInfo;
        }
        // "6.13 Create a double click event on the Name TextBox to clear the TextBboxes, ComboBox and Radio button."
        private void TextBoxName_DoubleClick(object sender, EventArgs e)
        {
            ClearAll();
        }
        // "6.14 Create two buttons for the manual open and save option; this must use a dialog box to select a file or rename a saved file.
        // All Wiki data is stored/retrieved using a binary file format."
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            // Opens Save dialog box.
            SaveFileDialog saveFileDialogVG = new SaveFileDialog();
            saveFileDialogVG.Filter = "bin file|*.bin"; // Only allows .bin files to be saved.
            saveFileDialogVG.Title = "Save a BIN File"; 
            saveFileDialogVG.InitialDirectory = Application.StartupPath; 
            saveFileDialogVG.DefaultExt = "bin"; // Default extension
            saveFileDialogVG.FileName = defaultFileName; // Default filename
            saveFileDialogVG.ShowDialog();

            string fileName = saveFileDialogVG.FileName; // Sets fileName string to currently input file name
            // if a file name is input, uses that file name
            if (saveFileDialogVG.FileName != "" || saveFileDialogVG.FileName != null)
            {
                SaveEntry(fileName);
            } 
            else // default file name if none is input
            {
                SaveEntry(defaultFileName);
            }
            toolStripStatusLabel1.Text = "Successfully Saved " + fileName;
        }
        // Save method for save button.
        private void SaveEntry(string saveFileName)
        {
            try
            {
                // Creates file with input name
                using (var stream = File.Open(saveFileName, FileMode.Create)) 
                {
                    using (var writer = new BinaryWriter(stream, Encoding.UTF8, false))
                    {
                        foreach (var info in Wiki) // Adds each entry in Wiki list to bin file
                        {
                            writer.Write(info.getName);
                            writer.Write(info.getCategory);
                            writer.Write(info.getStructure);
                            writer.Write(info.getDefinition);
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error Saving: " + ex.ToString());
            }
        }
        // "6.14 Create two buttons for the manual open and save option; this must use a dialog box to select a file or rename a saved file.
        // All Wiki data is stored/retrieved using a binary file format."
        private void ButtonOpen_Click(object sender, EventArgs e)
        {
            // Opens the open file dialog
            OpenFileDialog openFileDialogVG = new OpenFileDialog();
            openFileDialogVG.InitialDirectory = Application.StartupPath; // Default directory
            openFileDialogVG.Filter = "Bin Files|*.bin"; // Filters to only bin files
            openFileDialogVG.Title = "Select a BIN File";
            if (openFileDialogVG.ShowDialog() == DialogResult.OK)
            {
                OpenRecord(openFileDialogVG.FileName);
            }
        }
        // Open method for open button.
        private void OpenRecord(string openFileName)
        {
            if (File.Exists(openFileName))
            {
                // Opens file with input name
                using (var stream = File.Open(openFileName, FileMode.Open))
                {
                    using (var reader = new BinaryReader(stream, Encoding.UTF8, false))
                    {
                        Wiki.Clear(); // Clears wiki list to reload from file
                        while (stream.Position < stream.Length)
                        {
                            Information infoRead = new Information();
                            infoRead.setName(reader.ReadString());
                            infoRead.setCategory(reader.ReadString());
                            infoRead.setStructure(reader.ReadString());
                            infoRead.setDefinition(reader.ReadString());
                            Wiki.Add(infoRead);
                        }
                    }
                }
            }
            DisplayList();
            toolStripStatusLabel1.Text = "Successfully Opened " + openFileName;
        }
        // "6.15 The Wiki application will save data when the form closes. "
        private void FormDataStructureWiki_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveEntry(defaultFileName);
        }

        
    }
}
