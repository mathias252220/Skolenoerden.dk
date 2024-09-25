using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QuestPDF.Helpers.Colors;

namespace LogicLibrary.Validators;
public class EnumNotZeroAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        int intValue = (int)value;

        return intValue != 0;
    }
}