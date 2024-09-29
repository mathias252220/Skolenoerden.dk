using LogicLibrary.Models;
using LogicLibrary.TreasureHunt;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLibrary.TaskGenerator;
public class MultiplicationGenerator : ITaskGenerator
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
        throw new Exception(errorMessage);
    }

    public TaskModel CreateTaskOne(double taskAnswer)
    {
        throw new Exception(errorMessage);
    }

    public TaskModel CreateTaskTwo()
    {
        throw new Exception(errorMessage);
    }

    public TaskModel CreateTaskTwo(double taskAnswer)
    {
        throw new Exception(errorMessage);
    }

    public TaskModel CreateTaskThree()
    {
        Random rnd = new();

        //Answer is a non-prime number between 1 and 100
        List<int> products = MathLogic.CreateProducts(10, 10);
        double taskAnswer = products[rnd.Next(0, products.Count)];

        TaskModel task = CreateMultiplication(taskAnswer, 10);

        return task;
    }

    public TaskModel CreateTaskThree(double taskAnswer)
    {
        TaskModel task = CreateMultiplication(taskAnswer, 10);

        return task;
    }

    public TaskModel CreateTaskFour()
    {
        Random rnd = new();

        //Answer is a non-prime number between 1 and 1000.
        List<int> products = MathLogic.CreateProducts(10, 100);
        double taskAnswer = products[rnd.Next(products.Count)];

        TaskModel task = CreateMultiplication(taskAnswer, 100);

        return task;
    }

    public TaskModel CreateTaskFour(double taskAnswer)
    {
        TaskModel task = CreateMultiplication(taskAnswer, 100);

        return task;
    }

    public TaskModel CreateTaskFive()
    {
        Random rnd = new();

        //Answer is a non-prime number between 1 and 2500.
        List<int> products = MathLogic.CreateProducts(50, 50);
        double taskAnswer = products[rnd.Next(products.Count)];

        TaskModel task = CreateMultiplication(taskAnswer, 50);

        return task;
    }

    public TaskModel CreateTaskFive(double taskAnswer)
    {
        TaskModel task = CreateMultiplication(taskAnswer, 50);

        return task;
    }

    public TaskModel CreateTaskSix()
    {
        Random rnd = new();

        //Answer is a non-prime number between 1 and 10000.
        List<int> products = MathLogic.CreateProducts(100, 100);
        double taskAnswer = products[rnd.Next(products.Count)];

        TaskModel task = CreateMultiplication(taskAnswer, 100);

        return task;
    }

    public TaskModel CreateTaskSix(double taskAnswer)
    {
        TaskModel task = CreateMultiplication(taskAnswer, 100);

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

    private static TaskModel CreateMultiplication(double taskAnswer, int maxFactorValue)
    {
        Random rnd = new();
        TaskModel task = new();

        List<int> possibleFactors = MathLogic.GetFactors(Convert.ToInt16(taskAnswer));
        possibleFactors = MathLogic.LimitTwoFactors(possibleFactors, maxFactorValue, (int)taskAnswer);

        task.TaskType = Enums.TaskTypeEnum.Multiplication;
        task.Answer = taskAnswer;
        Console.WriteLine(task.Answer);
        task.VariableOne = Convert.ToDouble(possibleFactors[rnd.Next(0, possibleFactors.Count)]);
        task.VariableTwo = task.Answer / task.VariableOne;
        task.Question = $"{task.VariableOne} · {task.VariableTwo} =";

        return task;
    }

    private string errorMessage { get; set; } = "Error occured: Multiplication tasks are only available in grade three through six";
}
