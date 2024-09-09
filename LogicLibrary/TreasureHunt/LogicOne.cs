using LogicLibrary.Enums;
using LogicLibrary.Modeller;
using LogicLibrary.Models;
using LogicLibrary.TaskGenerator;
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

    public string taskTypes { get; set; } = "Elemental";

    public KeyPageModel CreateKeyPage()
	{
		Random rnd = new();
		bool unique;
		int number;

        KeyPageModel keyPage = new();
        AlphabetModel alphabet = new();
		alphabet.Alphabet = alphabet.CreateAlphabet();

		foreach (char c in alphabet.Alphabet)
		{
			KeyModel key = new();
			key.KeyLetter = c;

			do
			{
                // A whole number between 1 and 100. Used for addition and subtraction tasks.
				number = rnd.Next(1, 101);
                unique = true;

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
        ITaskGenerator taskGenerator;

        if (task.TaskType == TaskTypeEnum.Addition)
        {
            taskGenerator = new AdditionGenerator();
        }
        else if (task.TaskType == TaskTypeEnum.Subtraction)
        {
            taskGenerator = new SubtractionGenerator();
        }
        else
        {
            throw new Exception("Error occured: Task type does not exist in grade one.");
        }

        return taskGenerator.CreateTaskOne(task.Answer);
	}

    private static void CreateSubtraction(TaskModel task)
    {
        (task.VariableOne, task.VariableTwo) = MathLogic.GetMinuendAndSubtrahend(task.Answer);
        task.Question = $"{task.VariableOne} - {task.VariableTwo} =";
    }

    public void PopulateOutpost(OutpostModel outpost, KeyPageModel keyPage)
    {
        outpost.Tasks.Clear();

        foreach (char letter in outpost.ReturnNameOnlyChars())
        {
            outpost.Tasks.Add(CreateTask(letter, keyPage));
        }
    }
}
