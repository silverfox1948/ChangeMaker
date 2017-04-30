using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursive
{
	class ChangeCounter
	{
		int[] denomArray; // array of denominations available
		int[] maxCoeffArray; //uses integer divide to set max possible value
		int[] currCoeffArray; // current coefficients for corresponding denominations
		int changeFor;
		int countOfWays;
		int currTotal;
		int recurseCnt;
		bool verbose;

		public int CalculateNumberOfWays(int changeAmount, int[] denominations, bool verbose)
		{
			denomArray = denominations;
			Array.Sort(denomArray);
			Array.Reverse(denomArray);
			changeFor = changeAmount;
			this.verbose = verbose;
			maxCoeffArray = new int[denomArray.Length];
			currCoeffArray = new int[denomArray.Length];
			DumpArray("denominations", denominations, false);
			CalcMaxCoeff();
			recurseCnt = -1; // set to -1 so on first call it will be incremented to zero;
			CountWays();
			return countOfWays;
		}

		public void CountWays()
		{
			recurseCnt++; //increment as soon as we enter
			for (int i = 0; i <= maxCoeffArray[recurseCnt]; i++)
			{
				if (recurseCnt == 0)
				{
					InitCurrCoeffArray(i); // we're at top level; reset everything; start the next total
				}
				else
				{
					currCoeffArray[recurseCnt] = i; // set current coefficient
				}
				if (recurseCnt == (denomArray.Length - 1)) //we're at the bottom ...
				{
					CountTotal();
				}
				else //if (recurseCnt < denomArray.Length)
				{
					CountWays();
				}
			}
			recurseCnt--;//decrement when we leave;
		}

		public void CountTotal()
		{
			currTotal = 0;
			for (int i = 0; i <= recurseCnt; i++)
			{
				currTotal = currTotal + currCoeffArray[i] * denomArray[i];
			}
			if (currTotal <= changeFor)
			{
				if (denomArray[recurseCnt] == 1)
				{
					switch (currCoeffArray[recurseCnt])
					{
						case 0:
							if (currTotal == changeFor)
								countOfWays++;
							break;
						case 1:
							if (currTotal != changeFor)
								countOfWays++;
							break;
					}
				}
				else
				{
					if (currTotal == changeFor)
					{
						countOfWays++;
					}
				}
			}
			DumpArray("currCoeffArray", currCoeffArray, true);
		}

		public void InitCurrCoeffArray(int level)
		{
			for (int i = 0; i < currCoeffArray.Length; i++)
			{
				currCoeffArray[i] = (i == 0)? level : i;
			}
		}

		public void CalcMaxCoeff()
		{
			for (int i = 0; i < denomArray.Length; i++)
			{
				maxCoeffArray[i] = changeFor / denomArray[i];
				if (denomArray[i] == 1)
				{
					maxCoeffArray[i] = 1;
				}
			}
			DumpArray("maxCoeffArray", maxCoeffArray);
		}

		public void DumpArray(string name, int[] array, bool withTotals = false)
		{
			if (!verbose)
			{
				return;
			}
			var bldr = new StringBuilder();
			bldr.Append(string.Format("Array Name:: {0} ", name));
			bldr.Append("[");
			var comma = "";
			for (int i = 0; i < array.Length; i++)
			{
				bldr.Append(comma + array[i].ToString());
				comma = ",";
			}
			bldr.Append("] ");
			if (withTotals)
			{
				bldr.Append(string.Format("current total = {0} ", currTotal));
				bldr.Append(string.Format("countOfWays = {0}", countOfWays));
			}
			Program.logger.Debug(bldr.ToString());
		}
	}
}
