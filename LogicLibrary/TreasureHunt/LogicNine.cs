using LogicLibrary.Modeller;
using LogicLibrary.Models;
using LogicLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fractions;
using System.Diagnostics;
using LogicLibrary.TaskGenerator;

namespace LogicLibrary.TreasureHunt;

public class LogicNine : ILogic
{
    public string grade { get; set; } = "GradeNine";
    public string taskTypes { get; set; } = "FractionEquation";

    public KeyPageModel CreateKeyPage()
    {
        KeyPageModel keyPage = new();
        Random rnd = new();
        bool unique;
        double number;
        AlphabetModel alphabet = new();
        alphabet.Alphabet = alphabet.CreateAlphabet();

        foreach (char c in alphabet.Alphabet)
        {
            KeyModel key = new();
            key.KeyLetter = c;

            do
            {
                unique = true;
                int answerTypeInt = rnd.Next(0, 2);

                //A whole number between 1 and 20
                if (answerTypeInt == 0)
                {
                    number = Convert.ToDouble(rnd.Next(1, 21));
                }

                //A reduced fraction with numerator and demoninator between 1 and 20
                else
                {
                    Fraction fraction = new Fraction(rnd.Next(1, 21), rnd.Next(1, 21));
                    number = (double)fraction;
                }

                foreach (KeyModel entry in keyPage.LetterKeys)
                {
                    if (entry.KeyNumber == number)
                    {
                        unique = false;
                    }
                }
            } while (unique == false);

            key.KeyNumber = number;
            keyPage.LetterKeys.Add(key);
        }

        return keyPage;
    }

    public TaskModel CreateTask(char letter, KeyPageModel keyPage)
    {
        TaskModel task = new();
        Random rnd = new();

        foreach (KeyModel key in keyPage.LetterKeys)
        {
            if (key.KeyLetter == char.ToUpper(letter))
            {
                task.Answer = key.KeyNumber;
            }
        }

        ITaskGenerator taskGenerator;

        if (task.Answer % 1 == 0)
        {
            taskGenerator = new EquationGenerator();
        }
        else
        {
            taskGenerator = new FractionGenerator();
        }

        return taskGenerator.CreateTaskNine(task.Answer);
    }

    public void PopulateOutpost(OutpostModel outpost, KeyPageModel keyPage)
    {
        outpost.Tasks.Clear();

        foreach (char letter in outpost.ReturnNameOnlyChars())
        {
            outpost.Tasks.Add(CreateTask(letter, keyPage));
        }
    }
}
