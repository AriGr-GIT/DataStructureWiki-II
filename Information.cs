using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureWiki_II
{
    internal class Information : IComparable<Information>
    {
        // "6.1 Create a separate class file to hold the four data items of the Data Structure (use the Data Structure Matrix as a guide).
        // Use auto-implemented properties for the fields which must be of type “string”. Save the class as “Information.cs”."
        // Class variables outlining properties of a given data structure
        private string name;
        private string category;
        private string structure;
        private string definition;

        public Information()
        {

        }
        // Getters
        public string getName { get { return name; } }
        public string getCategory { get { return category; } }
        public string getStructure { get { return structure; } }
        public string getDefinition { get { return definition; } }
        // Setters
        public void setName(string newName) { this.name = newName; }
        public void setCategory(string newCategory) { this.category = newCategory; }
        public void setStructure(string newStructure) { this.structure = newStructure; }
        public void setDefinition(string newDefinition) { this.definition = newDefinition; }
        // Default comparitor set to name property
        public int CompareTo(Information other)
        {
            return this.name.CompareTo(other.name);
        }
    }
}
