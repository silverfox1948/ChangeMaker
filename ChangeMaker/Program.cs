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
using System.Diagnostics;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace ChangeMaker
{
	class Program
	{
		public static NLog.Logger logger = NLog.LogManager.GetLogger("Logger");
		public static string LogFileName;

		static void Main(string[] args)
		{
			ConfigureLogging();
			var options = new Options();
			CommandLine.Parser.Default.ParseArguments(args, options);
			var changeCounter = new ChangeCounter();
			Stopwatch timer = new Stopwatch();
			timer.Start();
			var result = changeCounter.CalculateNumberOfWays(options.ChangeAmount, options.Denominations, options.Verbose);
			timer.Stop();
			Console.WriteLine("\nNumber of ways to make change for {0} = {1}", options.ChangeAmount, result);
			if (options.Verbose)
			{
				logger.Debug("\nNumber of ways to make change for {0} = {1}", options.ChangeAmount, result);
				logger.Debug("elapsed milliseconds:: {0}", timer.ElapsedMilliseconds);
				Process.Start(LogFileName);
			}
			Console.Read();
		}

		private static void ConfigureLogging()
		{
			var config = new LoggingConfiguration();
			var fileTarget = new FileTarget();
			LogFileName = AppDomain.CurrentDomain.BaseDirectory + @"changemaker.txt";
			fileTarget.Name = "fileTarget";
			fileTarget.FileName = LogFileName;
			fileTarget.Layout = "${message}";
			fileTarget.DeleteOldFileOnStartup = true;
			config.AddTarget(fileTarget);

			var fileRule = new LoggingRule("*", LogLevel.Debug, fileTarget);
			config.LoggingRules.Add(fileRule);
			LogManager.Configuration = config;
		}
	}
}
