using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicLibrary.TaskGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLibrary.Models;
using Moq;

namespace LogicLibrary.TaskGenerator.Tests;

[TestClass()]
public class EquationGeneratorTests
{
    EquationGenerator equationGenerator = new();
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
                new object[] { 25 },
                new object[] { 30 },
                new object[] { 35 },
                new object[] { 40 },
                new object[] { 45 },
                new object[] { 50 },
            };
        }
    }

    [TestMethod()]
    [ExpectedException(typeof(Exception))]
    public void EquationTaskZeroWOAnswerTest()
    {
        task = equationGenerator.CreateTaskZero();
    }

    [TestMethod()]
    [ExpectedException(typeof(Exception))]
    public void EquationTaskZeroWAnswerTest()
    {
        double taskAnswer = 5;
        task = equationGenerator.CreateTaskZero(taskAnswer);
    }

    [TestMethod()]
    [ExpectedException(typeof(Exception))]
    public void EquationTaskOneWOAnswerTest()
    {
        task = equationGenerator.CreateTaskOne();
    }

    [TestMethod()]
    [ExpectedException(typeof(Exception))]
    public void EquationTaskOneWAnswerTest()
    {
        double taskAnswer = 10;
        task = equationGenerator.CreateTaskOne(taskAnswer);
    }

    [TestMethod()]
    [ExpectedException(typeof(Exception))]
    public void EquationTaskTwoWOAnswerTest()
    {
        task = equationGenerator.CreateTaskTwo();
    }

    [TestMethod()]
    [ExpectedException(typeof(Exception))]
    public void EquationTaskTwoWAnswerTest()
    {
        double taskAnswer = 15;
        task = equationGenerator.CreateTaskTwo(taskAnswer);
    }

    [TestMethod()]
    [ExpectedException(typeof(Exception))]
    public void EquationTaskThreeWOAnswerTest()
    {
        task = equationGenerator.CreateTaskThree();
    }

    [TestMethod()]
    [ExpectedException(typeof(Exception))]
    public void EquationTaskThreeWAnswertest()
    {
        double taskAnswer = 20;
        task = equationGenerator.CreateTaskThree(taskAnswer);
    }

    [TestMethod()]
    [ExpectedException(typeof(Exception))]
    public void EquationTaskFourWOAnswerTest()
    {
        task = equationGenerator.CreateTaskFour();
    }

    [TestMethod()]
    [ExpectedException(typeof(Exception))]
    public void EquationTaskFourWAnswerTest()
    {
        double taskAnswer = 25;
        task = equationGenerator.CreateTaskFour(taskAnswer);
    }

    [TestMethod()]
    [ExpectedException(typeof(Exception))]
    public void EquationTaskFiveWOAnswerTest()
    {
        task = equationGenerator.CreateTaskFive();
    }

    [TestMethod()]
    [ExpectedException(typeof(Exception))]
    public void EquationTaskFiveWAnswerTest()
    {
        double taskAnswer = 30;
        task = equationGenerator.CreateTaskFive(taskAnswer);
    }

    [TestMethod()]
    [ExpectedException(typeof(Exception))]
    public void EquationTaskSixWOAnswerTest()
    {
        task = equationGenerator.CreateTaskSix();
    }

    [TestMethod()]
    [ExpectedException(typeof(Exception))]
    public void EquationTaskSixWAnswerTest()
    {
        double taskAnswer = 35;
        task = equationGenerator.CreateTaskSix(taskAnswer);
    }

    [TestMethod()]
    public void EquationTaskSevenType0WOAnswerTest()
    {
        Mock<Random> mockRnd = new();
        mockRnd.Setup(rand => rand.Next(0, 4)).Returns(0);
        equationGenerator = new EquationGenerator(mockRnd.Object);

        task = equationGenerator.CreateTaskSeven();
        double testAnswer = task.VariableThree - task.VariableOne - task.VariableTwo;

        Assert.AreEqual(task.Answer, Math.Round(testAnswer, 2));
    }

    [TestMethod()]
    [DynamicData(nameof(AnswerList))]
    public void EquationTaskSevenType0WAnswerTest(double taskAnswer)
    {
        Mock<Random> mockRnd = new();
        mockRnd.Setup(rand => rand.Next(0, 4)).Returns(0);
        equationGenerator = new EquationGenerator(mockRnd.Object);

        task = equationGenerator.CreateTaskSeven(taskAnswer);
        double testAnswer = task.VariableThree - task.VariableOne - task.VariableTwo;

        Assert.AreEqual(task.Answer, Math.Round(testAnswer, 2));
        Assert.AreEqual(taskAnswer, task.Answer);
    }

    [TestMethod()]
    public void EquationTaskSevenType1WOAnswerTest()
    {
        Mock<Random> mockRnd = new();
        mockRnd.Setup(rand => rand.Next(0, 4)).Returns(1);
        equationGenerator = new EquationGenerator(mockRnd.Object);

        task = equationGenerator.CreateTaskSeven();
        double testAnswer = task.VariableThree + task.VariableTwo - task.VariableOne;

        Assert.AreEqual(task.Answer, Math.Round(testAnswer, 2));
    }

    [TestMethod()]
    [DynamicData(nameof(AnswerList))]
    public void EquationTaskSevenType1WAnswerTest(double taskAnswer)
    {
        Mock<Random> mockRnd = new();
        mockRnd.Setup(rand => rand.Next(0, 4)).Returns(1);
        equationGenerator = new EquationGenerator(mockRnd.Object);

        task = equationGenerator.CreateTaskSeven(taskAnswer);
        double testAnswer = task.VariableThree + task.VariableTwo - task.VariableOne;

        Assert.AreEqual(task.Answer, Math.Round(testAnswer, 2));
        Assert.AreEqual(taskAnswer, task.Answer);
    }

    [TestMethod()]
    public void EquationTaskSeventype2WOAnswerTest()
    {
        Mock<Random> mockRnd = new();
        mockRnd.Setup(rand => rand.Next(0, 4)).Returns(2);
        equationGenerator = new EquationGenerator(mockRnd.Object);

        task = equationGenerator.CreateTaskSeven();
        double testAnswer = (task.VariableThree - task.VariableTwo) / task.VariableOne;

        Assert.AreEqual(task.Answer, Math.Round(testAnswer, 2));
    }

    [TestMethod()]
    [DynamicData(nameof(AnswerList))]
    public void EquationTaskSevenType2WAnswerTest(double taskAnswer)
    {
        Mock<Random> mockRnd = new();
        mockRnd.Setup(rand => rand.Next(0, 4)).Returns(2);
        equationGenerator = new EquationGenerator(mockRnd.Object);

        task = equationGenerator.CreateTaskSeven(taskAnswer);
        double testAnswer = (task.VariableThree - task.VariableTwo) / task.VariableOne;

        Assert.AreEqual(task.Answer, Math.Round(testAnswer, 2));
        Assert.AreEqual(taskAnswer, task.Answer);
    }

    [TestMethod()]
    public void EquationTaskSevenType3WOAnswerTest()
    {
        Mock<Random> mockRnd = new();
        mockRnd.Setup(rand => rand.Next(0, 4)).Returns(3);
        equationGenerator = new EquationGenerator(mockRnd.Object);

        task = equationGenerator.CreateTaskSeven();
        double testAnswer = (task.VariableOne - task.VariableThree) / task.VariableTwo;

        Assert.AreEqual(task.Answer, Math.Round(testAnswer, 2));
    }

    [TestMethod()]
    [DynamicData(nameof(AnswerList))]
    public void EquationTaskSevenType3WAnswerTest(double taskAnswer)
    {
        Mock<Random> mockRnd = new();
        mockRnd.Setup(rand => rand.Next(0, 4)).Returns(3);
        equationGenerator = new EquationGenerator(mockRnd.Object);

        task = equationGenerator.CreateTaskSeven(taskAnswer);
        double testAnswer = (task.VariableOne - task.VariableThree) / task.VariableTwo;

        Assert.AreEqual(task.Answer, Math.Round(testAnswer, 2));
        Assert.AreEqual(taskAnswer, task.Answer);
    }

    [TestMethod()]
    public void EquationTaskEightType4WOAnswerTest()
    {
        Mock<Random> mockRnd = new();
        mockRnd.Setup(rand => rand.Next(4, 10)).Returns(4);
        equationGenerator = new EquationGenerator(mockRnd.Object);

        task = equationGenerator.CreateTaskEight();
        double testAnswer = task.VariableThree - task.VariableOne - task.VariableTwo;

        Assert.AreEqual(task.Answer, Math.Round(testAnswer, 2));
    }

    [TestMethod()]
    [DynamicData(nameof(AnswerList))]
    public void EquationTaskEightType4WAnswerTest(double taskAnswer)
    {
        Mock<Random> mockRnd = new();
        mockRnd.Setup(rand => rand.Next(4, 10)).Returns(4);
        equationGenerator = new EquationGenerator(mockRnd.Object);

        task = equationGenerator.CreateTaskEight(taskAnswer);
        double testAnswer = task.VariableThree - task.VariableOne - task.VariableTwo;

        Assert.AreEqual(task.Answer, Math.Round(testAnswer, 2));
        Assert.AreEqual(taskAnswer, task.Answer);
    }

    [TestMethod()]
    public void EquationTaskEightType5WOAsnwerTest()
    {
        Mock<Random> mockRnd = new();
        mockRnd.Setup(rand => rand.Next(4, 10)).Returns(5);
        equationGenerator = new EquationGenerator(mockRnd.Object);

        task = equationGenerator.CreateTaskEight();
        double testAnswer = task.VariableThree - task.VariableOne + task.VariableTwo;

        Assert.AreEqual(task.Answer, Math.Round(testAnswer, 2));
    }

    [TestMethod()]
    [DynamicData(nameof(AnswerList))]
    public void EquationTaskEightType5WAnswerTest(double taskAnswer)
    {
        Mock<Random> mockRnd = new();
        mockRnd.Setup(rand => rand.Next(4, 10)).Returns(5);
        equationGenerator = new EquationGenerator(mockRnd.Object);

        task = equationGenerator.CreateTaskEight(taskAnswer);
        double testAnswer = task.VariableThree - task.VariableOne + task.VariableTwo;

        Assert.AreEqual(task.Answer, Math.Round(testAnswer, 2));
        Assert.AreEqual(taskAnswer, task.Answer);
    }

    [TestMethod()]
    public void EquationTaskEightType6WOAnswerTest()
    {
        Mock<Random> mockRnd = new();
        mockRnd.Setup(rand => rand.Next(4, 10)).Returns(6);
        equationGenerator = new EquationGenerator(mockRnd.Object);

        task = equationGenerator.CreateTaskEight();
        double testAnswer = task.VariableOne - task.VariableTwo - task.VariableThree;

        Assert.AreEqual(task.Answer, Math.Round(testAnswer, 2));
    }

    [TestMethod()]
    [DynamicData(nameof(AnswerList))]
    public void EquationTaskEightType6WAnswerTest(double taskAnswer)
    {
        Mock<Random> mockRnd = new();
        mockRnd.Setup(rand => rand.Next(4, 10)).Returns(6);
        equationGenerator = new EquationGenerator(mockRnd.Object);

        task = equationGenerator.CreateTaskEight(taskAnswer);
        double testAnswer = task.VariableOne - task.VariableTwo - task.VariableThree;

        Assert.AreEqual(task.Answer, Math.Round(testAnswer, 2));
        Assert.AreEqual(taskAnswer, task.Answer);
    }

    [TestMethod()]
    public void EquationTaskEightType7WOAnswerTest()
    {
        Mock<Random> mockRnd = new();
        mockRnd.Setup(rand => rand.Next(4, 10)).Returns(7);
        equationGenerator = new EquationGenerator(mockRnd.Object);

        task = equationGenerator.CreateTaskEight();
        double testAnswer = task.VariableOne + task.VariableTwo - task.VariableThree;

        Assert.AreEqual(task.Answer, Math.Round(testAnswer, 2));
    }

    [TestMethod()]
    [DynamicData(nameof(AnswerList))]
    public void EquationTaskEightType7WAnswerTest(double taskAnswer)
    {
        Mock<Random> mockRnd = new();
        mockRnd.Setup(rand => rand.Next(4, 10)).Returns(7);
        equationGenerator = new EquationGenerator(mockRnd.Object);

        task = equationGenerator.CreateTaskEight(taskAnswer);
        double testAnswer = task.VariableOne + task.VariableTwo - task.VariableThree;

        Assert.AreEqual(task.Answer, Math.Round(testAnswer, 2));
        Assert.AreEqual(taskAnswer, task.Answer);
    }

    [TestMethod()]
    public void EquationTaskEightType8WOAnswerTest()
    {
        Mock<Random> mockRnd = new();
        mockRnd.Setup(rand => rand.Next(4, 10)).Returns(8);
        equationGenerator = new EquationGenerator(mockRnd.Object);

        task = equationGenerator.CreateTaskEight();
        double testAnswer = task.VariableThree / task.VariableOne - task.VariableTwo;

        Assert.AreEqual(task.Answer, Math.Round(testAnswer, 2));
    }

    [TestMethod()]
    [DynamicData(nameof(AnswerList))]
    public void EquationTaskEightType8WAnswerTest(double taskAnswer)
    {
        Mock<Random> mockRnd = new();
        mockRnd.Setup(rand => rand.Next(4, 10)).Returns(8);
        equationGenerator = new EquationGenerator(mockRnd.Object);

        task = equationGenerator.CreateTaskEight(taskAnswer);
        double testAnswer = task.VariableThree / task.VariableOne - task.VariableTwo;

        Assert.AreEqual(task.Answer, Math.Round(testAnswer, 2));
        Assert.AreEqual(taskAnswer, task.Answer);
    }

    [TestMethod()]
    public void EquationTaskEightType9WOAnswerTest()
    {
        Mock<Random> mockRnd = new();
        mockRnd.Setup(rand => rand.Next(4, 10)).Returns(9);
        equationGenerator = new EquationGenerator(mockRnd.Object);

        task = equationGenerator.CreateTaskEight();
        double testAnswer = task.VariableThree / task.VariableOne + task.VariableTwo;

        Assert.AreEqual(task.Answer, Math.Round(testAnswer, 2));
    }

    [TestMethod()]
    [DynamicData(nameof(AnswerList))]
    public void EquationTaskEightType9WAnswerTest(double taskAnswer)
    {
        Mock<Random> mockRnd = new();
        mockRnd.Setup(rand => rand.Next(4, 10)).Returns(9);
        equationGenerator = new EquationGenerator(mockRnd.Object);

        task = equationGenerator.CreateTaskEight(taskAnswer);
        double testAnswer = task.VariableThree / task.VariableOne + task.VariableTwo;

        Assert.AreEqual(task.Answer, Math.Round(testAnswer, 2));
        Assert.AreEqual(taskAnswer, task.Answer);
    }

    [TestMethod()]
    public void EquationTaskNineType10WOAnswerTest()
    {
        Mock<Random> mockRnd = new();
        mockRnd.Setup(rand => rand.Next(10, 15)).Returns(10);
        equationGenerator = new EquationGenerator(mockRnd.Object);

        task = equationGenerator.CreateTaskNine();
        double testAnswer = task.VariableOne * task.VariableTwo / (task.VariableThree - task.VariableOne);

        Assert.AreEqual(task.Answer, Math.Round(testAnswer, 2));
    }

    [TestMethod()]
    [DynamicData(nameof(AnswerList))]
    public void EquationTaskNineType10WAnswerTest(double taskAnswer)
    {
        Mock<Random> mockRnd = new();
        mockRnd.Setup(rand => rand.Next(10, 15)).Returns(10);
        equationGenerator = new EquationGenerator(mockRnd.Object);

        task = equationGenerator.CreateTaskNine(taskAnswer);
        double testAnswer = task.VariableOne * task.VariableTwo / (task.VariableThree - task.VariableOne);

        Assert.AreEqual(task.Answer, Math.Round(testAnswer, 2));
        Assert.AreEqual(taskAnswer, task.Answer);
    }

    [TestMethod()]
    public void EquationTaskNineType11WOAnswerTest()
    {
        Mock<Random> mockRnd = new();
        mockRnd.Setup(rand => rand.Next(10, 15)).Returns(11);
        equationGenerator = new EquationGenerator(mockRnd.Object);

        task = equationGenerator.CreateTaskNine();
        double testAnswer = (task.VariableThree * task.VariableFour - task.VariableOne) / (task.VariableTwo - task.VariableThree);

        Assert.AreEqual(task.Answer, Math.Round(testAnswer, 2));
    }

    [TestMethod()]
    [DynamicData(nameof(AnswerList))]
    public void EquationTaskNineType11WAnswerTest(double taskAnswer)
    {
        Mock<Random> mockRnd = new();
        mockRnd.Setup(rand => rand.Next(10, 15)).Returns(11);
        equationGenerator = new EquationGenerator(mockRnd.Object);

        task = equationGenerator.CreateTaskNine(taskAnswer);
        double testAnswer = (task.VariableThree * task.VariableFour - task.VariableOne) / (task.VariableTwo - task.VariableThree);

        Assert.AreEqual(task.Answer, Math.Round(testAnswer, 2));
        Assert.AreEqual(taskAnswer, task.Answer);
    }

    [TestMethod()]
    public void EquationTaskNineType12WOAnswerTest()
    {
        Mock<Random> mockRnd = new();
        mockRnd.Setup(rand => rand.Next(10, 15)).Returns(12);
        equationGenerator = new EquationGenerator(mockRnd.Object);

        task = equationGenerator.CreateTaskNine();
        double testAnswer = (task.VariableTwo * task.VariableThree - task.VariableOne) / (task.VariableTwo - task.VariableFour);

        Assert.AreEqual(task.Answer, Math.Round(testAnswer, 2));
    }

    [TestMethod()]
    [DynamicData(nameof(AnswerList))]
    public void EquationTaskNineType12WAnswerTest(double taskAnswer)
    {
        Mock<Random> mockRnd = new();
        mockRnd.Setup(rand => rand.Next(10, 15)).Returns(12);
        equationGenerator = new EquationGenerator(mockRnd.Object);

        task = equationGenerator.CreateTaskNine(taskAnswer);
        double testAnswer = (task.VariableTwo * task.VariableThree - task.VariableOne) / (task.VariableTwo - task.VariableFour);

        Assert.AreEqual(task.Answer, Math.Round(testAnswer, 2));
        Assert.AreEqual(taskAnswer, task.Answer);
    }

    [TestMethod()]
    public void EquationTaskNineType13WOAnswerTest()
    {
        Mock<Random> mockRnd = new();
        mockRnd.Setup(rand => rand.Next(10, 15)).Returns(13);
        equationGenerator = new EquationGenerator(mockRnd.Object);

        task = equationGenerator.CreateTaskNine();
        double testAnswer = (task.VariableOne - task.VariableTwo * task.VariableThree) / (task.VariableTwo + task.VariableFour);

        Assert.AreEqual(task.Answer, Math.Round(testAnswer, 2));
    }

    [TestMethod()]
    [DynamicData(nameof(AnswerList))]
    public void EquationTaskNineType13WAnswerTest(double taskAnswer)
    {
        Mock<Random> mockRnd = new();
        mockRnd.Setup(rand => rand.Next(10, 15)).Returns(13);
        equationGenerator = new EquationGenerator(mockRnd.Object);

        task = equationGenerator.CreateTaskNine(taskAnswer);
        double testAnswer = (task.VariableOne - task.VariableTwo * task.VariableThree) / (task.VariableTwo + task.VariableFour);

        Assert.AreEqual(task.Answer, Math.Round(testAnswer, 2));
        Assert.AreEqual(taskAnswer, task.Answer);
    }

    [TestMethod()]
    public void EquationTaskNineType14WOAnswerTest()
    {
        Mock<Random> mockRnd = new();
        mockRnd.Setup(rand => rand.Next(10, 15)).Returns(14);
        equationGenerator = new EquationGenerator(mockRnd.Object);

        task = equationGenerator.CreateTaskNine();
        double testAnswer = (task.VariableTwo + task.VariableThree * task.VariableFour) / (task.VariableOne + task.VariableThree);

        Assert.AreEqual(task.Answer, Math.Round(testAnswer, 2));
    }

    [TestMethod()]
    [DynamicData(nameof(AnswerList))]
    public void EquationTasknineType14WAnswerTest(double taskAnswer)
    {
        Mock<Random> mockRnd = new();
        mockRnd.Setup(rand => rand.Next(10, 15)).Returns(14);
        equationGenerator = new EquationGenerator(mockRnd.Object);

        task = equationGenerator.CreateTaskNine(taskAnswer);
        double testAnswer = (task.VariableTwo + task.VariableThree * task.VariableFour) / (task.VariableOne + task.VariableThree);

        Assert.AreEqual(task.Answer, Math.Round(testAnswer, 2));
        Assert.AreEqual(taskAnswer, task.Answer);
    }
}