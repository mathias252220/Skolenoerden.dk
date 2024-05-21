using LogicLibrary.Modeller;
using LogicLibrary.Enums;
using LogicLibrary.Models;

namespace LogicLibrary.TreasureHunt;

public class LogicThree : ILogic
{
	public string grade { get; set; } = "GradeThree";

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
				number = rnd.Next(1, 1001);

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

	public OutpostModel CreateOutpost(string outpostName, KeyPageModel keyPage)
	{
		OutpostModel outpost = new();
		outpost.Name = outpostName;

		foreach (char letter in outpost.ReturnNameNoSpaces())
		{
			outpost.Tasks.Add(CreateTask(letter, keyPage));
		}

		return outpost;
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

		List<int> possibleSolutions = MathLogic.GetFactors(Convert.ToInt16(task.Answer));
		possibleSolutions = MathLogic.LimitFactors(possibleSolutions, 10);

		if (possibleSolutions.Count > 0 && task.Answer <= 100)
		{
			task.TaskType = TaskTypeEnum.Gange;
		}
		else
		{
			task.TaskType = (TaskTypeEnum)rnd.Next(0, 2);
		}

		switch (task.TaskType)
		{
			case TaskTypeEnum.Plus:
				task.VariableOne = rnd.Next(1, Convert.ToInt16(task.Answer));
				task.VariableTwo = task.Answer - task.VariableOne;
				task.Question = $"{task.VariableOne} + {task.VariableTwo} =";
				break;

			case TaskTypeEnum.Minus:
				task.VariableOne = rnd.Next(Convert.ToInt16(task.Answer), 1001);
				task.VariableTwo = task.VariableOne - task.Answer;
				task.Question = $"{task.VariableOne} - {task.VariableTwo} =";
				break;

			case TaskTypeEnum.Gange:
				task.VariableOne = possibleSolutions[rnd.Next(0, possibleSolutions.Count)];
				task.VariableTwo = task.Answer / task.VariableOne;
				task.Question = $"{task.VariableOne} \u22C5 {task.VariableTwo} =";
				break;
		}

		return task;
	}
}
