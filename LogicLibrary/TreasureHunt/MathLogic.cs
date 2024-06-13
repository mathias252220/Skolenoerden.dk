using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLibrary.TreasureHunt;

public static class MathLogic
{
	public static List<int> GetFactors(int number)
	{
		List<int> factors = new();
		factors.Add(1);
		factors.Add(number);

		var limit = Math.Ceiling(Math.Sqrt(number));

		for (int i = 2; i <= limit; i++)
		{
			if (number % i == 0)
			{
				factors.Add(i);
			}
		}

		return factors;
	}
	public static List<int> LimitOneFactor(List<int> factors, int maxFactorValue)
	{
		IEnumerable<int> query = from number in factors
								 where number > 1 && number <= maxFactorValue
								 select number;

		List<int> newFactors = new();

		foreach (int factor in query)
		{
			newFactors.Add(factor);
		}

		return newFactors;
	}
	public static List<int> LimitTwoFactors(List<int> factors, int maxFactorValue, int product)
	{
		List<int> newFactors = LimitOneFactor(factors, maxFactorValue);

		List<int> newFactors2 = new();

		foreach(int factor in newFactors)
		{
			int newFactor = product / factor;
			newFactors2.Add(newFactor);
		}

		List<int> factorsFinal = LimitOneFactor(newFactors2, maxFactorValue);

		return factorsFinal;
	}
	public static List<int> CreateProducts(int maxFactor1, int maxFactor2)
	{
		List<int> products = new();
		bool unique;
		int product;

		for (int i = 2; i <= maxFactor1; i++)
		{
			for (int j = 2; j <= maxFactor2; j++)
			{
				unique = true;
				product = i * j;

				foreach (int number in products)
				{
					if (number == product)
					{ unique = false; }
				}
				if (unique)
				{ products.Add(product); }
			}
		}
		return products;
	}
	public static (int, int) GetMinuendAndSubtrahend(double answer)
	{
		Random rnd = new();

        int answerInt = Convert.ToInt16(answer);
        int minDigit1;
        int minDigit2;
        int subDigit1;
        int subDigit2;

        if (answer.ToString().Length < 2)
        {
            minDigit1 = rnd.Next(0, 10);
            subDigit1 = minDigit1;
            minDigit2 = rnd.Next(answerInt, 10);
            subDigit2 = minDigit2 - answerInt;
        }
        else
        {
            minDigit1 = rnd.Next(answerInt / 10, 10);
            subDigit1 = minDigit1 - (answerInt / 10);
            minDigit2 = rnd.Next(answerInt % 10, 10);
            subDigit2 = minDigit2 - (answerInt % 10);
        }

		int minuend = int.Parse(minDigit1.ToString() + minDigit2.ToString());
		int subtrahend = int.Parse(subDigit1.ToString() + subDigit2.ToString());

		return (minuend, subtrahend);
	}
}
