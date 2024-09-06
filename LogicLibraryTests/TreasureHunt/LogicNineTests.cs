using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicLibrary.TreasureHunt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLibrary.Models;
using LogicLibrary.Modeller;

namespace LogicLibrary.TreasureHunt.Tests;

[TestClass()]
public class LogicNineTests
{
    [TestMethod()]
    public void CreateTaskTest()
    {
        KeyModel key = new();
        key.KeyNumber = 15;
        key.KeyLetter = 'A';
        List<KeyModel> list = new();
        list.Add(key);
        KeyPageModel keyPage = new();
        keyPage.LetterKeys = list;
        LogicNine logic = new();
        TaskModel task = logic.CreateTask('A', keyPage);

        bool variableOneIsDecimal = task.VariableOne % 1 != 0;
        bool variableTwoIsDecimal = task.VariableTwo % 1 != 0;
        bool variableThreeIsDecimal = task.VariableThree % 1 != 0;
        bool variableFourIsDecimal = task.VariableFour % 1 != 0;

        Assert.AreEqual(15, task.Answer);
        Assert.IsFalse(variableOneIsDecimal);
        Assert.IsFalse(variableTwoIsDecimal);
        Assert.IsFalse(variableThreeIsDecimal);
        Assert.IsFalse(variableFourIsDecimal);
	}
}