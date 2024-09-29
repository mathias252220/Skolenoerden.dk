using LogicLibrary.Modeller;
using LogicLibrary.Enums;
using LogicLibrary.Models;
using LogicLibrary.TaskGenerator;

namespace LogicLibrary.TreasureHunt;

public class LogicThree : ILogic
{
	public string grade { get; set; } = "GradeThree";
    public string taskTypes { get; set; } = "Elemental";

    public KeyPageModel CreateKeyPage()
	{
		KeyPageModel keyPage = new();
		Random rnd = new();
		bool unique;
		int number;
		AlphabetModel alphabet = new();
		alphabet.Alphabet = alphabet.CreateAlphabet();
		List<int> products = MathLogic.CreateProducts(10, 10);

		foreach (char c in alphabet.Alphabet)
		{
			KeyModel key = new();
			key.KeyLetter = c;

			do
			{
				unique = true;

                // A non-prime whole number between 1 and 100. Used for multiplication tasks.
				if (rnd.Next(0, 3) == 0)
				{
					number = products[rnd.Next(0, products.Count)];

				} else
                // A whole number between 1 and 1000. Used for addition and subtraction tasks.
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
		possibleFactors = MathLogic.LimitTwoFactors(possibleFactors, 10, Convert.ToInt16(task.Answer));

        ITaskGenerator taskGenerator;

		if (possibleFactors.Count > 0 && task.Answer <= 100)
		{
			task.TaskType = TaskTypeEnum.Multiplication;
		}
		else
		{
			task.TaskType = (TaskTypeEnum)rnd.Next(1, 3);
		}

        if (task.TaskType == TaskTypeEnum.Addition)
        {
            taskGenerator = new AdditionGenerator();
        }
        else if (task.TaskType == TaskTypeEnum.Subtraction)
        {
            taskGenerator = new SubtractionGenerator();
        }
        else if (task.TaskType == TaskTypeEnum.Multiplication)
        {
            taskGenerator = new MultiplicationGenerator();
        }
        else
        {
            throw new Exception("Error occured: Task type does not exist in grade three");
        }

		return taskGenerator.CreateTaskThree(task.Answer);
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
