using LogicLibrary.Modeller;
using LogicLibrary.Validators;
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
        [Required(ErrorMessage = "Posten mangler et navn")]
		[ContainsOnlyLettersAndSpaces(ErrorMessage = "Dine poster må kun indeholde bogstaver og mellemrum")]
		[Length(1, 20, ErrorMessage = "Dine poster skal indeholde mellem 1 og 20 tegn (inkl. mellemrum)")]
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
                else
                {
                    nameUnderscored += "_ ";
                }
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
