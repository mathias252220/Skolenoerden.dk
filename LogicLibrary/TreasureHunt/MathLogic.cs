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
	public static List<int> LimitOneFactor(List<int> factors, int maxValue)
	{
		IEnumerable<int> query = from number in factors
								 where number > 1 && number <= maxValue
								 select number;

		List<int> newFactors = new();

		foreach (int factor in query)
		{
			newFactors.Add(factor);
		}

		return newFactors;
	}
	public static List<int> LimitTwoFactors(List<int> factors, int maxValue, int product)
	{
		List<int> newFactors = LimitOneFactor(factors, maxValue);

		List<int> newFactors2 = new();

		foreach(int factor in newFactors)
		{
			int newFactor = product / factor;
			newFactors2.Add(newFactor);
		}

		List<int> factorsFinal = LimitOneFactor(newFactors, maxValue);

		return factorsFinal;
	}
	public static List<int> CreateProducts(int maxFactor)
	{
		List<int> products = new();
		bool unique;
		int product;

		for (int i = 2; i <= maxFactor; i++)
		{
			for (int j = 2; j <= maxFactor; j++)
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
}
