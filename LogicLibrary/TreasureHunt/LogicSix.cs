using LogicLibrary.Modeller;
using LogicLibrary.Models;
using LogicLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLibrary.TaskGenerator;

namespace LogicLibrary.TreasureHunt;

public class LogicSix : ILogic
{
    public string grade { get; set; } = "GradeSix";
    public string taskTypes { get; set; } = "Elemental";

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
                int answerTypeInt = rnd.Next(0, 3);

                //A whole non-prime number between 1 and 10000. Used for multiplication tasks.
                if (answerTypeInt == 0)
                {
                    number = Convert.ToDouble(products[rnd.Next(products.Count)]);
                }
                // A whole number between 50 and 250. Used for division tasks.
                else if (answerTypeInt == 1)
                {
                    number = Convert.ToDouble(rnd.Next(50, 251));
                }
                // A random number between 100 and 1000 with 2 decimals. Used for addition and subtraction tasks.
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
            possibleFactors = MathLogic.LimitTwoFactors(possibleFactors, 100, (int)task.Answer);
        }

        ITaskGenerator taskGenerator;

        if (task.Answer < 251 && task.Answer % 1 == 0)
        {
            task.TaskType = TaskTypeEnum.Division;
        }
        else if (possibleFactors.Count > 0)
        {
            task.TaskType = TaskTypeEnum.Multiplication;
        }
        else
        {
            task.TaskType = (TaskTypeEnum)rnd.Next(1, 3);
        }

        if (task.TaskType == TaskTypeEnum.Addition)
        {
            taskGenerator = new AdditionGenerator();
        }
        else if (task.TaskType == TaskTypeEnum.Subtraction)
        {
            taskGenerator = new SubtractionGenerator();
        }
        else if (task.TaskType == TaskTypeEnum.Multiplication)
        {
            taskGenerator = new MultiplicationGenerator();
        }
        else if (task.TaskType == TaskTypeEnum.Division)
        {
            taskGenerator = new DivisionGenerator();
        }
        else
        {
            throw new Exception("Error occured: Task type does not exist in grade six.");
        }

        return taskGenerator.CreateTaskSix(task.Answer);
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
