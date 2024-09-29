using LogicLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLibrary.TaskGenerator;
public class DivisionGenerator : ITaskGenerator
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
        throw new Exception(errorMessage);
    }

    public TaskModel CreateTaskThree(double taskAnswer)
    {
        throw new Exception(errorMessage);
    }

    public TaskModel CreateTaskFour()
    {
        Random rnd = new();

        //Answer is a whole number between 1 and 10.
        double taskAnswer = rnd.Next(1, 11);

        TaskModel task = CreateDivision(taskAnswer, 10);

        return task;
    }

    public TaskModel CreateTaskFour(double taskAnswer)
    {
        TaskModel task = CreateDivision(taskAnswer, 10);

        return task;
    }

    public TaskModel CreateTaskFive()
    {
        Random rnd = new();

        //Answer is a whole number between 10 and 100.
        double taskAnswer = rnd.Next(10, 101);

        TaskModel task = CreateDivision(taskAnswer, 10);

        return task;
    }

    public TaskModel CreateTaskFive(double taskAnswer)
    {
        TaskModel task = CreateDivision(taskAnswer, 10);

        return task;
    }

    public TaskModel CreateTaskSix()
    {
        Random rnd = new();

        //Answer is a whole number between 50 and 250.
        double taskAnswer = rnd.Next(50, 251);

        TaskModel task = CreateDivision(taskAnswer, 10);

        return task;
    }

    public TaskModel CreateTaskSix(double taskAnswer)
    {
        TaskModel task = CreateDivision(taskAnswer, 10);

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

    private static TaskModel CreateDivision(double taskAnswer, int maxDivisor)
    {
        Random rnd = new();
        TaskModel task = new();

        task.TaskType = Enums.TaskTypeEnum.Division;
        task.Answer = taskAnswer;
        task.VariableOne = Convert.ToDouble(rnd.Next(2, maxDivisor));
        task.VariableTwo = task.Answer * task.VariableOne;
        task.Question = $"{task.VariableTwo} : {task.VariableOne} =";

        return task;
    }

    private string errorMessage { get; set; } = "Error occured: Division tasks are only avaiable in grade four through six.";
}
