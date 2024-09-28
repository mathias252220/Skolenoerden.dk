using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicLibrary.TaskGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using LogicLibrary.Models;

namespace LogicLibrary.TaskGenerator.Tests;

[TestClass()]
public class FractionGeneratorTests
{
    TaskModel task = new();
    FractionGenerator fractionGenerator = new();

    public static IEnumerable<object[]> AnswerList
    {
        get
        {
            return new[]
            {
                new object[] { 1 },
                new object[] { 2 },
                new object[] { 3 },
                new object[] { 4 },
                new object[] { 5 },
                new object[] { 6 },
                new object[] { 7 },
                new object[] { 8 },
                new object[] { 9 },
                new object[] { 10 },
            };
        }
    }

    [TestMethod()]
    [ExpectedException(typeof(Exception))]
    public void FractionTaskZeroWOAnswerTest()
    {
        task = fractionGenerator.CreateTaskZero();
    }

    [TestMethod()]
    [ExpectedException(typeof(Exception))]
    public void FractionTaskZeroWAnswerTest()
    {
        double taskAnswer = 1;
        task = fractionGenerator.CreateTaskZero(taskAnswer);
    }

    [TestMethod()]
    [ExpectedException(typeof(Exception))]
    public void FractionTaskOneWOAnswerTest()
    {
        task = fractionGenerator.CreateTaskOne();
    }

    [TestMethod()]
    [ExpectedException(typeof(Exception))]
    public void FractionTaskOneWAnswerTest()
    {
        double taskAnswer = 2;
        task = fractionGenerator.CreateTaskOne(taskAnswer);
    }

    [TestMethod()]
    [ExpectedException(typeof(Exception))]
    public void FractionTaskTwoWOAnswerTest()
    {
        task = fractionGenerator.CreateTaskTwo();
    }

    [TestMethod()]
    [ExpectedException(typeof(Exception))]
    public void FractionTaskTwoWAnswerTest()
    {
        double taskAnswer = 3;
        task = fractionGenerator.CreateTaskTwo(taskAnswer);
    }

    [TestMethod()]
    [ExpectedException(typeof(Exception))]
    public void FractionTaskThreeWOAnswerTest()
    {
        task = fractionGenerator.CreateTaskThree();
    }

    [TestMethod()]
    [ExpectedException(typeof(Exception))]
    public void FractionTaskThreeWAnswerTest()
    {
        double taskAnswer = 4;
        task = fractionGenerator.CreateTaskThree(taskAnswer);
    }

    [TestMethod()]
    [ExpectedException(typeof(Exception))]
    public void FractionTaskFourWOAnswerTest()
    {
        task = fractionGenerator.CreateTaskFour();
    }

    [TestMethod()]
    [ExpectedException(typeof(Exception))]
    public void FractionTaskFourWAnswerTest()
    {
        double taskAnswer = 5;
        task = fractionGenerator.CreateTaskFour(taskAnswer);
    }

    [TestMethod()]
    [ExpectedException(typeof(Exception))]
    public void FractionTaskFiveWOAnswerTest()
    {
        task = fractionGenerator.CreateTaskFive();
    }

    [TestMethod()]
    [ExpectedException(typeof(Exception))]
    public void FractionTaskFiveWAnswerTest()
    {
        double taskAnswer = 6;
        task = fractionGenerator.CreateTaskFive(taskAnswer);
    }

    [TestMethod()]
    [ExpectedException(typeof(Exception))]
    public void FractionTaskSixWOAnswerTest()
    {
        task = fractionGenerator.CreateTaskSix();
    }

    [TestMethod()]
    [ExpectedException(typeof(Exception))]
    public void FractionTaskSixWAnswerTest()
    {
        double taskAnswer = 7;
        task = fractionGenerator.CreateTaskSix(taskAnswer);
    }

    [TestMethod()]
    public void FractionTaskSevenType0WOAnswerTest()
    {
        Mock<Random> mockRnd = new();
        mockRnd.Setup(rand => rand.Next(0, 4)).Returns(0);
        fractionGenerator = new FractionGenerator(mockRnd.Object);

        task = fractionGenerator.CreateTaskSeven();
        double testAnswer = task.VariableOne + task.VariableTwo;

        Assert.AreEqual(Math.Round(task.Answer, 2), Math.Round(testAnswer,2 ));
    }

    [TestMethod()]
    [DynamicData(nameof(AnswerList))]
    public void FractionTaskSevenType0WAnswerTest(double taskAnswer)
    {
        Mock<Random> mockRnd = new();
        mockRnd.Setup(rand => rand.Next(0, 4)).Returns(0);
        fractionGenerator = new FractionGenerator(mockRnd.Object);

        task = fractionGenerator.CreateTaskSeven(taskAnswer);
        double testAnswer = task.VariableOne + task.VariableTwo;

        Assert.AreEqual(Math.Round(task.Answer, 2), Math.Round(testAnswer, 2));
        Assert.AreEqual(taskAnswer, Math.Round(task.Answer));
    }

    [TestMethod()]
    public void FractionTaskSevenType1WOAnswerTest()
    {
        Mock<Random> mockRnd = new();
        mockRnd.Setup(rand => rand.Next(0, 4)).Returns(1);
        fractionGenerator = new FractionGenerator(mockRnd.Object);

        task = fractionGenerator.CreateTaskSeven();
        double testAnswer = task.VariableOne - task.VariableTwo;

        Assert.AreEqual(Math.Round(task.Answer, 2), Math.Round(testAnswer, 2));
    }

    [TestMethod()]
    [DynamicData(nameof(AnswerList))]
    public void FractionTaskSevenType1WAnswerTest(double taskAnswer)
    {
        Mock<Random> mockRnd = new();
        mockRnd.Setup(rand => rand.Next(0, 4)).Returns(1);
        fractionGenerator = new FractionGenerator(mockRnd.Object);

        task = fractionGenerator.CreateTaskSeven(taskAnswer);
        double testAnswer = task.VariableOne - task.VariableTwo;

        Assert.AreEqual(Math.Round(task.Answer, 2), Math.Round(testAnswer, 2));
        Assert.AreEqual(taskAnswer, Math.Round(task.Answer));
    }

    [TestMethod()]
    public void FractionTaskSevenType2WOAnswerTest()
    {
        Mock<Random> mockRnd = new();
        mockRnd.Setup(rand => rand.Next(0, 4)).Returns(2);
        fractionGenerator = new FractionGenerator(mockRnd.Object);

        task = fractionGenerator.CreateTaskSeven();
        double testAnswer = task.VariableOne * task.VariableTwo;

        Assert.AreEqual(Math.Round(task.Answer, 2), Math.Round(testAnswer, 2));
    }

    [TestMethod()]
    [DynamicData(nameof(AnswerList))]
    public void FractionTaskSevenType2WAnswerTest(double taskAnswer)
    {
        Mock<Random> mockRnd = new();
        mockRnd.Setup(rand => rand.Next(0, 4)).Returns(2);
        fractionGenerator = new FractionGenerator(mockRnd.Object);

        task = fractionGenerator.CreateTaskSeven(taskAnswer);
        double testAnswer = task.VariableOne * task.VariableTwo;

        Assert.AreEqual(Math.Round(task.Answer, 2), Math.Round(testAnswer, 2));
        Assert.AreEqual(taskAnswer, Math.Round(task.Answer));
    }

    [TestMethod()]
    public void FractionTaskSevenType3WOAnswerTest()
    {
        Mock<Random> mockRnd = new();
        mockRnd.Setup(rand => rand.Next(0, 4)).Returns(3);
        fractionGenerator = new FractionGenerator(mockRnd.Object);

        task = fractionGenerator.CreateTaskSeven();
        double testAnswer = task.VariableOne / task.VariableTwo;

        Assert.AreEqual(Math.Round(task.Answer, 2), Math.Round(testAnswer, 2));
    }

    [TestMethod()]
    [DynamicData(nameof(AnswerList))]
    public void FractionTaskSevenType3WAnswerTest(double taskAnswer)
    {
        Mock<Random> mockRnd = new();
        mockRnd.Setup(rand => rand.Next(0, 4)).Returns(3);
        fractionGenerator = new FractionGenerator(mockRnd.Object);

        task = fractionGenerator.CreateTaskSeven(taskAnswer);
        double testAnswer = task.VariableOne / task.VariableTwo;

        Assert.AreEqual(Math.Round(task.Answer, 2), Math.Round(testAnswer, 2));
        Assert.AreEqual(taskAnswer, Math.Round(task.Answer));
    }

    [TestMethod()]
    public void FractionTaskEightType0WOAnswerTest()
    {
        Mock<Random> mockRnd = new();
        mockRnd.Setup(rand => rand.Next(0, 4)).Returns(0);
        fractionGenerator = new FractionGenerator(mockRnd.Object);

        task = fractionGenerator.CreateTaskEight();
        double testAnswer = task.VariableOne + task.VariableTwo;

        Assert.AreEqual(Math.Round(task.Answer, 2), Math.Round(testAnswer, 2));
    }

    [TestMethod()]
    [DynamicData(nameof(AnswerList))]
    public void FractionTaskEightType0WAnswerTest(double taskAnswer)
    {
        Mock<Random> mockRnd = new();
        mockRnd.Setup(rand => rand.Next(0, 4)).Returns(0);
        fractionGenerator = new FractionGenerator(mockRnd.Object);

        task = fractionGenerator.CreateTaskEight(taskAnswer);
        double testAnswer = task.VariableOne + task.VariableTwo;

        Assert.AreEqual(Math.Round(task.Answer, 2), Math.Round(testAnswer, 2));
        Assert.AreEqual(taskAnswer, Math.Round(task.Answer));
    }

    [TestMethod()]
    public void FractionTaskEightType1WOAnswerTest()
    {
        Mock<Random> mockRnd = new();
        mockRnd.Setup(rand => rand.Next(0, 4)).Returns(1);
        fractionGenerator = new FractionGenerator(mockRnd.Object);

        task = fractionGenerator.CreateTaskEight();
        double testAnswer = task.VariableOne - task.VariableTwo;

        Assert.AreEqual(Math.Round(task.Answer, 2), Math.Round(testAnswer, 2));
    }

    [TestMethod()]
    [DynamicData(nameof(AnswerList))]
    public void FractionTaskEightType1WAnswerTest(double taskAnswer)
    {
        Mock<Random> mockRnd = new();
        mockRnd.Setup(rand => rand.Next(0, 4)).Returns(1);
        fractionGenerator = new FractionGenerator(mockRnd.Object);

        task = fractionGenerator.CreateTaskEight(taskAnswer);
        double testAnswer = task.VariableOne - task.VariableTwo;

        Assert.AreEqual(Math.Round(task.Answer, 2), Math.Round(testAnswer, 2));
        Assert.AreEqual(taskAnswer, Math.Round(task.Answer));
    }

    [TestMethod()]
    public void FractionTaskEightType2WOAnswerTest()
    {
        Mock<Random> mockRnd = new();
        mockRnd.Setup(rand => rand.Next(0, 4)).Returns(2);
        fractionGenerator = new FractionGenerator(mockRnd.Object);

        task = fractionGenerator.CreateTaskEight();
        double testAnswer = task.VariableOne * task.VariableTwo;

        Assert.AreEqual(Math.Round(task.Answer, 2), Math.Round(testAnswer, 2));
    }

    [TestMethod()]
    [DynamicData(nameof(AnswerList))]
    public void FractionTaskEightType2WAnswerTest(double taskAnswer)
    {
        Mock<Random> mockRnd = new();
        mockRnd.Setup(rand => rand.Next(0, 4)).Returns(2);
        fractionGenerator = new FractionGenerator(mockRnd.Object);

        task = fractionGenerator.CreateTaskEight(taskAnswer);
        double testAnswer = task.VariableOne * task.VariableTwo;

        Assert.AreEqual(Math.Round(task.Answer, 2), Math.Round(testAnswer, 2));
        Assert.AreEqual(taskAnswer, Math.Round(task.Answer));
    }

    [TestMethod()]
    public void FractionTaskEightType3WOAnswerTest()
    {
        Mock<Random> mockRnd = new();
        mockRnd.Setup(rand => rand.Next(0, 4)).Returns(3);
        fractionGenerator = new FractionGenerator(mockRnd.Object);

        task = fractionGenerator.CreateTaskEight();
        double testAnswer = task.VariableOne / task.VariableTwo;

        Assert.AreEqual(Math.Round(task.Answer, 2), Math.Round(testAnswer, 2));
    }

    [TestMethod()]
    [DynamicData(nameof(AnswerList))]
    public void FractionTaskEightType3WAnswerTest(double taskAnswer)
    {
        Mock<Random> mockRnd = new();
        mockRnd.Setup(rand => rand.Next(0, 4)).Returns(3);
        fractionGenerator = new FractionGenerator(mockRnd.Object);

        task = fractionGenerator.CreateTaskEight(taskAnswer);
        double testAnswer = task.VariableOne / task.VariableTwo;

        Assert.AreEqual(Math.Round(task.Answer, 2), Math.Round(testAnswer, 2));
        Assert.AreEqual(taskAnswer, Math.Round(task.Answer));
    }

    [TestMethod()]
    public void FractionTaskNineType0WOAnswerTest()
    {
        Mock<Random> mockRnd = new();
        mockRnd.Setup(rand => rand.Next(0, 4)).Returns(0);
        fractionGenerator = new FractionGenerator(mockRnd.Object);

        task = fractionGenerator.CreateTaskNine();
        double testAnswer = task.VariableOne + task.VariableTwo;

        Assert.AreEqual(Math.Round(task.Answer, 2), Math.Round(testAnswer, 2));
    }

    [TestMethod()]
    [DynamicData(nameof(AnswerList))]
    public void FractionTaskNineType0WAnswerTest(double taskAnswer)
    {
        Mock<Random> mockRnd = new();
        mockRnd.Setup(rand => rand.Next(0, 4)).Returns(0);
        fractionGenerator = new FractionGenerator(mockRnd.Object);

        task = fractionGenerator.CreateTaskNine(taskAnswer);
        double testAnswer = task.VariableOne + task.VariableTwo;

        Assert.AreEqual(Math.Round(task.Answer, 2), Math.Round(testAnswer, 2));
        Assert.AreEqual(taskAnswer, Math.Round(task.Answer));
    }

    [TestMethod()]
    public void FractionTaskNineType1WOAnswerTest()
    {
        Mock<Random> mockRnd = new();
        mockRnd.Setup(rand => rand.Next(0, 4)).Returns(() => 1);
        fractionGenerator = new FractionGenerator(mockRnd.Object);

        task = fractionGenerator.CreateTaskNine();
        double testAnswer = task.VariableOne - task.VariableTwo;

        Assert.AreEqual(Math.Round(task.Answer, 2), Math.Round(testAnswer, 2));
    }

    [TestMethod()]
    [DynamicData(nameof(AnswerList))]
    public void FractionTaskNineType1WAnswerTest(double taskAnswer)
    {
        Mock<Random> mockRnd = new();
        mockRnd.Setup(rand => rand.Next(0, 4)).Returns(() => 1);
        fractionGenerator = new FractionGenerator(mockRnd.Object);

        task = fractionGenerator.CreateTaskNine(taskAnswer);
        double testAnswer = task.VariableOne - task.VariableTwo;

        Assert.AreEqual(Math.Round(task.Answer, 2), Math.Round(testAnswer, 2));
        Assert.AreEqual(taskAnswer, Math.Round(task.Answer));
    }

    [TestMethod()]
    public void FractionTaskNineType2WOAnswerTest()
    {
        Mock<Random> mockRnd = new();
        mockRnd.Setup(rand => rand.Next(0, 4)).Returns(() => 2);
        fractionGenerator = new FractionGenerator(mockRnd.Object);

        task = fractionGenerator.CreateTaskNine();
        double testAnswer = task.VariableOne * task.VariableTwo;

        Assert.AreEqual(Math.Round(task.Answer, 2), Math.Round(testAnswer, 2));
    }

    [TestMethod()]
    [DynamicData(nameof(AnswerList))]
    public void FractionTaskNineType2WAnswerTest(double taskAnswer)
    {
        Mock<Random> mockRnd = new();
        mockRnd.Setup(rand => rand.Next(0, 4)).Returns(() => 2);
        fractionGenerator = new FractionGenerator(mockRnd.Object);

        task = fractionGenerator.CreateTaskNine(taskAnswer);
        double testAnswer = task.VariableOne * task.VariableTwo;

        Assert.AreEqual(Math.Round(task.Answer, 2), Math.Round(testAnswer, 2));
        Assert.AreEqual(taskAnswer, Math.Round(task.Answer));
    }

    [TestMethod()]
    public void FractionTaskNineType3WOAnswerTest()
    {
        Mock<Random> mockRnd = new();
        mockRnd.Setup(rand => rand.Next(0, 4)).Returns(() => 3);
        fractionGenerator = new FractionGenerator(mockRnd.Object);

        task = fractionGenerator.CreateTaskNine();
        double testAnswer = task.VariableOne / task.VariableTwo;

        Assert.AreEqual(Math.Round(task.Answer, 2), Math.Round(testAnswer, 2));
    }

    [TestMethod()]
    [DynamicData(nameof(AnswerList))]
    public void FractionTaskNineType3WAnswerTest(double taskAnswer)
    {
        Mock<Random> mockRnd = new();
        mockRnd.Setup(rand => rand.Next(0, 4)).Returns(() => 3);
        fractionGenerator = new FractionGenerator(mockRnd.Object);

        task = fractionGenerator.CreateTaskNine(taskAnswer);
        double testAnswer = task.VariableOne / task.VariableTwo;

        Assert.AreEqual(Math.Round(task.Answer, 2), Math.Round(testAnswer, 2));
        Assert.AreEqual(taskAnswer, Math.Round(task.Answer));
    }
}