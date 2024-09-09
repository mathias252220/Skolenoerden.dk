using LogicLibrary.Enums;
using LogicLibrary.Modeller;
using LogicLibrary.Models;
using LogicLibrary.TaskGenerator;

namespace LogicLibrary.TreasureHunt;

public class LogicZero : ILogic
{
	public string grade { get; set; } = "GradeZero";

    public string taskTypes { get; set; } = "Elemental";

    public KeyPageModel CreateKeyPage()
	{
		Random rnd = new();
		bool unique;
		int number;

        KeyPageModel keyPage = new();
        AlphabetModel alphabet = new();
		alphabet.Alphabet = alphabet.CreateAlphabet();

		foreach(char c in alphabet.Alphabet)
		{
			KeyModel key = new();
			key.KeyLetter = c;

			do
			{
                // A random whole number between 1 and 40. Used for addition tasks.
				unique = true;
				number = rnd.Next(1, 41);

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
        ITaskGenerator taskGenerator;
		foreach (KeyModel key in keyPage.LetterKeys)
		{
			if (key.KeyLetter == char.ToUpper(letter))
			{
                taskGenerator = new AdditionGenerator();
                return taskGenerator.CreateTaskZero(key.KeyNumber);
			}
		}

        throw new Exception("An error occured: KeyNumber not found, when creating task");
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
