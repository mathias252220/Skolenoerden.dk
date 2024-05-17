using LogicLibrary.Enums;
using LogicLibrary.Modeller;
using LogicLibrary.Models;
using LogicLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLibrary.TreasureHunt
{
	public class LogicZero : ILogic
	{
		public GradeEnum grade { get; set; } = GradeEnum.GradeZero;
        public KeyPageModel CreateKeyPage()
		{
			KeyPageModel keyPage = new();
			Random rnd = new();
			bool unique;
			int number;
			AlphabetModel alphabet = new();
			alphabet.Alphabet = alphabet.CreateAlphabet();

			foreach(char c in alphabet.Alphabet)
			{
				KeyModel key = new();
				key.KeyLetter = c;

				do
				{
					unique = true;
					number = rnd.Next(1, 30);

					foreach (KeyModel entry in keyPage.LetterKeys)
					{
						if (entry.KeyLetter == number)
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

			task.TaskType = (TaskTypeEnum)rnd.Next(0, 1);

			switch (task.TaskType)
			{
				case TaskTypeEnum.Plus:
					task.VariableOne = rnd.Next(1, Convert.ToInt16(task.Answer));
					task.VariableTwo = task.Answer - task.VariableOne;
					task.Question = $"{task.VariableOne} + {task.VariableTwo} =";
					break;
			}

			return task;
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
	}
}
