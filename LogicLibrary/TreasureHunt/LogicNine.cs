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

        if (task.Answer % 1 == 0)
        {
            task.TaskType = TaskTypeEnum.Equation;
        }
        else
        {
            task.TaskType = TaskTypeEnum.Fraction;
        }

        switch (task.TaskType)
        {
            case TaskTypeEnum.Equation:
                CreateEquation(task, rnd);
                break;

            case TaskTypeEnum.Fraction:
                CreateFraction(task, rnd);
                break;
        }

        return task;
    }

    private static void CreateEquation(TaskModel task, Random rnd)
    {
        int equationTypeInt = rnd.Next(0, 5);


        if (equationTypeInt == 0)
        {
            CreateEquationType0(task, rnd);
        }

        else if (equationTypeInt == 1)
        {
            CreateEquationType1(task, rnd);
        }

        else if (equationTypeInt == 2)
        {
            CreateEquationType2(task, rnd);
        }

        else if (equationTypeInt == 3)
        {
            CreateEquationType3(task, rnd);
        }

        else if (equationTypeInt == 4)
        {
            CreateEquationType4(task, rnd);
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
            CreateFractionType2(task, rnd, out variableOne, out variableTwo, answer);
        }
        // a/b : c/d =
        else if (fractionTypeInt == 3)
        {
            CreateFractionType3(task, rnd, out variableOne, out variableTwo, answer);
        }
    }

    private static void CreateEquationType0(TaskModel task, Random rnd)
    {
        // Equation of type a * (x + b) = c * x
        task.VariableOne = rnd.Next(1, 11);
        task.VariableTwo = rnd.Next(1, 11) * task.Answer;
        task.VariableThree = task.VariableOne * (task.Answer + task.VariableTwo) / task.Answer;

        task.Question = $"{task.VariableOne}(x + {task.VariableTwo}) = {task.VariableThree}x";
    }

    private static void CreateEquationType1(TaskModel task, Random rnd)
    {
        // Equation of type a + b * x = c * (x + d)
        task.VariableThree = rnd.Next(1, 11);
        task.VariableFour = rnd.Next(1, 11) * task.Answer;
        for (int i = 2; i <= (int)task.VariableThree * (int)task.VariableFour; i++)
        {
            task.VariableOne = task.VariableThree * task.VariableFour / i;
            if (task.VariableOne % 1 == 0)
            {
                task.VariableTwo = (task.VariableThree * (task.Answer + task.VariableFour) - task.VariableOne) / task.Answer;
                if (task.VariableTwo % 1 == 0)
                {
                    task.Question = $"{task.VariableOne} + {task.VariableTwo}x = {task.VariableThree}(x + {task.VariableFour})";
                    return;
                }
            }
        }
        throw new Exception("Equation type 1 not concluded properly.");
    }

    private static void CreateEquationType2(TaskModel task, Random rnd)
    {
        // Equation of type a + b * (x - c) = d * x
        task.VariableTwo = rnd.Next(1, 11);
        task.VariableThree = rnd.Next(1, 11) * task.Answer;
        for (int i = 2; i <= (int)task.VariableTwo * (int)task.VariableThree; i++)
        {
            task.VariableOne = task.VariableTwo * task.VariableThree / i;
            if (task.VariableOne % 1 == 0)
            {
                task.VariableFour = (task.VariableOne + task.VariableTwo * (task.Answer - task.VariableThree)) / task.Answer;
                if (task.VariableFour % 1 == 0)
                {
                    task.Question = $"{task.VariableOne} + {task.VariableTwo}(x - {task.VariableThree}) = {task.VariableFour}x";
                    return;
                }
            }
        }
        throw new Exception("Equation type 2 not concluded properly.");
    }

    private static void CreateEquationType3(TaskModel task, Random rnd)
    {
        // Equation of type a - b * (x + c) = d * x
        task.VariableTwo = rnd.Next(1, 11);
        task.VariableThree = rnd.Next(1, 11) * task.Answer;
        for (int i = 2; i <= (int)task.VariableTwo * (int)task.VariableThree; i++)
        {
            task.VariableOne = task.VariableTwo * task.VariableThree / i;
            if (task.VariableOne % 1 == 0)
            {
                task.VariableFour = (task.VariableOne - task.VariableTwo * (task.Answer + task.VariableThree)) / task.Answer;
                if (task.VariableFour % 1 == 0)
                {
                    task.Question = $"{task.VariableOne} - {task.VariableTwo}(x + {task.VariableThree}) = {task.VariableFour}x";
                    return;
                }
            }
        }
        throw new Exception("Equation type 3 not concluded properly.");
    }

    private static void CreateEquationType4(TaskModel task, Random rnd)
    {
        // Equation of type a * x = b - c * (x - d)
        task.VariableThree = rnd.Next(1, 11);
        task.VariableFour = rnd.Next(1, 11) * task.Answer;
        for (int i = 2; i <= (int)task.VariableThree * (int)task.VariableFour; i++)
        {
            task.VariableTwo = task.VariableThree * task.VariableFour / i;
            if (task.VariableTwo % 1 == 0)
            {
                task.VariableOne = (task.VariableTwo - task.VariableThree * (task.Answer - task.VariableFour)) / task.Answer;
                if ( task.VariableOne % 1 == 0)
                {
                    task.Question = $"{task.VariableOne}x = {task.VariableTwo} - {task.VariableThree}(x - {task.VariableFour})";
                    return;
                }

            }
        }
        throw new Exception("Equation type 4 not concluded properly.");
    }

    private static void CreateFractionType0(TaskModel task, Random rnd, out Fraction variableOne, out Fraction variableTwo, Fraction answer)
    {
        do
        {
            variableOne = new Fraction(rnd.Next(1, 21), rnd.Next(1, 22));
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
            variableOne = new Fraction(rnd.Next(1, 22), rnd.Next(1, 21));
        } while (variableOne < answer);
        task.VariableOne = (double)variableOne;
        variableTwo = variableOne - answer;
        task.VariableTwo = (double)variableTwo;
        task.Question = $"{variableOne} - {variableTwo} =";
    }
    
    private static void CreateFractionType2(TaskModel task, Random rnd, out Fraction variableOne, out Fraction variableTwo, Fraction answer)
    {
        variableOne = new Fraction(rnd.Next(1, 21), rnd.Next(1, 21));
        task.VariableOne = (double)variableOne;
        variableTwo = answer / variableOne;
        task.VariableTwo = (double)variableTwo;
        task.Question = $"{variableOne} · {variableTwo} =";
    }
    
    private static void CreateFractionType3(TaskModel task, Random rnd, out Fraction variableOne, out Fraction variableTwo, Fraction answer)
    {
        variableOne = new Fraction(rnd.Next(1, 21), rnd.Next(1, 21));
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
