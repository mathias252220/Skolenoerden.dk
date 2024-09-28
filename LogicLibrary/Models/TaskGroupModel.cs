using LogicLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLibrary.Models;
public class TaskGroupModel
{
    public List<TaskModel> Tasks { get; set; } = new();
    public TaskTypeEnum TasksType { get; set; }
    public GradeEnum TasksGrade { get; set; }

    public static List<GradeEnum> GetAvailableGrades(TaskTypeEnum taskType)
    {
        if (taskType == TaskTypeEnum.Default)
        {
            return [];
        }
        if (taskType == TaskTypeEnum.Addition)
        {
            return ReturnAvailableGrades(0, 6);
        }
        else if (taskType == TaskTypeEnum.Subtraction)
        {
            return ReturnAvailableGrades(1, 6);
        }
        else if (taskType == TaskTypeEnum.Multiplication)
        {
            return ReturnAvailableGrades(3, 6);
        }
        else if (taskType == TaskTypeEnum.Division)
        {
            return ReturnAvailableGrades(4, 6);
        }
        else if (taskType == TaskTypeEnum.Fraction)
        {
            return ReturnAvailableGrades(7, 9);
        }
        else if (taskType == TaskTypeEnum.Equation)
        {
            return ReturnAvailableGrades(7, 9);
        }
        else
        {
            throw new Exception("Error occured: That task type does not exist.");
        }
    }

    public static string GetGradeString(GradeEnum grade)
    {
        return $"{(int)grade - 1}. klasse";
    }

    public static string GetTaskTypeString(TaskTypeEnum taskType)
    {
        if (taskType == TaskTypeEnum.Default)
        {
            return "Vælg Opgavetype";
        }
        else if (taskType == TaskTypeEnum.Addition)
        {
            return "Addition";
        }
        else if (taskType == TaskTypeEnum.Subtraction)
        {
            return "Subtraktion";
        }
        else if (taskType == TaskTypeEnum.Multiplication)
        {
            return "Multiplikation";
        }
        else if (taskType == TaskTypeEnum.Division)
        {
            return "Division";
        }
        else if (taskType == TaskTypeEnum.Fraction)
        {
            return "Brøker";
        }
        else if (taskType == TaskTypeEnum.Equation)
        {
            return "Ligninger";
        }
        else
        {
            throw new Exception("Error occured: Task type does not exist");
        }
    }

    private static List<GradeEnum> ReturnAvailableGrades(int lowestGrade, int highestGrade)
    {
        List<GradeEnum> availableGrades = new();

        for (int i = lowestGrade+1; i <= highestGrade+1; i++)
        {
            availableGrades.Add((GradeEnum)i);
        }

        return availableGrades;
    }
}
