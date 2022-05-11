using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureWiki_II
{
    internal class Information //: IComparable<Information>
    {
        private string name;
        private string category;
        private string structure;
        private string definition;

        public string getName { get { return name; } }
        public string getCategory { get { return category; } }
        public string getStructure { get { return structure; } }
        public string getDefinition { get { return definition; } }

        public void setName(string newName) { this.name = newName; }
        public void setCategory(string newCategory) { this.category = newCategory; }
        public void setStructure(string newStructure) { this.structure = newStructure; }
        public void setDefinition(string newDefinition) { this.definition = newDefinition; }


    }
}
