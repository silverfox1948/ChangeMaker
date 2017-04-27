using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedalTest3
{
	class Program
	{
		public static int countOfWays = 0;
		public static int currTotal = 0;
		public static int adjTarget = 0;
		public static int[] denomArray = new int[] { 20, 10, 5, 1 }; //.AsEnumerable();
		public static int[] maxCoeffArray = new int[] { 0, 0, 0, 0 };
		public static int[] currCoeffArray = new int[] { 0, 0, 0, 0 };
		public static int arrayLen = 0; // = currCoeffArray.Length;
		public static int flipIndex = 0;
		public static int onesIndex = 0;
		public static bool calcsDone = false;
		public static bool indexDone = false;

		static void Main(string[] args)
		{
			Array.Sort(denomArray);
			Array.Reverse(denomArray);
			adjTarget = 25;
			arrayLen = currCoeffArray.Length;
			onesIndex = arrayLen - 1;
			flipIndex = onesIndex - 1;
			CalcMaxCoeff();
			int i = 0;
			while (!calcsDone && i < 100)
			{
				CalcCount();
				i++;
			}
			Console.WriteLine("Done! count= {0}", countOfWays);
			Console.Read();
		}

		public static void CalcCount()
		{
			CalcCurrTotal();
			if (currTotal > adjTarget && flipIndex == 0)
			{
				calcsDone = true;
				return;
			}
			DumpCoeffArray("\ncurr total = " + currTotal.ToString() + " current coefficients: ");
			//Console.WriteLine("curr total= " + currTotal.ToString());
			//if (currTotal < adjTarget && currCoeffArray[onesIndex] == 0)
			//{
			//	IncrementCoeffArray();
			//}
			if (currTotal == adjTarget && currCoeffArray[onesIndex] == 0)
			{
				countOfWays++;
				Console.WriteLine("match! count = {0}", countOfWays);
			}
			if (currTotal < adjTarget && currCoeffArray[onesIndex] == 1)
			{
				countOfWays++;
				Console.WriteLine("ticked over to one! count = {0}", countOfWays);
			}
			IncrementCoeffArray();
			//if (currCoeffArray[0] > maxCoeffArray[0])
			//{
			//	calcsDone = true;
			//}
		}

		public static void IncrementCoeffArray()
		{
			if (currCoeffArray[onesIndex] == 0)
			{
				currCoeffArray[onesIndex] = 1;
			}
			else //current ones column == 1
			{
				currCoeffArray[onesIndex] = 0;
				IncrementLeft(onesIndex);
			}
			//DumpCoeffArray("after Increment");
		}

		public static void IncrementLeft(int index)
		{
			int limit = flipIndex; // we might increment flipindex
			bool done = false;
			for (int i = onesIndex - 1; (!done && i >= limit); i--)
			{
				currCoeffArray[i]++;
				if (currCoeffArray[i] > maxCoeffArray[i])
				{
					DumpCoeffArray(string.Format("i={0}, flipIndex={1}, ", i, flipIndex));
					if (i > 0)
					{
						currCoeffArray[i-1]++;
						ZeroRight(i);
						if (i == flipIndex)
						{
							flipIndex--;
						}
						done = true; 
					}
					else
					{
						done = true; //
					}
				}
				else
				{
					done = true;
				}
			}
		}

		public static void ZeroRight(int j)
		{
			for (int i = j; i <= onesIndex; i++)
			{
				currCoeffArray[i] = 0;
			}
		}

		public static void CalcCurrTotal()
		{
			currTotal = 0;
			for (int j = 0; j < onesIndex; j++)
			{
				currTotal = currTotal + denomArray[j] * currCoeffArray[j];
			}
		}

		public static void DumpCoeffArray(string message)
		{
			Console.WriteLine("{4} [{0}, {1}, {2}, {3}]", currCoeffArray[0], currCoeffArray[1], currCoeffArray[2], currCoeffArray[3], message);
		}

		public static void CalcMaxCoeff()
		{
			for (int i = 0; i < denomArray.Length; i++)
			{
				maxCoeffArray[i] = adjTarget / denomArray[i];
				if (denomArray[i] == 1)
				{
					maxCoeffArray[i] = 1;
				}
			}
		}
	}
}