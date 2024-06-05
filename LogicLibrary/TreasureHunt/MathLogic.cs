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
	public static (int, int) GetMinuendAndSubtrahend()
	{
		Random rnd = new();

		int digit1 = rnd.Next(0, 10);
		int digit2 = rnd.Next(0, 10);
		int digit3 = rnd.Next(0, 10);
		int digit4 = rnd.Next(0, 10);

		int minuend = int.Parse(Math.Max(digit1, digit2).ToString() + Math.Max(digit3, digit4).ToString());
		int subtrahend = int.Parse(Math.Min(digit1, digit2).ToString() + Math.Min(digit3, digit4).ToString());

		return (minuend, subtrahend);
	}
	public static double NextDouble(int minValue, int maxValue, int numberOfDecimals)
	{
		Random rnd = new();
		int wholeNumber = rnd.Next(minValue, maxValue);
		string numberString = wholeNumber.ToString() + ",";

		for (int i = 0;  i < numberOfDecimals; i++)
		{
			int digit = rnd.Next(0, 10);
			numberString = $"{numberString}{digit}";
		}

		return Math.Round(double.Parse(numberString), 2);
	}
}
