using LogicLibrary.Enums;
using LogicLibrary.Modeller;
using LogicLibrary.Models;
using LogicLibrary.TaskGenerator;

namespace LogicLibrary.TreasureHunt;

public class LogicTwo : ILogic
{
    public string grade { get; set; } = "GradeTwo";

    public string taskTypes { get; set; } = "Elemental";

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
                // A whole number between 1 and 100. Used for Addition and subtraction.
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

        ITaskGenerator taskGenerator;

		task.TaskType = (TaskTypeEnum)rnd.Next(1, 3);

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
            throw new Exception("Error occured: Task type does not exist in grade two.");
        }

        return taskGenerator.CreateTaskTwo(task.Answer);
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
