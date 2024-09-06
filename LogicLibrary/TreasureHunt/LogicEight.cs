using LogicLibrary.Modeller;
using LogicLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fractions;

namespace LogicLibrary.TreasureHunt;
public class LogicEight : ILogic
{
    public string grade { get; set; } = "GradeEight";
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
                int answerTypeInt = rnd.Next(0, 3);

                //A whole number between 1 and 100
                if (answerTypeInt == 0)
                {
                    number = (double)(rnd.Next(1, 100));
                }

                //A reduced fraction with numerator and demoninator between 1 and 10
                else
                {
                    Fraction fraction = new Fraction(rnd.Next(1, 11), rnd.Next(1, 11));
                    number = (double)fraction;
                }

                //Check if the number is already used
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

        foreach(KeyModel key in keyPage.LetterKeys)
        {
            if (key.KeyLetter == char.ToUpper(letter))
            {
                task.Answer = key.KeyNumber;
            }
        }

        if (task.Answer % 1 == 0)
        {
            task.TaskType = Enums.TaskTypeEnum.Equation;
        }
        else
        {
            task.TaskType = Enums.TaskTypeEnum.Fraction;
        }

        switch (task.TaskType)
        {
            case Enums.TaskTypeEnum.Equation:
                CreateEquation(task, rnd);
                break;

            case Enums.TaskTypeEnum.Fraction:
                CreateFraction(task, rnd);
                break;
        }
        return task;
    }

    private static void CreateEquation(TaskModel task, Random rnd)
    {
        int equationTypeInt = rnd.Next(0, 6);
        // Equation of type a + (x + b) = c
        if (equationTypeInt == 0)
        {
            CreateEquationType0(task, rnd);
        }
        // Equation of type a + (x - b) = c
        else if (equationTypeInt == 1)
        {
            CreateEquationType1(task, rnd);
        }
        // Equation of type a - (x + b) = c
        else if (equationTypeInt == 2)
        {
            CreateEquationType2(task, rnd);
        }
        // Equation of type a - (x - b) = c
        else if (equationTypeInt == 3)
        {
            CreateEquationType3(task, rnd);
        }
        // Equation of type a * (x + b) = c
        else if (equationTypeInt == 4)
        {
            CreateEquationType4(task, rnd);
        }
        // Equation of type a * (x - b) = c
        else if (equationTypeInt == 5)
        {
            CreateEquationType5(task, rnd);
        }
    }

    private static void CreateFraction(TaskModel task, Random rnd)
    {
        int fractionTypeInt = rnd.Next(0, 4);

        Fraction variableOne;
        Fraction variableTwo;
        Fraction answer = Fraction.FromDoubleRounded(task.Answer);

        // a/b + c/d =
        if (fractionTypeInt == 0)
        {
            CreateFractionType0(task, rnd, out variableOne, out variableTwo, answer);
        }
        // a/b - c/d =
        else if (fractionTypeInt == 1)
        {
            CreateFractionType1(task, rnd, out variableOne, out variableTwo, answer);
        }
        // a/b * c/d =
        else if (fractionTypeInt == 2)
        {
            CreateFraction2(task, rnd, out variableOne, out variableTwo, answer);
        }
        // a/b : c/d =
        else if (fractionTypeInt == 3)
        {
            CreateFractionType3(task, rnd, out variableOne, out variableTwo, answer);
        }
    }

    private static void CreateEquationType0(TaskModel task, Random rnd)
    {
        task.VariableOne = rnd.Next(1, 51);
        task.VariableTwo = rnd.Next(1, 51);
        task.VariableThree = task.VariableOne + task.Answer + task.VariableTwo;
        task.Question = $"{task.VariableOne} + (x + {task.VariableTwo}) = {task.VariableThree}";
    }

    private static void CreateEquationType1(TaskModel task, Random rnd)
    {
        task.VariableOne = rnd.Next(1, 51);
        task.VariableTwo = rnd.Next(1, 51);
        task.VariableThree = task.VariableOne + task.Answer - task.VariableTwo;
        task.Question = $"{task.VariableOne} + (x - {task.VariableTwo}) = {task.VariableThree}";
    }

    private static void CreateEquationType2(TaskModel task, Random rnd)
    {
        task.VariableOne = rnd.Next(1, 51);
        task.VariableTwo = rnd.Next(1, 51);
        task.VariableThree = task.VariableOne - task.Answer - task.VariableTwo;
        task.Question = $"{task.VariableOne} - (x + {task.VariableTwo}) = {task.VariableThree}";
    }

    private static void CreateEquationType3(TaskModel task, Random rnd)
    {
        task.VariableOne = rnd.Next(1, 51);
        task.VariableTwo = rnd.Next(1, 51);
        task.VariableThree = task.VariableOne - task.Answer + task.VariableTwo;
        task.Question = $"{task.VariableOne} - (x - {task.VariableTwo}) = {task.VariableThree}";
    }

    private static void CreateEquationType4(TaskModel task, Random rnd)
    {
        task.VariableOne = rnd.Next(1, 11);
        task.VariableTwo = rnd.Next(1, 51);
        task.VariableThree = task.VariableOne * (task.Answer + task.VariableTwo);
        task.Question = $"{task.VariableOne}(x + {task.VariableTwo}) = {task.VariableThree}";
    }

    private static void CreateEquationType5(TaskModel task, Random rnd)
    {
        task.VariableOne = rnd.Next(1, 11);
        task.VariableTwo = rnd.Next(1, 51);
        task.VariableThree = task.VariableOne * (task.Answer - task.VariableTwo);
        task.Question = $"{task.VariableOne}(x - {task.VariableTwo}) = {task.VariableThree}";
    }

    private static void CreateFractionType0(TaskModel task, Random rnd, out Fraction variableOne, out Fraction variableTwo, Fraction answer)
    {
        do
        {
            variableOne = new Fraction(rnd.Next(1, 11), rnd.Next(1, 12));
        } while (variableOne > answer);
        task.VariableOne = (double)variableOne;
        variableTwo = answer - variableOne;
        task.VariableTwo = (double)variableTwo;
        task.Question = $"{variableOne} + {variableTwo} =";
    }

    private static void CreateFractionType1(TaskModel task, Random rnd, out Fraction variableOne, out Fraction variableTwo, Fraction answer)
    {
        do
        {
            variableOne = new Fraction(rnd.Next(1, 12), rnd.Next(1, 11));
        } while (variableOne < answer);
        task.VariableOne = (double)variableOne;
        variableTwo = variableOne - answer;
        task.VariableTwo = (double)variableTwo;
        task.Question = $"{variableOne} - {variableTwo} =";
    }

    private static void CreateFraction2(TaskModel task, Random rnd, out Fraction variableOne, out Fraction variableTwo, Fraction answer)
    {
        variableOne = new Fraction(rnd.Next(1, 11), rnd.Next(1, 11));
        task.VariableOne = (double)variableOne;
        variableTwo = answer / variableOne;
        task.VariableTwo = (double)variableTwo;
        task.Question = $"{variableOne} · {variableTwo} =";
    }

    private static void CreateFractionType3(TaskModel task, Random rnd, out Fraction variableOne, out Fraction variableTwo, Fraction answer)
    {
        variableOne = new Fraction(rnd.Next(1, 11), rnd.Next(1, 11));
        task.VariableOne = (double)variableOne;
        variableTwo = variableOne / answer;
        task.VariableTwo = (double)variableTwo;
        task.Question = $"{variableOne} : {variableTwo} =";
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
