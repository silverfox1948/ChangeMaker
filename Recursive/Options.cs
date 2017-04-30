using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace Recursive
{
	public class Options
	{
		[Option('a', "changeAmount", Required = true, HelpText = "Enter the amount of change desired")]
		public int ChangeAmount { get; set; }

		[OptionArray('d', "denominations", Required = true, HelpText = "Enter a space separated list of available donations from which to make change")]
		public int[] Denominations { get; set; }

		[Option('v', "verbose", Required = false, DefaultValue = false, HelpText = "If present will display the items being tested")]
		public bool Verbose { get; set; }

	}
}
