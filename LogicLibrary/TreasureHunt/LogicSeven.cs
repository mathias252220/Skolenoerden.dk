using LogicLibrary.Modeller;
using LogicLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fractions;
using LogicLibrary.Enums;
using LogicLibrary.TaskGenerator;

namespace LogicLibrary.TreasureHunt;
public class LogicSeven : ILogic
{
    public string grade { get; set; } = "GradeSeven";
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

                //A whole number between 1 and 50
                if (answerTypeInt == 0)
                {
                    number = (double)rnd.Next(1, 51);
                }

                //A reduced fraction with numerator and denominator between 1 and 10
                else
                {
                    Fraction fraction = new Fraction(rnd.Next(1, 11), rnd.Next(1, 11));
                    number = (double)fraction;
                }

                //Check if the number is already used
                foreach(KeyModel entry in keyPage.LetterKeys)
                {
                    if (entry.KeyNumber == number)
                    {
                        unique = false;
                    }
                }
            } while(unique == false);

            key.KeyNumber = number;
            keyPage.LetterKeys.Add(key);
        }

        return keyPage;
    }

    public TaskModel CreateTask(char letter, KeyPageModel keyPage)
    {
        TaskModel task = new();
        Random rnd = new();

        foreach(KeyModel key in keyPage.LetterKeys)
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

        return taskGenerator.CreateTaskSeven(task.Answer);
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
