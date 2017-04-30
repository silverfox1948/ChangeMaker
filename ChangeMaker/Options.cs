/*
Copyright 2017 Steven Archibald Consulting Corporation

Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

	 http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace ChangeMaker
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
