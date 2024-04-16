using LogicLibrary.Enums;
using LogicLibrary.Modeller;
using LogicLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLibrary.Logic
{
    public class Logic : ILogic
    {
        public KeyPageModel CreateKeyPage()
        {
            KeyPageModel keyPage = new KeyPageModel();
            Random rnd = new Random();
            bool unique;
            int number;
            List<char> alphabet = CreateAlphabet();

            foreach (char c in alphabet)
            {
                KeyModel key = new KeyModel();
                key.KeyLetter = c;

                do
                {
                    unique = true;
                    number = rnd.Next(1, 100);

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

        public List<char> CreateAlphabet()
        {
            List<char> alphabet = new List<char>();

            for (char letter = 'A'; letter <= 'Z'; letter++)
            {
                alphabet.Add(letter);
            }

            alphabet.Add('Æ');
            alphabet.Add('Ø');
            alphabet.Add('Å');

            return alphabet;
        }
        public OutpostModel CreateOutpost(string outpostName, KeyPageModel keyPage)
        {
            OutpostModel outpost = new OutpostModel();
            outpost.Name = outpostName;

            foreach(char letter in outpost.ReturnNameNoSpaces())
            {
                outpost.Tasks.Add(CreateTask(letter, keyPage));
            }

            return outpost;
        }
        public TaskModel CreateTask(char letter, KeyPageModel keyPage)
        {
            TaskModel task = new TaskModel();
            Random rnd = new Random();

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
                case TaskTypeEnum.Plus:
                    task.VariableOne = rnd.Next(1, Convert.ToInt16(task.Answer));
                    task.VariableTwo = task.Answer - task.VariableOne;
                    task.Question = $"{task.VariableOne} + {task.VariableTwo} =";
                    break;

                case TaskTypeEnum.Minus:
                    task.VariableOne = rnd.Next(Convert.ToInt16(task.Answer), 100);
                    task.VariableTwo = task.VariableOne - task.Answer;
                    task.Question = $"{task.VariableOne} - {task.VariableTwo} =";
                    break;
            }

            return task;
        }
    }
}
