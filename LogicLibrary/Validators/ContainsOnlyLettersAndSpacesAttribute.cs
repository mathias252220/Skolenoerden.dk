using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLibrary.Validators
{
	public class ContainsOnlyLettersAndSpacesAttribute : ValidationAttribute
	{
		public override bool IsValid(object value)
		{
			string strValue = value as string;
            strValue = strValue.Replace(" ", "");
            return strValue.All(char.IsLetter);
		}
	}
}
