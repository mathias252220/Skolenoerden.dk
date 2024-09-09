using LogicLibrary.Enums;
using LogicLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLibrary.TaskGenerator;
public class TaskPageGenerator
{
    public TaskModel GenerateTask(GradeEnum grade, TaskTypeEnum taskType)
    {
        ITaskGenerator taskGenerator;
        taskGenerator = ChooseTaskGenerator(taskType);
        return CreateTask(grade, taskGenerator);
    }

    private static TaskModel CreateTask(GradeEnum grade, ITaskGenerator taskGenerator)
    {
        if (grade == GradeEnum.GradeZero)
        {
            return taskGenerator.CreateTaskZero();
        }
        else if (grade == GradeEnum.GradeOne)
        {
            return taskGenerator.CreateTaskOne();
        }
        else if (grade == GradeEnum.GradeTwo)
        {
            return taskGenerator.CreateTaskTwo();
        }
        else if (grade == GradeEnum.GradeThree)
        {
            return taskGenerator.CreateTaskThree();
        }
        else if (grade == GradeEnum.GradeFour)
        {
            return taskGenerator.CreateTaskFour();
        }
        else if (grade == GradeEnum.GradeFive)
        {
            return taskGenerator.CreateTaskFive();
        }
        else if (grade == GradeEnum.GradeSix)
        {
            return taskGenerator.CreateTaskSix();
        }
        else if (grade == GradeEnum.GradeSeven)
        {
            return taskGenerator.CreateTaskSeven();
        }
        else if (grade == GradeEnum.GradeEight)
        {
            return taskGenerator.CreateTaskEight();
        }
        else if (grade == GradeEnum.GradeNine)
        {
            return taskGenerator.CreateTaskNine();
        }
        else
        {
            throw new Exception("Error occured: Grade does not exist.");
        }
    }

    private static ITaskGenerator ChooseTaskGenerator(TaskTypeEnum taskType)
    {
        ITaskGenerator taskGenerator;
        if (taskType == TaskTypeEnum.Addition)
        {
            taskGenerator = new AdditionGenerator();
        }
        else if (taskType == TaskTypeEnum.Subtraction)
        {
            taskGenerator = new SubtractionGenerator();
        }
        else if (taskType == TaskTypeEnum.Multiplication)
        {
            taskGenerator = new MultiplicationGenerator();
        }
        else if (taskType == TaskTypeEnum.Division)
        {
            taskGenerator = new DivisionGenerator();
        }
        else if (taskType == TaskTypeEnum.Fraction)
        {
            taskGenerator = new FractionGenerator();
        }
        else if (taskType == TaskTypeEnum.Equation)
        {
            taskGenerator = new EquationGenerator();
        }
        else
        {
            throw new Exception("Error occured: Task type does not exist");
        }

        return taskGenerator;
    }
}
