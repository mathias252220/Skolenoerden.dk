using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fractions;

namespace LogicLibrary.Modeller;

public class KeyModel
{
    public double KeyNumber { get; set; }
    public char KeyLetter { get; set; }
    public string getString()
    {
        string keyString = $"{KeyLetter} = {Fraction.FromDoubleRounded(KeyNumber)}";
        keyString = keyString.Replace('.', ',');
        return keyString;
    }
}
