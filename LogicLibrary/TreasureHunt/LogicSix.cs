using LogicLibrary.Modeller;
using LogicLibrary.Models;
using LogicLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLibrary.TreasureHunt;

public class LogicSix : ILogic
{
    public string grade { get; set; } = "GradeSix";

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
                    number = Convert.ToDouble(rnd.Next(50, 251));
                }
                else
                {
                    do
                    {
                        number = Math.Round(rnd.NextDouble() * 1000, 2);
                    } while (number < 100);
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
            possibleFactors = MathLogic.GetFactors(Convert.ToInt16(task.Answer));
            possibleFactors = MathLogic.LimitOneFactor(possibleFactors, 100);
        }

        if (task.Answer < 100 && task.Answer % 1 == 0)
        {
            task.TaskType = TaskTypeEnum.Division;
        }
        else if (possibleFactors.Count > 0)
        {
            task.TaskType = TaskTypeEnum.Gange;
        }
        else
        {
            task.TaskType = (TaskTypeEnum)rnd.Next(0, 2);
        }

        switch (task.TaskType)
        {
            case TaskTypeEnum.Plus:
                do
                {
                    task.VariableOne = Math.Round(rnd.NextDouble() * 1000, 2);
                } while (task.VariableOne > task.Answer);

                task.VariableTwo = Math.Round(task.Answer - task.VariableOne, 2);
                task.Question = $"{task.VariableOne} + {task.VariableTwo} =";
                task.Question = task.Question.Replace('.', ',');
                break;

            case TaskTypeEnum.Minus:
                do
                {
                    task.VariableOne = Math.Round(rnd.NextDouble() * 1000, 2);
                } while (task.VariableOne < task.Answer);

                task.VariableTwo = Math.Round(task.VariableOne - task.Answer, 2);
                task.Question = $"{task.VariableOne} - {task.VariableTwo} =";
                task.Question = task.Question.Replace('.', ',');
                break;

            case TaskTypeEnum.Gange:
                task.VariableOne = Convert.ToDouble(possibleFactors[rnd.Next(0, possibleFactors.Count)]);
                task.VariableTwo = task.Answer / task.VariableOne;
                task.Question = $"{task.VariableOne} x {task.VariableTwo} =";
                task.Question = task.Question.Replace('.', ',');
                break;

            case TaskTypeEnum.Division:
                task.VariableOne = Convert.ToDouble(rnd.Next(2, 10));
                task.VariableTwo = task.Answer * task.VariableOne;
                task.Question = $"{task.VariableTwo} : {task.VariableOne} =";
                task.Question = task.Question.Replace('.', ',');
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
