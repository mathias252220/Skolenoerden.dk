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
		[ContainsOnlyCertainChars(ErrorMessage = "Dine poster må kun indeholde bogstaver, tal, mellemrum, punktum og komma")]
		[LengthModified(ErrorMessage = "Dine poster skal indeholde mellem 1 og 16 tegn (eksl. mellemrum, punktum og komma)")]
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
                else if (c == '.')
                {
                    nameUnderscored += ". ";
                }
                else if (c == ',')
                {
                    nameUnderscored += ", ";
                }
                else
                {
                    nameUnderscored += "_ ";
                }
            }

            return nameUnderscored;
        }
        public string ReturnNameOnlyChars()
        {
            string nameNoSpaces = string.Empty;

            foreach(char c in Name)
            {
                if (c != ' ' && c != '.' && c != ',')
                {
                    nameNoSpaces += c;
                }
            }

            return nameNoSpaces;
        }
    }
}
