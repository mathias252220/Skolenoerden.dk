using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLibrary.Models
{
	public class AlphabetModel
	{
        public List<char> Alphabet { get; set; }

		public List<char> CreateAlphabet()
		{
			List<char> alphabet = new();

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
