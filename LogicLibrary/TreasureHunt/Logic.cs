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
    }
}
