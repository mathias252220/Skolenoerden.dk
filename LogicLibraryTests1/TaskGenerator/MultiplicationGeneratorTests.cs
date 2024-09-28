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
public class MultiplicationGeneratorTests
{
    MultiplicationGenerator multiplicationGenerator = new();
    TaskModel task = new();

    public static IEnumerable<object[]> AnswerList
    {
        get
        {
            return new[]
            {
                new object[] { 9 },
                new object[] { 10 },
                new object[] { 16 },
                new object[] { 35 },
                new object[] { 42 },
                new object[] { 49 },
                new object[] { 56 }
            };
        }
    }

    [TestMethod()]
    [ExpectedException(typeof(Exception))]
    public void MultiplicationTaskZeroWOAnswerTest()
    {
        task = multiplicationGenerator.CreateTaskZero();
    }

    [TestMethod()]
    [ExpectedException(typeof(Exception))]
    public void MultiplicationTaskZeroWAnswerTest()
    {
        double taskAnswer = 5;
        task = multiplicationGenerator.CreateTaskZero(taskAnswer);
    }

    [TestMethod()]
    [ExpectedException(typeof(Exception))]
    public void MultiplicationTaskOneWOAnswerTest()
    {
        task = multiplicationGenerator.CreateTaskOne();
    }

    [TestMethod()]
    [ExpectedException(typeof(Exception))]
    public void MultiplicationTaskOneWAnswerTest()
    {
        double taskAnswer = 10;
        task = multiplicationGenerator.CreateTaskOne(taskAnswer);
    }

    [TestMethod()]
    [ExpectedException(typeof(Exception))]
    public void MultiplicationTaskTwoWOAnswerTest()
    {
        task = multiplicationGenerator.CreateTaskTwo();
    }

    [TestMethod()]
    [ExpectedException(typeof(Exception))]
    public void MultiplicationTaskTwoWAnswerTest()
    {
        double taskAnswer = 15;
        task = multiplicationGenerator.CreateTaskTwo(taskAnswer);
    }

    [TestMethod()]
    public void MultiplicationTaskThreeWOAnswerTest()
    {
        task = multiplicationGenerator.CreateTaskThree();
        double testAnswer = task.VariableOne * task.VariableTwo;

        Assert.AreEqual(task.Answer, Math.Round(testAnswer, 2));
    }

    [TestMethod()]
    [DynamicData(nameof(AnswerList))]
    public void MultiplicationTaskThreeWAnswerTest(double taskAnswer)
    {
        task = multiplicationGenerator.CreateTaskThree(taskAnswer);
        double testAnswer = task.VariableOne * task.VariableTwo;

        Assert.AreEqual(task.Answer, Math.Round(testAnswer, 2));
        Assert.AreEqual(taskAnswer, task.Answer);
    }

    [TestMethod()]
    public void MultiplicationTaskFourWOAnswerTest()
    {
        task = multiplicationGenerator.CreateTaskFour();
        double testAnswer = task.VariableOne * task.VariableTwo;

        Assert.AreEqual(task.Answer, Math.Round(testAnswer, 2));
    }

    [TestMethod()]
    [DynamicData(nameof(AnswerList))]
    public void MultiplicationTaskFourWAnswerTest(double taskAnswer)
    {
        task = multiplicationGenerator.CreateTaskFour(taskAnswer);
        double testAnswer = task.VariableOne * task.VariableTwo;

        Assert.AreEqual(task.Answer, Math.Round(testAnswer, 2));
        Assert.AreEqual(taskAnswer, task.Answer);
    }

    [TestMethod()]
    public void MultiplicationTaskFiveWOAnswerTest()
    {
        task = multiplicationGenerator.CreateTaskFive();
        double testAnswer = task.VariableOne * task.VariableTwo;

        Assert.AreEqual(task.Answer, Math.Round(testAnswer, 2));
    }

    [TestMethod()]
    [DynamicData(nameof(AnswerList))]
    public void MultiplicationTaskFiveWAnswerTest(double taskAnswer)
    {
        task = multiplicationGenerator.CreateTaskFive(taskAnswer);
        double testAnswer = task.VariableOne * task.VariableTwo;

        Assert.AreEqual(task.Answer, Math.Round(testAnswer, 2));
        Assert.AreEqual(taskAnswer, task.Answer);
    }

    [TestMethod()]
    public void MultiplicationTaskSixWOAnswerTest()
    {
        task = multiplicationGenerator.CreateTaskSix();
        double testAnswer = task.VariableOne * task.VariableTwo;

        Assert.AreEqual(task.Answer, Math.Round(testAnswer, 2));
    }

    [TestMethod()]
    [DynamicData(nameof(AnswerList))]
    public void MultiplicationTaskSixWAnswerTest(double taskAnswer)
    {
        task = multiplicationGenerator.CreateTaskSix(taskAnswer);
        double testAnswer = task.VariableOne * task.VariableTwo;

        Assert.AreEqual(task.Answer, Math.Round(testAnswer, 2));
        Assert.AreEqual(taskAnswer, task.Answer);
    }

    [TestMethod()]
    [ExpectedException(typeof(Exception))]
    public void MultiplicationTaskSevenWOAnswerTest()
    {
        task = multiplicationGenerator.CreateTaskSeven();
    }

    [TestMethod()]
    [ExpectedException(typeof(Exception))]
    public void MultiplicationTaskSevenWAnswerTest()
    {
        double taskAnswer = 40;
        task = multiplicationGenerator.CreateTaskSeven(taskAnswer);
    }

    [TestMethod()]
    [ExpectedException(typeof(Exception))]
    public void MultiplicationTaskEightWOAnswerTest()
    {
        task = multiplicationGenerator.CreateTaskEight();
    }

    [TestMethod()]
    [ExpectedException(typeof(Exception))]
    public void MultiplicationTaskEightWAnswerTest()
    {
        double taskAnswer = 45;
        task = multiplicationGenerator.CreateTaskEight(taskAnswer);
    }

    [TestMethod()]
    [ExpectedException(typeof(Exception))]
    public void MultiplicationTaskNineWOAnswerTest()
    {
        task = multiplicationGenerator.CreateTaskNine();
    }

    [TestMethod()]
    [ExpectedException(typeof(Exception))]
    public void MultiplicationTaskNineWAnswerTest()
    {
        double taskAnswer = 50;
        task = multiplicationGenerator.CreateTaskNine(taskAnswer);
	}
}