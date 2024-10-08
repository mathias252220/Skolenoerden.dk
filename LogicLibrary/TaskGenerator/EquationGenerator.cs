﻿using LogicLibrary.Enums;
using LogicLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLibrary.TaskGenerator;
public class EquationGenerator : ITaskGenerator
{
    private readonly Random rnd;

    private static Random random = new();

    public EquationGenerator(Random rnd = default)
    {
        this.rnd = rnd ?? new Random();
    }

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
        throw new Exception(errorMessage);
    }

    public TaskModel CreateTaskFour(double taskAnswer)
    {
        throw new Exception(errorMessage);
    }

    public TaskModel CreateTaskFive()
    {
        throw new Exception(errorMessage);
    }

    public TaskModel CreateTaskFive(double taskAnswer)
    {
        throw new Exception(errorMessage);
    }

    public TaskModel CreateTaskSix()
    {
        throw new Exception(errorMessage);
    }

    public TaskModel CreateTaskSix(double taskAnswer)
    {
        throw new Exception(errorMessage);
    }

    public TaskModel CreateTaskSeven()
    {
        //Answer is a whole number between 1 and 50.
        double answer = random.Next(1, 51);

        TaskModel task = CreateEquation(7, answer);
        task.Grade = GradeEnum.GradeSeven;

        return task;
    }

    public TaskModel CreateTaskSeven(double answer)
    {
        TaskModel task = CreateEquation(7, answer);
        task.Grade = GradeEnum.GradeSeven;

        return task;
        
    }

    public TaskModel CreateTaskEight()
    {
        //Answer is a whole number between 1 and 100
        double answer = random.Next(1, 100);

        TaskModel task = CreateEquation(8, answer);
        task.Grade = GradeEnum.GradeEight;

        return task;
    }

    public TaskModel CreateTaskEight(double answer)
    {
        TaskModel task = CreateEquation(8, answer);
        task.Grade = GradeEnum.GradeEight;

        return task;
    }

    public TaskModel CreateTaskNine()
    {
        //Answer is a whole number between 1 and 20
        double answer = random.Next(1, 20);

        TaskModel task = CreateEquation(9, answer);
        task.Grade = GradeEnum.GradeNine;

        return task;
    }

    public TaskModel CreateTaskNine(double answer)
    {
        TaskModel task = CreateEquation(9, answer);
        task.Grade = GradeEnum.GradeNine;

        return task;
    }

    private TaskModel CreateEquation(int grade, double taskAnswer)
    {
        if (grade == 7)
        {
            return CreateEquationGradeSeven(taskAnswer);
        }
        else if (grade == 8)
        {
            return CreateEquationGradeEight(taskAnswer);
        }
        else if (grade == 9)
        {
            return CreateEquationGradeNine(taskAnswer);
        }
        else
        {
            throw new Exception("Error occured: Grade does not exist.");
        }
    }

    private TaskModel CreateEquationGradeSeven(double taskAnswer)
    {
        int equationTypeInt = rnd.Next(0, 4);

        if (equationTypeInt == 0)
        {
            return CreateEquationType0(taskAnswer);
        }
        else if (equationTypeInt == 1)
        {
            return CreateEquationType1(taskAnswer);
        }
        else if (equationTypeInt == 2)
        {
            return CreateEquationType2(taskAnswer);
        }
        else if (equationTypeInt == 3)
        {
            return CreateEquationType3(taskAnswer);
        }
        else
        {
            throw new Exception("Error occured: Equation task type does not exist");
        }
    }

    private TaskModel CreateEquationGradeEight(double taskAnswer)
    {
        int equationTypeInt = rnd.Next(4, 10);

        if (equationTypeInt == 4)
        {
            return CreateEquationType4(taskAnswer);
        }
        else if (equationTypeInt == 5)
        {
            return CreateEquationType5(taskAnswer);
        }
        else if (equationTypeInt == 6)
        {
            return CreateEquationType6(taskAnswer);
        }
        else if (equationTypeInt == 7)
        {
            return CreateEquationType7(taskAnswer);
        }
        else if (equationTypeInt == 8)
        {
            return CreateEquationType8(taskAnswer);
        }
        else if (equationTypeInt == 9)
        {
            return CreateEquationType9(taskAnswer);
        }
        else
        {
            throw new Exception("Error occured: Equation task type does not exist");
        }
    }

    private TaskModel CreateEquationGradeNine(double taskAnswer)
    {
        int equationTypeInt = rnd.Next(10, 15);

        if (equationTypeInt == 10)
        {
            return CreateEquationType10(taskAnswer);
        }
        else if (equationTypeInt == 11)
        {
            return CreateEquationType11(taskAnswer);
        }
        else if (equationTypeInt == 12)
        {
            return CreateEquationType12(taskAnswer);
        }
        else if (equationTypeInt == 13)
        {
            return CreateEquationType13(taskAnswer);
        }
        else if (equationTypeInt == 14)
        {
            return CreateEquationType14(taskAnswer);
        }
        else
        {
            throw new Exception("Error occured: Equation task type does not exist");
        }
    }

    //Equation of type a + x + b = c
    private TaskModel CreateEquationType0(double taskAnswer)
    {
        TaskModel task = new();

        task.Answer = taskAnswer;
        task.TaskType = TaskTypeEnum.Equation;
        task.VariableOne = random.Next(1, 51);
        task.VariableTwo = random.Next(1, 51);
        task.VariableThree = task.VariableOne + task.Answer + task.VariableTwo;
        task.Question = $"{task.VariableOne} + x + {task.VariableTwo} = {task.VariableThree}";

        return task;
    }

    //Equation of type a + x - b = c
    private static TaskModel CreateEquationType1(double taskAnswer)
    {
        TaskModel task = new();

        task.Answer = taskAnswer;
        task.TaskType = TaskTypeEnum.Equation;
        task.VariableOne = random.Next(1, 51);
        task.VariableTwo = random.Next(1, 51);
        task.VariableThree = task.VariableOne + task.Answer - task.VariableTwo;
        task.Question = $"{task.VariableOne} + x - {task.VariableTwo} = {task.VariableThree}";

        return task;
    }

    //Equation of type a * x + b = c
    private static TaskModel CreateEquationType2(double taskAnswer)
    {
        TaskModel task = new();

        task.Answer = taskAnswer;
        task.TaskType = TaskTypeEnum.Equation;
        task.VariableOne = random.Next(1, 11);
        task.VariableTwo = random.Next(1, 51);
        task.VariableThree = task.VariableOne * task.Answer + task.VariableTwo;
        task.Question = $"{task.VariableOne}x + {task.VariableTwo} = {task.VariableThree}";

        return task;
    }

    //Equation of type a - b * x = c
    private static TaskModel CreateEquationType3(double taskAnswer)
    {
        TaskModel task = new();

        task.Answer = taskAnswer;
        task.TaskType = TaskTypeEnum.Equation;
        task.VariableOne = random.Next(1, 51);
        task.VariableTwo = random.Next(1, 11);
        task.VariableThree = task.VariableOne - (task.Answer * task.VariableTwo);
        task.Question = $"{task.VariableOne} - {task.VariableTwo}x = {task.VariableThree}";

        return task;
    }

    // Equation of type a + (x + b) = c
    private static TaskModel CreateEquationType4(double taskAnswer)
    {
        TaskModel task = new();

        task.Answer = taskAnswer;
        task.TaskType = TaskTypeEnum.Equation;
        task.VariableOne = random.Next(1, 51);
        task.VariableTwo = random.Next(1, 51);
        task.VariableThree = task.VariableOne + task.Answer + task.VariableTwo;
        task.Question = $"{task.VariableOne} + (x + {task.VariableTwo}) = {task.VariableThree}";

        return task;
    }

    // Equation of type a + (x - b) = c
    private static TaskModel CreateEquationType5(double taskAnswer)
    {
        TaskModel task = new();

        task.Answer = taskAnswer;
        task.TaskType = TaskTypeEnum.Equation;
        task.VariableOne = random.Next(1, 51);
        task.VariableTwo = random.Next(1, 51);
        task.VariableThree = task.VariableOne + task.Answer - task.VariableTwo;
        task.Question = $"{task.VariableOne} + (x - {task.VariableTwo}) = {task.VariableThree}";

        return task;
    }

    // Equation of type a - (x + b) = c
    private static TaskModel CreateEquationType6(double taskAnswer)
    {
        TaskModel task = new();

        task.Answer = taskAnswer;
        task.TaskType = TaskTypeEnum.Equation;
        task.VariableOne = random.Next(1, 51);
        task.VariableTwo = random.Next(1, 51);
        task.VariableThree = task.VariableOne - task.Answer - task.VariableTwo;
        task.Question = $"{task.VariableOne} - (x + {task.VariableTwo}) = {task.VariableThree}";

        return task;
    }

    // Equation of type a - (x - b) = c
    private static TaskModel CreateEquationType7(double taskAnswer)
    {
        TaskModel task = new();

        task.Answer = taskAnswer;
        task.TaskType = TaskTypeEnum.Equation;
        task.VariableOne = random.Next(1, 51);
        task.VariableTwo = random.Next(1, 51);
        task.VariableThree = task.VariableOne - task.Answer + task.VariableTwo;
        task.Question = $"{task.VariableOne} - (x - {task.VariableTwo}) = {task.VariableThree}";

        return task;
    }

    // Equation of type a * (x + b) = c
    private static TaskModel CreateEquationType8(double taskAnswer)
    {
        TaskModel task = new();

        task.Answer = taskAnswer;
        task.TaskType = TaskTypeEnum.Equation;
        task.VariableOne = random.Next(1, 11);
        task.VariableTwo = random.Next(1, 51);
        task.VariableThree = task.VariableOne * (task.Answer + task.VariableTwo);
        task.Question = $"{task.VariableOne}(x + {task.VariableTwo}) = {task.VariableThree}";

        return task;
    }

    // Equation of type a * (x - b) = c
    private static TaskModel CreateEquationType9(double taskAnswer)
    {
        TaskModel task = new();

        task.Answer = taskAnswer;
        task.TaskType = TaskTypeEnum.Equation;
        task.VariableOne = random.Next(1, 11);
        task.VariableTwo = random.Next(1, 51);
        task.VariableThree = task.VariableOne * (task.Answer - task.VariableTwo);
        task.Question = $"{task.VariableOne}(x - {task.VariableTwo}) = {task.VariableThree}";

        return task;
    }

    // Equation of type a * (x + b) = c * x
    private static TaskModel CreateEquationType10(double taskAnswer)
    {
        TaskModel task = new();

        task.Answer = taskAnswer;
        task.TaskType = TaskTypeEnum.Equation;
        task.VariableOne = random.Next(1, 11);
        task.VariableTwo = random.Next(1, 11) * task.Answer;
        task.VariableThree = task.VariableOne * (task.Answer + task.VariableTwo) / task.Answer;

        task.Question = $"{task.VariableOne}(x + {task.VariableTwo}) = {task.VariableThree}x";

        return task;
    }

    // Equation of type a + b * x = c * (x + d)
    private static TaskModel CreateEquationType11(double taskAnswer)
    {
        TaskModel task = new();

        task.Answer = taskAnswer;
        task.TaskType = TaskTypeEnum.Equation;
        task.VariableThree = random.Next(1, 11);
        task.VariableFour = random.Next(1, 11) * task.Answer;
        for (int i = 2; i <= (int)task.VariableThree * (int)task.VariableFour; i++)
        {
            task.VariableOne = task.VariableThree * task.VariableFour / i;
            if (task.VariableOne % 1 == 0)
            {
                task.VariableTwo = (task.VariableThree * (task.Answer + task.VariableFour) - task.VariableOne) / task.Answer;
                if (task.VariableTwo % 1 == 0)
                {
                    task.Question = $"{task.VariableOne} + {task.VariableTwo}x = {task.VariableThree}(x + {task.VariableFour})";
                    return task;
                }
            }
        }
        throw new Exception("Equation type 11 not concluded properly.");
    }

    // Equation of type a + b * (x - c) = d * x
    private static TaskModel CreateEquationType12(double taskAnswer)
    {
        TaskModel task = new();

        task.Answer = taskAnswer;
        task.TaskType = TaskTypeEnum.Equation;
        task.VariableTwo = random.Next(1, 11);
        task.VariableThree = random.Next(1, 11) * task.Answer;
        for (int i = 2; i <= (int)task.VariableTwo * (int)task.VariableThree; i++)
        {
            task.VariableOne = task.VariableTwo * task.VariableThree / i;
            if (task.VariableOne % 1 == 0)
            {
                task.VariableFour = (task.VariableOne + task.VariableTwo * (task.Answer - task.VariableThree)) / task.Answer;
                if (task.VariableFour % 1 == 0)
                {
                    task.Question = $"{task.VariableOne} + {task.VariableTwo}(x - {task.VariableThree}) = {task.VariableFour}x";
                    return task;
                }
            }
        }
        throw new Exception("Equation type 12 not concluded properly.");
    }

    // Equation of type a - b * (x + c) = d * x
    private static TaskModel CreateEquationType13(double taskAnswer)
    {
        TaskModel task = new();

        task.Answer = taskAnswer;
        task.TaskType = TaskTypeEnum.Equation;
        task.VariableTwo = random.Next(1, 11);
        task.VariableThree = random.Next(1, 11) * task.Answer;
        for (int i = 2; i <= (int)task.VariableTwo * (int)task.VariableThree; i++)
        {
            task.VariableOne = task.VariableTwo * task.VariableThree / i;
            if (task.VariableOne % 1 == 0)
            {
                task.VariableFour = (task.VariableOne - task.VariableTwo * (task.Answer + task.VariableThree)) / task.Answer;
                if (task.VariableFour % 1 == 0)
                {
                    task.Question = $"{task.VariableOne} - {task.VariableTwo}(x + {task.VariableThree}) = {task.VariableFour}x";
                    return task;
                }
            }
        }
        throw new Exception("Equation type 13 not concluded properly.");
    }

    // Equation of type a * x = b - c * (x - d)
    private static TaskModel CreateEquationType14(double taskAnswer)
    {
        TaskModel task = new();

        task.Answer = taskAnswer;
        task.TaskType = TaskTypeEnum.Equation;
        task.VariableThree = random.Next(1, 11);
        task.VariableFour = random.Next(1, 11) * task.Answer;
        for (int i = 2; i <= (int)task.VariableThree * (int)task.VariableFour; i++)
        {
            task.VariableTwo = task.VariableThree * task.VariableFour / i;
            if (task.VariableTwo % 1 == 0)
            {
                task.VariableOne = (task.VariableTwo - task.VariableThree * (task.Answer - task.VariableFour)) / task.Answer;
                if (task.VariableOne % 1 == 0)
                {
                    task.Question = $"{task.VariableOne}x = {task.VariableTwo} - {task.VariableThree}(x - {task.VariableFour})";
                    return task;
                }

            }
        }
        throw new Exception("Equation type 14 not concluded properly.");
    }

    private string errorMessage { get; set; } = "Error occured: Equation tasks are only avaiable in grade seven through nine.";
}
