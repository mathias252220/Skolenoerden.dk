using LogicLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fractions;
using LogicLibrary.Enums;

namespace LogicLibrary.TaskGenerator;
public class FractionGenerator : ITaskGenerator
{
    private readonly Random rnd;

    private static Random random = new();

    public FractionGenerator(Random rnd = default)
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
        //Answer is a reduced fraction with numerator and denominator between 1 and 10
        Fraction answer = new Fraction(random.Next(1, 11), random.Next(1, 11));

        TaskModel task = CreateFraction(answer, rnd.Next(0, 4), 10);
        task.Grade = GradeEnum.GradeSeven;

        return task;
    }

    public TaskModel CreateTaskSeven(double taskAnswer)
    {
        TaskModel task = CreateFraction(Fraction.FromDoubleRounded(taskAnswer), rnd.Next(0, 4), 10);
        task.Grade = GradeEnum.GradeSeven;

        return task;
    }

    public TaskModel CreateTaskEight()
    {
        TaskModel task = CreateTaskSeven();
        task.Grade = GradeEnum.GradeEight;

        return task;
    }

    public TaskModel CreateTaskEight(double taskAnswer)
    {
        TaskModel task = CreateTaskSeven(taskAnswer);
        task.Grade = GradeEnum.GradeEight;

        return task;
    }

    public TaskModel CreateTaskNine()
    {
        //Answer is a reduced fraction with numerator and denominator between 1 and 20.
        Fraction fraction = new Fraction(random.Next(1, 21), random.Next(1, 21));

        TaskModel task = CreateFraction(fraction, rnd.Next(0, 4), 20);

        task.Grade = GradeEnum.GradeNine;

        return task;
    }

    public TaskModel CreateTaskNine(double taskAnswer)
    {
        TaskModel task = CreateFraction(Fraction.FromDoubleRounded(taskAnswer), rnd.Next(0, 4), 20);
        task.Grade = GradeEnum.GradeNine;

        return task;
    }

    private static TaskModel CreateFraction(Fraction taskAnswer, int fractionType, int maxDivisor)
    {
        if (fractionType == 0)
        {
            return CreateFractionType0(maxDivisor, taskAnswer);
        }
        else if (fractionType == 1)
        {
            return CreateFractionType1(maxDivisor, taskAnswer);
        }
        else if (fractionType == 2)
        {
            return CreateFractionType2(maxDivisor, taskAnswer);
        }
        else if (fractionType == 3)
        {
            return CreateFractionType3(maxDivisor, taskAnswer);
        }
        else
        {
            throw new Exception("Error occured: Fraction task type does not exist");
        }
    }

    private static TaskModel CreateFractionType0(int maxDivisor, Fraction answer)
    {
        TaskModel task = new();
        Fraction variableOne;
        Fraction variableTwo;

        do
        {
            variableOne = new Fraction(random.Next(1, maxDivisor + 1), random.Next(1, maxDivisor + 2));
        } while (variableOne >= answer);

        task.Answer = (double)answer;
        task.TaskType = Enums.TaskTypeEnum.Fraction;
        task.VariableOne = (double)variableOne;
        variableTwo = answer - variableOne;
        task.VariableTwo = (double)variableTwo;
        task.Question = $"{variableOne} + {variableTwo} =";

        return task;
    }

    private static TaskModel CreateFractionType1(int maxDivisor, Fraction answer)
    {
        Random random = new();
        TaskModel task = new();
        Fraction variableOne;
        Fraction variableTwo;

        do
        {
            variableOne = new Fraction(random.Next(1, maxDivisor + 2), random.Next(1, maxDivisor + 1));
        } while (variableOne <= answer);

        task.Answer = (double)answer;
        task.TaskType = Enums.TaskTypeEnum.Fraction;
        task.VariableOne = (double)variableOne;
        variableTwo = variableOne - answer;
        task.VariableTwo = (double)variableTwo;
        task.Question = $"{variableOne} - {variableTwo} =";

        return task;
    }

    private static TaskModel CreateFractionType2(int maxDivisor, Fraction answer)
    {
        Random random = new();
        TaskModel task = new();
        Fraction variableOne;
        Fraction variableTwo;

        task.Answer = (double)answer;
        task.TaskType = Enums.TaskTypeEnum.Fraction;
        variableOne = new Fraction(random.Next(1, maxDivisor + 1), random.Next(1, maxDivisor + 1));
        task.VariableOne = (double)variableOne;
        variableTwo = answer / variableOne;
        task.VariableTwo = (double)variableTwo;
        task.Question = $"{variableOne} · {variableTwo} =";

        return task;
    }

    private static TaskModel CreateFractionType3(int maxDivisor, Fraction answer)
    {
        Random random = new();
        TaskModel task = new();
        Fraction variableOne;
        Fraction variableTwo;

        task.Answer = (double)answer;
        task.TaskType = Enums.TaskTypeEnum.Fraction;
        variableOne = new Fraction(random.Next(1, maxDivisor + 1), random.Next(1, maxDivisor + 1));
        task.VariableOne = (double)variableOne;
        variableTwo = variableOne / answer;
        task.VariableTwo = (double)variableTwo;
        task.Question = $"{variableOne} : {variableTwo} =";

        return task;
    }

    private string errorMessage { get; set; } = "Error occured: Fraction tasks are only avaible in grade seven through nine.";
}
