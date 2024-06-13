using LogicLibrary.Enums;
using LogicLibrary.Modeller;
using LogicLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LogicLibrary.TreasureHunt;

public class LogicOne : ILogic
{
	public string grade { get; set; } = "GradeOne";

	public KeyPageModel CreateKeyPage()
	{
		KeyPageModel keyPage = new();
		Random rnd = new();
		bool unique;
		int number;
		AlphabetModel alphabet = new();
		alphabet.Alphabet = alphabet.CreateAlphabet();

		foreach (char c in alphabet.Alphabet)
		{
			KeyModel key = new();
			key.KeyLetter = c;

			do
			{
				unique = true;
				number = rnd.Next(1, 101);

				foreach (KeyModel entry in keyPage.LetterKeys)
				{
					if (entry.KeyNumber == number)
					{
						unique = false;
					}
				}
			} while (unique == false);

			key.KeyNumber = number;
			keyPage.LetterKeys.Add(key);
		}

		return keyPage;
	}

	public void PopulateOutpost(OutpostModel outpost, KeyPageModel keyPage)
	{
		outpost.Tasks.Clear();

		foreach (char letter in outpost.ReturnNameOnlyChars())
		{
			outpost.Tasks.Add(CreateTask(letter, keyPage));
		}
	}

	public TaskModel CreateTask(char letter, KeyPageModel keyPage)
	{
		TaskModel task = new();
		Random rnd = new();

		foreach (KeyModel key in keyPage.LetterKeys)
		{
			if (key.KeyLetter == char.ToUpper(letter))
			{
				task.Answer = key.KeyNumber;
			}
		}

		task.TaskType = (TaskTypeEnum)rnd.Next(0, 2);

		switch (task.TaskType)
		{
			case TaskTypeEnum.Addition:
				task.VariableOne = rnd.Next(1, Convert.ToInt16(task.Answer));
				task.VariableTwo = task.Answer - task.VariableOne;
				task.Question = $"{task.VariableOne} + {task.VariableTwo} =";
				break;

			case TaskTypeEnum.Subtraction:
				(task.VariableOne, task.VariableTwo) = MathLogic.GetMinuendAndSubtrahend(task.Answer);
				task.Question = $"{task.VariableOne} - {task.VariableTwo} =";
				break;
		}

		return task;
	}
}
