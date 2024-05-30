using LogicLibrary.Modeller;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLibrary.Models
{
    public class OutpostModel
    {
        [Required(ErrorMessage = "En eller flere af dine poster mangler et navn")]
        public string Name { get; set; }
        public List<TaskModel> Tasks { get; set; } = new List<TaskModel>();
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
