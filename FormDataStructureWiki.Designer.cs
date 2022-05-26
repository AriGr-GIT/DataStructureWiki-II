namespace DataStructureWiki_II
{
    partial class FormDataStructureWiki
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
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.comboBoxCategory = new System.Windows.Forms.ComboBox();
            this.groupBoxStructure = new System.Windows.Forms.GroupBox();
            this.radioButtonNonLinear = new System.Windows.Forms.RadioButton();
            this.radioButtonLinear = new System.Windows.Forms.RadioButton();
            this.textBoxDefiniton = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.listViewDefinitions = new System.Windows.Forms.ListView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBoxStructure.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(13, 12);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(110, 47);
            this.buttonAdd.TabIndex = 0;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(141, 12);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(110, 47);
            this.buttonEdit.TabIndex = 1;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.ButtonEdit_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(267, 12);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(110, 47);
            this.buttonDelete.TabIndex = 2;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(566, 26);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(160, 20);
            this.textBoxSearch.TabIndex = 3;
            this.textBoxSearch.Text = "Search...";
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(738, 18);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(50, 34);
            this.buttonSearch.TabIndex = 4;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.ButtonSearch_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(12, 65);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(238, 20);
            this.textBoxName.TabIndex = 5;
            this.textBoxName.Text = "Name";
            this.textBoxName.DoubleClick += new System.EventHandler(this.TextBoxName_DoubleClick);
            // 
            // comboBoxCategory
            // 
            this.comboBoxCategory.FormattingEnabled = true;
            this.comboBoxCategory.Location = new System.Drawing.Point(12, 92);
            this.comboBoxCategory.MaxDropDownItems = 6;
            this.comboBoxCategory.Name = "comboBoxCategory";
            this.comboBoxCategory.Size = new System.Drawing.Size(238, 21);
            this.comboBoxCategory.TabIndex = 6;
            this.comboBoxCategory.Text = "Category";
            // 
            // groupBoxStructure
            // 
            this.groupBoxStructure.Controls.Add(this.radioButtonNonLinear);
            this.groupBoxStructure.Controls.Add(this.radioButtonLinear);
            this.groupBoxStructure.Location = new System.Drawing.Point(12, 120);
            this.groupBoxStructure.Name = "groupBoxStructure";
            this.groupBoxStructure.Size = new System.Drawing.Size(238, 74);
            this.groupBoxStructure.TabIndex = 7;
            this.groupBoxStructure.TabStop = false;
            this.groupBoxStructure.Text = "Structure";
            // 
            // radioButtonNonLinear
            // 
            this.radioButtonNonLinear.AutoSize = true;
            this.radioButtonNonLinear.Location = new System.Drawing.Point(129, 32);
            this.radioButtonNonLinear.Name = "radioButtonNonLinear";
            this.radioButtonNonLinear.Size = new System.Drawing.Size(77, 17);
            this.radioButtonNonLinear.TabIndex = 1;
            this.radioButtonNonLinear.TabStop = true;
            this.radioButtonNonLinear.Text = "Non-Linear";
            this.radioButtonNonLinear.UseVisualStyleBackColor = true;
            // 
            // radioButtonLinear
            // 
            this.radioButtonLinear.AutoSize = true;
            this.radioButtonLinear.Location = new System.Drawing.Point(6, 32);
            this.radioButtonLinear.Name = "radioButtonLinear";
            this.radioButtonLinear.Size = new System.Drawing.Size(54, 17);
            this.radioButtonLinear.TabIndex = 0;
            this.radioButtonLinear.TabStop = true;
            this.radioButtonLinear.Text = "Linear";
            this.radioButtonLinear.UseVisualStyleBackColor = true;
            // 
            // textBoxDefiniton
            // 
            this.textBoxDefiniton.Location = new System.Drawing.Point(13, 200);
            this.textBoxDefiniton.Multiline = true;
            this.textBoxDefiniton.Name = "textBoxDefiniton";
            this.textBoxDefiniton.Size = new System.Drawing.Size(364, 183);
            this.textBoxDefiniton.TabIndex = 8;
            this.textBoxDefiniton.Text = "Definition";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(13, 391);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(110, 47);
            this.buttonSave.TabIndex = 9;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(267, 391);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(110, 47);
            this.buttonOpen.TabIndex = 10;
            this.buttonOpen.Text = "Open";
            this.buttonOpen.UseVisualStyleBackColor = true;
            // 
            // listViewDefinitions
            // 
            this.listViewDefinitions.HideSelection = false;
            this.listViewDefinitions.Location = new System.Drawing.Point(393, 65);
            this.listViewDefinitions.Name = "listViewDefinitions";
            this.listViewDefinitions.Size = new System.Drawing.Size(395, 373);
            this.listViewDefinitions.TabIndex = 11;
            this.listViewDefinitions.UseCompatibleStateImageBehavior = false;
            this.listViewDefinitions.SelectedIndexChanged += new System.EventHandler(this.ListViewDefinitions_SelectedIndexChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 449);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // FormDataStructureWiki
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 471);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.listViewDefinitions);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxDefiniton);
            this.Controls.Add(this.groupBoxStructure);
            this.Controls.Add(this.comboBoxCategory);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonAdd);
            this.Name = "FormDataStructureWiki";
            this.Text = "Data Structure Wiki";
            this.Load += new System.EventHandler(this.FormDataStructureWiki_Load);
            this.groupBoxStructure.ResumeLayout(false);
            this.groupBoxStructure.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.ComboBox comboBoxCategory;
        private System.Windows.Forms.GroupBox groupBoxStructure;
        private System.Windows.Forms.RadioButton radioButtonNonLinear;
        private System.Windows.Forms.RadioButton radioButtonLinear;
        private System.Windows.Forms.TextBox textBoxDefiniton;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.ListView listViewDefinitions;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}

