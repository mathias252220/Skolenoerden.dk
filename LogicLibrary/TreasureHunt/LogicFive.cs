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
    public string taskTypes { get; set; } = "Elemental";

    public KeyPageModel CreateKeyPage()
    {
        KeyPageModel keyPage = new();
        Random rnd = new();
        bool unique;
        double number;
        AlphabetModel alphabet = new();
        alphabet.Alphabet = alphabet.CreateAlphabet();
        List<int> products = MathLogic.CreateProducts(50, 50);

        foreach (char c in alphabet.Alphabet)
        {
            KeyModel key = new();
            key.KeyLetter = c;

            do
            {
                unique = true;
                int answerTypeInt = rnd.Next(0, 4);

                // A whole non-prime number between 1 and 2500. Used for multiplication tasks.
                if (answerTypeInt == 0)
                {
                    number = Convert.ToDouble(products[rnd.Next(products.Count)]);
                }
                // A whole number between 10 and 100. Used for division tasks.
                else if (answerTypeInt == 1)
                {
                    number = Convert.ToDouble(rnd.Next(10, 101));
                }
                // A random number between 10 and 100 with 2 decimals. Used for addition and subtraction tasks.
                else
                {
                    do
                    {
                        number = Math.Round(rnd.NextDouble() * 100, 2);
                    }
                    while (number < 10);
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
            task.TaskType = TaskTypeEnum.Multiplication;
        }
        else
        {
            task.TaskType =(TaskTypeEnum)rnd.Next(0, 2);
        }

        switch (task.TaskType)
        {
            case TaskTypeEnum.Addition:
                CreateAddition(task, rnd);
                break;

            case TaskTypeEnum.Subtraction:
                CreateSubtraction(task, rnd);
                break;

            case TaskTypeEnum.Multiplication:
                CreateMultiplication(task, rnd, possibleFactors);
                break;

            case TaskTypeEnum.Division:
                CreateDivision(task, rnd);
                break;
        }

        return task;
    }

    private static void CreateAddition(TaskModel task, Random rnd)
    {
        do
        {
            task.VariableOne = Math.Round(rnd.NextDouble() * 100, 2);
        } while (task.VariableOne > task.Answer);

        task.VariableTwo = Math.Round(task.Answer - task.VariableOne, 2);
        task.Question = $"{task.VariableOne} + {task.VariableTwo} =";
        task.Question = task.Question.Replace('.', ',');
    }

    private static void CreateSubtraction(TaskModel task, Random rnd)
    {
        do
        {
            task.VariableOne = Math.Round(rnd.NextDouble() * 100, 2);
        } while (task.VariableOne < task.Answer);

        task.VariableTwo = Math.Round(task.VariableOne - task.Answer, 2);
        task.Question = $"{task.VariableOne} - {task.VariableTwo} =";
        task.Question = task.Question.Replace('.', ',');
    }

    private static void CreateMultiplication(TaskModel task, Random rnd, List<int> possibleFactors)
    {
        task.VariableOne = Convert.ToDouble(possibleFactors[rnd.Next(0, possibleFactors.Count)]);
        task.VariableTwo = task.Answer / task.VariableOne;
        task.Question = $"{task.VariableOne} · {task.VariableTwo} =";
        task.Question = task.Question.Replace('.', ',');
    }

    private static void CreateDivision(TaskModel task, Random rnd)
    {
        task.VariableOne = Convert.ToDouble(rnd.Next(2, 10));
        task.VariableTwo = task.Answer * task.VariableOne;
        task.Question = $"{task.VariableTwo} : {task.VariableOne} =";
        task.Question = task.Question.Replace('.', ',');
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
