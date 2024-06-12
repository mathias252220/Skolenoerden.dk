using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QuestPDF.Helpers.Colors;

namespace LogicLibrary.Validators;
public class ContainsOnlyCertainCharsAttribute : ValidationAttribute
{
	public override bool IsValid(object value)
	{
		string strValue = value as string;
        strValue = strValue.Replace(" ", "");
		strValue = strValue.Replace(".", "");
		strValue = strValue.Replace(",", "");
        return strValue.All(char.IsLetterOrDigit);
	}
}

public class LengthModifiedAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
	{
		string strValue = value as string;
		strValue = strValue.Replace(" ", "");
		strValue = strValue.Replace(".", "");
		strValue = strValue.Replace(",", "");
		return (strValue.Length >= 1 && strValue.Length <= 16);
	}
}
