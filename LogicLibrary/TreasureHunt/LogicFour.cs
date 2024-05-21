using LogicLibrary.Modeller;
using LogicLibrary.Models;
using LogicLibrary.Enums;

namespace LogicLibrary.TreasureHunt;

public class LogicFour : ILogic
{
	public string grade { get; set; } = "GradeFour";

	public KeyPageModel CreateKeyPage()
	{
		KeyPageModel keyPage = new();
		Random rnd = new();
		bool unique;
		int number;
		AlphabetModel alphabet = new();
		alphabet.Alphabet = alphabet.CreateAlphabet();
		List<int> products = MathLogic.CreateProducts(100);

		foreach (char c in alphabet.Alphabet)
		{
			KeyModel key = new();
			key.KeyLetter = c;


			do
			{
				unique = true;

				if (rnd.Next(0, 3) == 0)
				{
					number = products[rnd.Next(products.Count)];
				}
				else
				{
					number = rnd.Next(1, 1001);
				}

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

		List<int> possibleFactors = MathLogic.GetFactors(Convert.ToInt16(task.Answer));
		possibleFactors = MathLogic.LimitOneFactor(possibleFactors, 100);

		if (possibleFactors.Count > 0 && task.Answer <= 1000)
		{
			task.TaskType = (TaskTypeEnum)rnd.Next(0, 3);
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
				task.VariableOne = possibleFactors[rnd.Next(0, possibleFactors.Count)];
				task.VariableTwo = task.Answer / task.VariableOne;
				task.Question = $"{task.VariableOne} \u22C5 {task.VariableTwo} =";
				break;
		}

		return task;
	}
}