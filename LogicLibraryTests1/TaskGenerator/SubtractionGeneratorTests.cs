using LogicLibrary.Models;
using LogicLibrary.TaskGenerator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLibrary.TaskGenerator.Tests;

[TestClass()]
public class SubtractionGeneratorTests
{
    SubtractionGenerator subtractionGenerator = new();
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
    [ExpectedException(typeof(Exception))]
    public void SubtractionTaskZeroWOAnswerTest()
    {
        task = subtractionGenerator.CreateTaskZero();
    }

    [TestMethod()]
    [ExpectedException(typeof(Exception))]
    public void SubtractionTaskZeroWAnswerTest()
    {
        double taskAnswer = 5;
        task = subtractionGenerator.CreateTaskZero(taskAnswer);
    }

    [TestMethod()]
    public void SubtractionTaskOneWOAnswerTest()
    {
        task = subtractionGenerator.CreateTaskOne();
        double testAnswer = task.VariableOne - task.VariableTwo;

        Assert.AreEqual(task.Answer, Math.Round(testAnswer, 2));
    }

    [TestMethod()]
    [DynamicData(nameof(AnswerList))]
    public void SubtractionTaskOneWAnswerTest(double taskAnswer)
    {
        task = subtractionGenerator.CreateTaskOne(taskAnswer);
        double testAnswer = task.VariableOne - task.VariableTwo;

        Assert.AreEqual(task.Answer, Math.Round(testAnswer, 2));
        Assert.AreEqual(taskAnswer, task.Answer);
    }

    [TestMethod()]
    public void SubtractionTaskTwoWOAnswerTest()
    {
        task = subtractionGenerator.CreateTaskTwo();
        double testAnswer = task.VariableOne - task.VariableTwo;

        Assert.AreEqual(task.Answer, Math.Round(testAnswer, 2));
    }

    [TestMethod()]
    [DynamicData(nameof(AnswerList))]
    public void SubtractionTaskTwoWAnswerTest(double taskAnswer)
    {
        task = subtractionGenerator.CreateTaskTwo(taskAnswer);
        double testAnswer = task.VariableOne - task.VariableTwo;

        Assert.AreEqual(task.Answer, Math.Round(testAnswer, 2));
        Assert.AreEqual(taskAnswer, task.Answer);
    }

    [TestMethod()]
    public void SubtractionTaskThreeWOAnswerTest()
    {
        task = subtractionGenerator.CreateTaskThree();
        double testAnswer = task.VariableOne - task.VariableTwo;

        Assert.AreEqual(task.Answer, Math.Round(testAnswer, 2));
    }

    [TestMethod()]
    [DynamicData(nameof(AnswerList))]
    public void SubtractionTaskThreeWAnswerTest(double taskAnswer)
    {
        task = subtractionGenerator.CreateTaskThree(taskAnswer);
        double testAnswer = task.VariableOne - task.VariableTwo;

        Assert.AreEqual(task.Answer, Math.Round(testAnswer, 2));
        Assert.AreEqual(taskAnswer, task.Answer);
    }

    [TestMethod()]
    public void SubtractionTaskFourWOAnswerTest()
    {
        task = subtractionGenerator.CreateTaskFour();
        double testAnswer = task.VariableOne - task.VariableTwo;

        Assert.AreEqual(task.Answer, Math.Round(testAnswer, 2));
    }

    [TestMethod()]
    [DynamicData(nameof(AnswerList))]
    public void SubtractionTaskFourWAnswerTest(double taskAnswer)
    {
        task = subtractionGenerator.CreateTaskFour(taskAnswer);
        double testAnswer = task.VariableOne - task.VariableTwo;

        Assert.AreEqual(task.Answer, Math.Round(testAnswer, 2));
        Assert.AreEqual(taskAnswer, task.Answer);
    }

    [TestMethod()]
    public void SubtractionTaskFiveWOAnswerTest()
    {
        task = subtractionGenerator.CreateTaskFive();
        double testAnswer = task.VariableOne - task.VariableTwo;

        Assert.AreEqual(task.Answer, Math.Round(testAnswer, 2));
    }

    [TestMethod()]
    [DynamicData(nameof(AnswerList))]
    public void SubtractionTaskFiveWAnswerTest(double taskAnswer)
    {
        task = subtractionGenerator.CreateTaskFive(taskAnswer);
        double testAnswer = task.VariableOne - task.VariableTwo;

        Assert.AreEqual(task.Answer, Math.Round(testAnswer, 2));
        Assert.AreEqual(taskAnswer, task.Answer);
    }

    [TestMethod()]
    public void SubtractionTaskSixWOAnswerTest()
    {
        task = subtractionGenerator.CreateTaskSix();
        double testAnswer = task.VariableOne - task.VariableTwo;

        Assert.AreEqual(task.Answer, Math.Round(testAnswer, 2));
    }

    [TestMethod()]
    [DynamicData(nameof(AnswerList))]
    public void SubtractionTaskSixWAnswerTest(double taskAnswer)
    {
        task = subtractionGenerator.CreateTaskSix(taskAnswer);
        double testAnswer = task.VariableOne - task.VariableTwo;

        Assert.AreEqual(task.Answer, Math.Round(testAnswer, 2));
        Assert.AreEqual(taskAnswer, task.Answer);
    }

    [TestMethod()]
    [ExpectedException(typeof(Exception))]
    public void SubtractionTaskSevenWOAnswerTest()
    {
        task = subtractionGenerator.CreateTaskSeven();
    }

    [TestMethod()]
    [ExpectedException(typeof(Exception))]
    public void SubtractionTaskSevenWAnswerTest()
    {
        double taskAnswer = 40;
        task = subtractionGenerator.CreateTaskSeven(taskAnswer);
    }

    [TestMethod()]
    [ExpectedException(typeof(Exception))]
    public void SubtractionTaskEightWOAnswerTest()
    {
        task = subtractionGenerator.CreateTaskEight();
    }

    [TestMethod()]
    [ExpectedException(typeof(Exception))]
    public void SubtractionTaskEightWAnswerTest()
    {
        double taskAnswer = 45;
        task = subtractionGenerator.CreateTaskEight(taskAnswer);
    }

    [TestMethod()]
    [ExpectedException(typeof(Exception))]
    public void SubtractionTaskNineWOAnswerTest()
    {
        task = subtractionGenerator.CreateTaskNine();
    }

    [TestMethod()]
    [ExpectedException(typeof(Exception))]
    public void SubtractionTaskNineWAnswerTest()
    {
        double taskAnswer = 50;
        task = subtractionGenerator.CreateTaskNine(taskAnswer);
	}
}