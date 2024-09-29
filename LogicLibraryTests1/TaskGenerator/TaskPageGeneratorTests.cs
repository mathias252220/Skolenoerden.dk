using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicLibrary.TaskGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLibrary.Models;
using LogicLibrary.Enums;
using System.Diagnostics;

namespace LogicLibrary.TaskGenerator.Tests;

[TestClass()]
public class TaskPageGeneratorTests
{
    TaskPageGenerator taskPageGenerator = new();

    public static IEnumerable<object[]> Tasks
    {
        get
        {
            return new[]
            {
               new object[] { GradeEnum.GradeZero },
               new object[] { GradeEnum.GradeOne },
               new object[] { GradeEnum.GradeTwo },
               new object[] { GradeEnum.GradeThree },
               new object[] { GradeEnum.GradeFour },
               new object[] { GradeEnum.GradeFive },
               new object[] { GradeEnum.GradeSix },
               new object[] { GradeEnum.GradeSeven },
               new object[] { GradeEnum.GradeEight },
               new object[] { GradeEnum.GradeNine }
           };
        }
    }

    [TestMethod()]
    [DynamicData(nameof(Tasks))]
    public void GenerateAdditionTaskTest(GradeEnum grade)
    {
        TaskTypeEnum taskType = TaskTypeEnum.Addition;

        if (grade < GradeEnum.GradeZero || grade > GradeEnum.GradeSix && grade <= GradeEnum.GradeNine)
        {
            Assert.ThrowsException<Exception>(()=>taskPageGenerator.GenerateTask(grade, taskType));
        }
        else
        {
            TaskModel task = taskPageGenerator.GenerateTask(grade, taskType);
            Assert.AreEqual(task.Grade, grade);
            Assert.AreEqual(task.TaskType, taskType);
        }
	}

    [TestMethod()]
    [DynamicData(nameof(Tasks))]
    public void GenerateSubtractionTaskTest(GradeEnum grade)
    {
        TaskTypeEnum taskType = TaskTypeEnum.Subtraction;

        if (grade < GradeEnum.GradeOne || grade > GradeEnum.GradeSix && grade <= GradeEnum.GradeNine)
        {
            Assert.ThrowsException<Exception>(()=> taskPageGenerator.GenerateTask(grade,taskType));
        }
        else
        {
            TaskModel task = taskPageGenerator.GenerateTask(grade, taskType);
            Assert.AreEqual(task.Grade, grade);
            Assert.AreEqual(task.TaskType, taskType);
        }
    }

    [TestMethod()]
    [DynamicData(nameof(Tasks))]
    public void GenerateMultiplcationTaskTest(GradeEnum grade)
    {
        TaskTypeEnum taskType = TaskTypeEnum.Multiplication;

        if (grade < GradeEnum.GradeThree || grade > GradeEnum.GradeSix && grade <= GradeEnum.GradeNine)
        {
            Assert.ThrowsException<Exception>(()=>taskPageGenerator.GenerateTask(grade, taskType));
        }
        else
        {
            TaskModel task = taskPageGenerator.GenerateTask(grade, taskType);
            Assert.AreEqual(task.Grade, grade);
            Assert.AreEqual(task.TaskType, taskType);
        }
    }

    [TestMethod()]
    [DynamicData(nameof(Tasks))]
    public void GenerateDivisionTaskTest(GradeEnum grade)
    {
        TaskTypeEnum taskType = TaskTypeEnum.Division;

        if (grade < GradeEnum.GradeFour || grade > GradeEnum.GradeSix && grade <= GradeEnum.GradeNine)
        {
            Assert.ThrowsException<Exception>(()=>taskPageGenerator.GenerateTask(grade, taskType));
        }
        else
        {
            TaskModel task = taskPageGenerator.GenerateTask(grade, taskType);
            Assert.AreEqual(task.Grade, grade);
            Assert.AreEqual(task.TaskType, taskType);
        }
    }

    [TestMethod()]
    [DynamicData(nameof(Tasks))]
    public void GenerateFractionTaskTest(GradeEnum grade)
    {
        TaskTypeEnum taskType = TaskTypeEnum.Fraction;

        if (grade < GradeEnum.GradeSeven || grade > GradeEnum.GradeNine)
        {
            Assert.ThrowsException<Exception>(() => taskPageGenerator.GenerateTask(grade,taskType));
        }
        else
        {
            TaskModel task = taskPageGenerator.GenerateTask(grade, taskType);
            Assert.AreEqual(task.Grade, grade);
            Assert.AreEqual(task.TaskType, taskType);
        }
    }

    [TestMethod()]
    [DynamicData(nameof(Tasks))]
    public void GenerateEquationTaskTest(GradeEnum grade)
    {
        TaskTypeEnum taskType = TaskTypeEnum.Equation;

        if (grade < GradeEnum.GradeSeven || grade > GradeEnum.GradeNine)
        {
            Assert.ThrowsException<Exception> (()=> taskPageGenerator.GenerateTask(grade, taskType));
        }
        else
        {
            TaskModel task = taskPageGenerator.GenerateTask(grade, taskType);
            Assert.AreEqual(task.Grade, grade);
            Assert.AreEqual(task.TaskType, taskType);
        }
    }
}
