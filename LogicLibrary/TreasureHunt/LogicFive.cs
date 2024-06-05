using LogicLibrary.Modeller;
using LogicLibrary.Models;
using LogicLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLibrary.TreasureHunt;

public class LogicFive : ILogic
{
    public string grade { get; set; } = "GradeFive";

    public KeyPageModel CreateKeyPage()
    {
        KeyPageModel keyPage = new();
        Random rnd = new();
        bool unique;
        double number;
        AlphabetModel alphabet = new();
        alphabet.Alphabet = alphabet.CreateAlphabet();
        List<int> products = MathLogic.CreateProducts(100, 100);

        foreach (char c in alphabet.Alphabet)
        {
            KeyModel key = new();
            key.KeyLetter = c;

            do
            {
                unique = true;
                int answerTypeInt = rnd.Next(0, 4);

                if (answerTypeInt == 0)
                {
                    number = Convert.ToDouble(products[rnd.Next(products.Count)]);
                }
                else if (answerTypeInt == 1)
                {
                    number = Convert.ToDouble(rnd.Next(10, 101));
                }
                else
                {
                    number = MathLogic.NextDouble(100, 1000, 2);
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

        List<int> possibleFactors = new();

        if (task.Answer % 1 == 0)
        {
            possibleFactors = MathLogic.GetFactors(Convert.ToInt32(task.Answer));
            possibleFactors = MathLogic.LimitOneFactor(possibleFactors, 100);
        }
        
        if (task.Answer < 100)
        {
            task.TaskType = TaskTypeEnum.Division;
        }
        else if (possibleFactors.Count > 0)
        {
            task.TaskType = TaskTypeEnum.Gange;
        }
        else
        {
            task.TaskType =(TaskTypeEnum)rnd.Next(0, 2);
        }

        switch (task.TaskType)
        {
            case TaskTypeEnum.Plus:
                task.VariableOne = MathLogic.NextDouble(10, Convert.ToInt32(task.Answer - 50), 2);
                task.VariableTwo = Math.Round(task.Answer - task.VariableOne, 2);
                task.Question = $"{task.VariableOne} + {task.VariableTwo} =";
                break;

            case TaskTypeEnum.Minus:
                task.VariableOne = MathLogic.NextDouble(Convert.ToInt32(task.Answer + 50), 1100, 2);
                task.VariableTwo = Math.Round(task.VariableOne - task.Answer, 2);
                task.Question = $"{task.VariableOne} - {task.VariableTwo} =";
                break;

            case TaskTypeEnum.Gange:
                task.VariableOne = Convert.ToDouble(possibleFactors[rnd.Next(0, possibleFactors.Count)]);
                task.VariableTwo = task.Answer / task.VariableOne;
                task.Question = $"{task.VariableOne} x {task.VariableTwo} =";
                break;

            case TaskTypeEnum.Division:
                task.VariableOne = Convert.ToDouble(rnd.Next(2, 10));
                task.VariableTwo = task.Answer * task.VariableOne;
                task.Question = $"{task.VariableTwo} : {task.VariableOne} =";
                break;
        }

        return task;
    }

    public void PopulateOutpost(OutpostModel outpost, KeyPageModel keyPage)
    {
        outpost.Tasks.Clear();

        foreach (char letter in outpost.ReturnNameNoSpaces())
        {
            outpost.Tasks.Add(CreateTask(letter, keyPage));
        }
    }
}
