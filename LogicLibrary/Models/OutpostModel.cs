using LogicLibrary.Modeller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLibrary.Models
{
    public class OutpostModel
    {
        public string Name { get; set; }
        public List<TaskModel> Tasks { get; set; }
        public string ReturnNameUnderscored()
        {
            string nameUnderscored = string.Empty;

            foreach(char c in Name)
            {
                if (c == ' ')
                {
                    nameUnderscored += "  ";
                }

                nameUnderscored += "_ ";
            }

            return nameUnderscored;
        }
        public string ReturnNameNoSpaces()
        {
            string nameNoSpaces = string.Empty;

            foreach(char c in Name)
            {
                if (c != ' ')
                {
                    nameNoSpaces += c;
                }
            }

            return nameNoSpaces;
        }
    }
}
