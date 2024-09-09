﻿using LogicLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LogicLibrary.TaskGenerator;
public class SubtractionGenerator : ITaskGenerator
{
    public TaskModel CreateTaskZero()
    {
        throw new Exception(errorMessage);
    }

    public TaskModel CreateTaskZero(double taskAnswer)
    {
        throw new Exception(errorMessage);
    }

    public TaskModel CreateTaskOne()
    {
        Random rnd = new();

        //Answer is a whole number between 1 and 100.
        double taskAnswer = rnd.Next(1, 101);

        TaskModel task = CreateSubtraction(taskAnswer, 100, 0);

        return task;
    }

    public TaskModel CreateTaskOne(double taskAnswer)
    {
        TaskModel task = CreateSubtraction(taskAnswer, 100, 0);

        return task;
    }

    public TaskModel CreateTaskTwo()
    {
        return CreateTaskOne();
    }

    public TaskModel CreateTaskTwo(double taskAnswer)
    {
        return CreateTaskOne(taskAnswer);
    }

    public TaskModel CreateTaskThree()
    {
        Random rnd = new();

        //Answer is a whole number between 1 and 1000.
        double taskAnswer = rnd.Next(1, 1001);

        TaskModel task = CreateSubtraction(taskAnswer, 1000, 0);

        return task;
    }

    public TaskModel CreateTaskThree(double taskAnswer)
    {
        TaskModel task = CreateSubtraction(taskAnswer, 1000, 0);

        return task;
    }

    public TaskModel CreateTaskFour()
    {
        return CreateTaskThree();
    }

    public TaskModel CreateTaskFour(double taskAnswer)
    {
        return CreateTaskThree(taskAnswer);
    }

    public TaskModel CreateTaskFive()
    {
        Random rnd = new();

        //Answer is a random number between 10 and 100 with 2 decimals.
        double taskAnswer;
        do
        {
            taskAnswer = Math.Round(rnd.NextDouble() * 100, 2);
        }
        while (taskAnswer < 10);

        TaskModel task = CreateSubtraction(taskAnswer, 100, 2);

        return task;
    }

    public TaskModel CreateTaskFive(double taskAnswer)
    {
        TaskModel task = CreateSubtraction(taskAnswer, 100, 2);

        return task;
    }

    public TaskModel CreateTaskSix()
    {
        Random rnd = new();

        //Answer is a random number between 100 and 1000 with 2 decimals.
        double taskAnswer;
        do
        {
            taskAnswer = Math.Round(rnd.NextDouble() * 1000, 2);
        } while (taskAnswer < 100);

        TaskModel task = CreateSubtraction(taskAnswer, 1000, 2);

        return task;
    }

    public TaskModel CreateTaskSix(double taskAnswer)
    {
        TaskModel task = CreateSubtraction(taskAnswer, 1000, 2);

        return task;
    }

    public TaskModel CreateTaskSeven()
    {
        throw new Exception(errorMessage);
    }

    public TaskModel CreateTaskSeven(double taskAnswer)
    {
        throw new Exception(errorMessage);
    }

    public TaskModel CreateTaskEight()
    {
        throw new Exception(errorMessage);
    }

    public TaskModel CreateTaskEight(double taskAnswer)
    {
        throw new Exception(errorMessage);
    }

    public TaskModel CreateTaskNine()
    {
        throw new Exception(errorMessage);
    }

    public TaskModel CreateTaskNine(double taskAnswer)
    {
        throw new Exception(errorMessage);
    }

    private static TaskModel CreateSubtraction(double answer, double maxValue, int decimalDigits)
    {
        Random rnd = new();
        TaskModel task = new();

        task.TaskType = Enums.TaskTypeEnum.Subtraction;
        task.Answer = answer;

        if (decimalDigits > 0)
        {
            double tempVariable;
            do
            {
                tempVariable = Math.Round(rnd.NextDouble() * maxValue, decimalDigits);
            } while (tempVariable < task.Answer);

            task.VariableOne = tempVariable;
            task.VariableTwo = Math.Round(task.VariableOne - task.Answer, decimalDigits);
        }
        else
        {
            task.VariableOne = rnd.Next(Convert.ToInt16(task.Answer), (int)maxValue);
            task.VariableTwo = task.VariableOne - task.Answer;
        }
        task.Question = $"{task.VariableOne} - {task.VariableTwo} =";
        task.Question = task.Question.Replace('.', ',');

        return task;
    }

    private string errorMessage { get; set; } = "Error occured: Subtraction tasks are only available in grade one through six";
}
