namespace MedalChangeMaker
{
	class Program
	{
		static void Main(string[] args)
		{
			var options = new Options();
			var isValid =  CommandLine.Parser.Default.ParseArgumentsStrict(args, options);
			if (isValid)
			{
				var changeMaker = new ChangeMaker();
				var result = ChangeMaker.
			}
		}
	}
}
