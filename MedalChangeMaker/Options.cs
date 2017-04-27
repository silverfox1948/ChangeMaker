﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace MedalChangeMaker
{
	public class Options
	{
		[Option('a', "changeAmount", Required = true, HelpText = "Enter the amount of change desired")]
		public int ChangeAmount { get; set; }

		[Option('d', "denominations", Required = true, HelpText = "Enter a space separated list of available donations from which to make change")]
		public IEnumerable<int> denominations { get; set; }
	}
}
