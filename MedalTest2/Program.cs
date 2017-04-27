using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedalTest2
{
	public class Program
	{
		public int countOfWays = 0;
		public int currTotal = 0;
		public int adjTarget = 0;
		public int[] denomArray = new int[] { 20, 10, 5, 1 }; //.AsEnumerable();
		public int[] maxCoeffArray = new int[] { 0, 0, 0, 0 };
		public int[] currCoeffArray = new int[] { 0, 0, 0, 0 };
		public int arrayLen = 0; // = currCoeffArray.Length;
		public int flipIndex = 0;
		public int onesIndex = 0;
		public bool calcsDone = false;
		public bool indexDone = false;

		static void Main(string[] args)
		{
			//medal test 2
			Array.Sort(denomArray);
			Array.Reverse(denomArray);
			adjTarget = 25;
			arrayLen = currCoeffArray.Length;
			onesIndex = arrayLen - 1;
			flipIndex = onesIndex - 1;
			CalcMaxCoeff();
			int i = 0;
			while (i < 15)//(!calcsDone)
			{
				CalcCount();
				i++;
			}
		}

		public void CalcCount()
		{
			CalcCurrTotal();
			DumpCoeffArray("curr total= " + currTotal.ToString() + "  current coeff array");
			if (currTotal < adjTarget && currCoeffArray[onesIndex] == 0)
			{
				IncrementCoeffArray();
			}
			if (currTotal == adjTarget && currCoeffArray[onesIndex] == 0)
			{
				countOfWays++;
				IncrementCoeffArray();
			}
			if (currTotal < adjTarget && currCoeffArray[onesIndex] == 1)
			{
				countOfWays++;
				IncrementCoeffArray();
			}
			DumpCoeffArray("curr total= " + currTotal.ToString() + "  current coeff array");
		}

		public void IncrementCoeffArray()
		{
			DumpCoeffArray("before Increment");
			if (currCoeffArray[onesIndex] == 0)
			{
				currCoeffArray[onesIndex] = 1;
			}
			else //current ones column == 1
			{
				currCoeffArray[onesIndex] = 0;
				IncrementLeft(onesIndex);
			}
			DumpCoeffArray("after Increment");
		}

		public void CalcCurrTotal()
		{
			currTotal = 0;
			for (int j = 0; j < onesIndex; j++)
			{
				currTotal = currTotal + denomArray[j] * currCoeffArray[j];
			}
		}

		public void IncrementLeft(int index)
		{
			for (int i = index - 1; flipIndex <= i; i--)
			{
				//Console.WriteLine("IncrementLeft i={0}", i);
				currCoeffArray[i]++;
				if (currCoeffArray[i] > maxCoeffArray[i])
				{
					currCoeffArray[i] = 0;
					IncrementLeft(i);
				}
			}
		}

		public void DumpCoeffArray(string message)
		{
			Console.WriteLine("{4} [{0}, {1}, {2}, {3}]", currCoeffArray[0], currCoeffArray[1], currCoeffArray[2], currCoeffArray[3], message);
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
			//maxCoeffArray.Dump();
		}
	}
}