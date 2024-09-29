using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicLibrary.TaskGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLibrary.Models;

namespace LogicLibrary.TaskGenerator.Tests;

[TestClass()]
public class AdditionGeneratorTests
{
    AdditionGenerator additionGenerator = new();
    TaskModel task = new();

    public static IEnumerable<object[]> AnswerList
    {
        get
        {
            return new[]
            {
                new object[] { 5 },
                new object[] { 10 },
                new object[] { 15 },
                new object[] { 20 },
                new object[] { 35 },
                new object[] { 40 },
                new object[] { 45 },
                new object[] { 50 }
            };
        }
    }

    [TestMethod()]
    public void AdditionTaskZeroWOAnswerTest()
    {
        task = additionGenerator.CreateTaskZero();
        double testAnswer = task.VariableOne + task.VariableTwo;

        Assert.AreEqual(task.Answer, Math.Round(testAnswer, 2));
    }

    [TestMethod()]
    [DynamicData(nameof(AnswerList))]
    public void AdditionTaskZeroWAnswerTest(double taskAnswer)
    {
        task = additionGenerator.CreateTaskZero(taskAnswer);
        double testAnswer = task.VariableOne + task.VariableTwo;

        Assert.AreEqual(task.Answer, Math.Round(testAnswer,2 ));
        Assert.AreEqual(taskAnswer, task.Answer);
    }

    [TestMethod()]
    public void AdditionTaskOneWOAnswerTest()
    {
        task = additionGenerator.CreateTaskOne();
        double testAnswer = task.VariableOne + task.VariableTwo;

        Assert.AreEqual(task.Answer, Math.Round(testAnswer, 2));
    }

    [TestMethod()]
    [DynamicData(nameof(AnswerList))]
    public void AdditionTaskOneWAnswerTest(double taskAnswer)
    {
        task = additionGenerator.CreateTaskOne(taskAnswer);
        double testAnswer = task.VariableOne + task.VariableTwo;

        Assert.AreEqual(task.Answer, Math.Round(testAnswer, 2));
        Assert.AreEqual(taskAnswer, task.Answer);
    }

    [TestMethod()]
    public void AdditionTaskTwoWOAnswerTest()
    {
        task = additionGenerator.CreateTaskTwo();
        double testAnswer = task.VariableOne + task.VariableTwo;

        Assert.AreEqual(task.Answer, Math.Round(testAnswer, 2));
    }

    [TestMethod()]
    [DynamicData(nameof(AnswerList))]
    public void AdditionTaskTwoWAnswerTest(double taskAnswer)
    {
        task = additionGenerator.CreateTaskTwo(taskAnswer);
        double testAnswer = task.VariableOne + task.VariableTwo;

        Assert.AreEqual(task.Answer, Math.Round(testAnswer, 2));
        Assert.AreEqual(taskAnswer, task.Answer);
    }

    [TestMethod()]
    public void AdditionTaskThreeWOAnswerTest()
    {
        task = additionGenerator.CreateTaskThree();
        double testAnswer = task.VariableOne + task.VariableTwo;

        Assert.AreEqual(task.Answer, Math.Round(testAnswer, 2));
    }

    [TestMethod()]
    [DynamicData(nameof(AnswerList))]
    public void AdditionTaskThreeWAnswerTest(double taskAnswer)
    {
        task = additionGenerator.CreateTaskThree(taskAnswer);
        double testAnswer = task.VariableOne + task.VariableTwo;

        Assert.AreEqual(task.Answer, Math.Round(testAnswer, 2));
        Assert.AreEqual(taskAnswer, task.Answer);
    }

    [TestMethod()]
    public void AdditionTaskFourWOAnswerTest()
    {
        task = additionGenerator.CreateTaskFour();
        double testAnswer = task.VariableOne + task.VariableTwo;

        Assert.AreEqual(task.Answer, Math.Round(testAnswer, 2));
    }

    [TestMethod()]
    [DynamicData(nameof(AnswerList))]
    public void AdditionTaskFourWAnswerTest(double taskAnswer)
    {
        task = additionGenerator.CreateTaskFour(taskAnswer);
        double testAnswer = task.VariableOne + task.VariableTwo;

        Assert.AreEqual(task.Answer, Math.Round(testAnswer, 2));
        Assert.AreEqual(taskAnswer, task.Answer);
    }

    [TestMethod()]
    public void AdditionTaskFiveWOAnswerTest()
    {
        task = additionGenerator.CreateTaskFive();
        double testAnswer = task.VariableOne + task.VariableTwo;

        Assert.AreEqual(task.Answer, Math.Round(testAnswer, 2));
    }

    [TestMethod()]
    [DynamicData(nameof(AnswerList))]
    public void AdditionTaskFiveWAnswerTest(double taskAnswer)
    {
        task = additionGenerator.CreateTaskFive(taskAnswer);
        double testAnswer = task.VariableOne + task.VariableTwo;

        Assert.AreEqual(task.Answer, Math.Round(testAnswer, 2));
        Assert.AreEqual(taskAnswer, task.Answer);
    }

    [TestMethod()]
    public void AdditionTaskSixWOAnswerTest()
    {
        task = additionGenerator.CreateTaskSix();
        double testAnswer = task.VariableOne + task.VariableTwo;

        Assert.AreEqual(task.Answer, Math.Round(testAnswer, 2));
    }

    [TestMethod()]
    [DynamicData(nameof(AnswerList))]
    public void AdditionTaskSixWAnswerTest(double taskAnswer)
    {
        task = additionGenerator.CreateTaskSix(taskAnswer);
        double testAnswer = task.VariableOne + task.VariableTwo;

        Assert.AreEqual(task.Answer, Math.Round(testAnswer, 2));
        Assert.AreEqual(taskAnswer, task.Answer);
    }

    
    [TestMethod()]
    [ExpectedException(typeof(Exception))]
    public void AdditionTaskSevenWOAnswerTest()
    {
        task = additionGenerator.CreateTaskSeven();
    }

    [TestMethod()]
    [ExpectedException(typeof(Exception))]
    public void AdditionTaskSevenWAnswerTest()
    {
        double taskAnswer = 40;
        task = additionGenerator.CreateTaskSeven(taskAnswer);
    }

    [TestMethod()]
    [ExpectedException(typeof(Exception))]
    public void AdditionTaskEightWOAnswerTest()
    {
        task = additionGenerator.CreateTaskEight();
    }

    [TestMethod()]
    [ExpectedException(typeof(Exception))]
    public void AdditionTaskEightWAnswerTest()
    {
        double taskAnswer = 45;
        task = additionGenerator.CreateTaskEight(taskAnswer);
    }

    [TestMethod()]
    [ExpectedException(typeof(Exception))]
    public void AdditionTaskNineWOAnswerTest()
    {
        task = additionGenerator.CreateTaskNine();
    }

    [TestMethod()]
    [ExpectedException(typeof(Exception))]
    public void AdditionTaskNineWAnswerTest()
    {
        double taskAnswer = 50;
        task = additionGenerator.CreateTaskNine(taskAnswer);
	}
}