using System;
using System.Collections.Generic;

namespace MedalChangeMaker
{
	public class ChangeMaker
	{
		int[]denomArray;
		int[]maxCoeffArray;
		int changeFor;
		int adjTarget;
		int countOfWays;
		int currTotal;

		public ChangeMaker()
		{}

		public int CalculateNumberOfWays(int changeAmount, List<int> denominations)
		{
			denomArray = denominations.ToArray();
			changeFor = changeAmount;
			//Array.Sort(denomArray);
			maxCoeffArray = new int[denomArray.Length];
			Console.WriteLine("sorted denomArray:: [{0}, {1}, {2}, {3}]", denomArray[0], denomArray[1], denomArray[2], denomArray[3]);
			adjTarget = (changeFor / denomArray[1]) * denomArray[1];
			Console.WriteLine("adjusted target from {0} to {1}", changeFor, adjTarget);
			CalcMaxCoeff();
			CountSums();
			Console.WriteLine("\nNumber of ways to make change: {0}", countOfWays);
			return countOfWays;
		}

		public void CountSums()
		{
			for (int i = 0; i <= maxCoeffArray[0]; i++)
			{
				var icoeff = i;
				for (int j = 0; j <= maxCoeffArray[1]; j++)
				{
					var jcoeff = j;
					for (int k = 0; k <= maxCoeffArray[2]; k++)
					{
						var kcoeff = k;
						for (int m = 0; m <= maxCoeffArray[3]; m++)
						{
							var mcoeff = m;
							currTotal = denomArray[0] * i + denomArray[1] * j + denomArray[2] * k;
							if (currTotal <= adjTarget)
							{
								switch (mcoeff)
								{
									case 0:
										if (currTotal == adjTarget)
											countOfWays++;
										break;
									case 1:
										if (currTotal != adjTarget)
											countOfWays++;
										break;
								}
							}
							Console.WriteLine("[{0}, {1}, {2}, {3}] = {4} count = {5}", icoeff, jcoeff, kcoeff, mcoeff, currTotal, countOfWays);
						}
					}
				}
			}
		}

		public void CalcCurrTotal(int i, int j, int k, int m)
		{
			currTotal = denomArray[0] * i + denomArray[1] * j + denomArray[2] * k + denomArray[3] * m;
		}

		public void CalcMaxCoeff()
		{
			for (int i = 0; i < denomArray.Length; i++)
			{
				maxCoeffArray[i] = adjTarget / denomArray[i];
				if (denomArray[i] == 1)
				{
					maxCoeffArray[i] = 1;
				}
			}
			Console.WriteLine("maxcoeffArray:: [{0}, {1}, {2}, {3}]", maxCoeffArray[0], maxCoeffArray[1], maxCoeffArray[2], maxCoeffArray[3]);
		}
	}
}
