using LogicLibrary.Models;

namespace LogicLibrary.TaskGenerator.Tests;

[TestClass()]
public class DivisionGeneratorTests
{
    DivisionGenerator divisionGenerator = new();
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
    public void DivisionTaskZeroWOAnswerTest()
    {
        task = divisionGenerator.CreateTaskZero();
    }

    [TestMethod()]
    [ExpectedException(typeof(Exception))]
    public void DivisionTaskZeroWAnswerTest()
    {
        double taskAnswer = 5;
        task = divisionGenerator.CreateTaskZero(taskAnswer);
    }

    [TestMethod()]
    [ExpectedException(typeof(Exception))]
    public void DivisionTaskOneWOAnswerTest()
    {
        task = divisionGenerator.CreateTaskOne();
    }

    [TestMethod()]
    [ExpectedException(typeof(Exception))]
    public void DivisionTaskOneWAnswerTest()
    {
        double taskAnswer = 10;
        task = divisionGenerator.CreateTaskOne(taskAnswer);
    }

    [TestMethod()]
    [ExpectedException(typeof(Exception))]
    public void DivisionTaskTwoWOAnswerTest()
    {
        task = divisionGenerator.CreateTaskTwo();
    }

    [TestMethod()]
    [ExpectedException(typeof(Exception))]
    public void DivisionTaskTwoWAnswerTest()
    {
        double taskAnswer = 15;
        task = divisionGenerator.CreateTaskTwo(taskAnswer);
    }

    [TestMethod()]
    [ExpectedException(typeof(Exception))]
    public void DivisionTaskThreeWOAnswerTest()
    {
        task = divisionGenerator.CreateTaskThree();
    }

    [TestMethod()]
    [ExpectedException(typeof(Exception))]
    public void DivisionTaskThreeWAnswerTest()
    {
        double taskAnswer = 20;
        task = divisionGenerator.CreateTaskThree(taskAnswer);
    }

    [TestMethod()]
    public void DivisionTaskFourWOAnswerTest()
    {
        task = divisionGenerator.CreateTaskFour();
        double testAnswer = task.VariableTwo / task.VariableOne;

        Assert.AreEqual(task.Answer, Math.Round(testAnswer,2));
    }

    [TestMethod()]
    [DynamicData(nameof(AnswerList))]
    public void DivisionTaskFourWAnswerTest(double taskAnswer)
    {
        task = divisionGenerator.CreateTaskFour(taskAnswer);
        double testAnswer = task.VariableTwo / task.VariableOne;

        Assert.AreEqual(task.Answer, Math.Round(testAnswer, 2));
        Assert.AreEqual(taskAnswer, task.Answer);
    }

    [TestMethod()]
    public void DivisionTaskFiveWOAnswerTest()
    {
        task = divisionGenerator.CreateTaskFive();
        double testAnswer = task.VariableTwo / task.VariableOne;

        Assert.AreEqual(task.Answer, Math.Round(testAnswer, 2)  );
    }

    [TestMethod()]
    [DynamicData(nameof(AnswerList))]
    public void DivisionTaskFiveWAnswerTest(double taskAnswer)
    {
        task = divisionGenerator.CreateTaskFive(taskAnswer);
        double testAnswer = task.VariableTwo / task.VariableOne;

        Assert.AreEqual(task.Answer, Math.Round(testAnswer, 2));
        Assert.AreEqual(taskAnswer, task.Answer);
    }

    [TestMethod()]
    public void DivisionTaskSixWOAnswerTest()
    {
        task = divisionGenerator.CreateTaskSix();
        double testAnswer = task.VariableTwo / task.VariableOne;

        Assert.AreEqual(task.Answer, Math.Round(testAnswer, 2));
    }

    [TestMethod()]
    [DynamicData(nameof(AnswerList))]
    public void DivisionTaskSixWAnswerTest(double taskAnswer)
    {
        task = divisionGenerator.CreateTaskSix(taskAnswer);
        double testAnswer = task.VariableTwo / task.VariableOne;

        Assert.AreEqual(task.Answer, Math.Round(testAnswer, 2));
        Assert.AreEqual(taskAnswer, task.Answer);
    }

    [TestMethod()]
    [ExpectedException(typeof(Exception))]
    public void DivisionTaskSevenWOAnswerTest()
    {
        task = divisionGenerator.CreateTaskSeven();
    }

    [TestMethod()]
    [ExpectedException(typeof(Exception))]
    public void DivisionTaskSevenWAnswerTest()
    {
        double taskAnswer = 45;
        task = divisionGenerator.CreateTaskSeven(taskAnswer);
    }

    [TestMethod()]
    [ExpectedException(typeof(Exception))]
    public void DivisionTaskEightWOAnswerTest()
    {
        task = divisionGenerator.CreateTaskEight();
    }

    [TestMethod()]
    [ExpectedException(typeof(Exception))]
    public void DivisionTaskEightWAnswerTest()
    {
        double taskAnswer = 50;
        task = divisionGenerator.CreateTaskEight(taskAnswer);
    }

    [TestMethod()]
    [ExpectedException(typeof(Exception))]
    public void DivisionTaskNineWOAnswerTest()
    {
        task = divisionGenerator.CreateTaskNine();
    }

    [TestMethod()]
    [ExpectedException(typeof(Exception))]
    public void DivisionTaskNineWAnswerTest()
    {
        double taskAnswer = 50;
        task = divisionGenerator.CreateTaskNine(taskAnswer);
	}
}