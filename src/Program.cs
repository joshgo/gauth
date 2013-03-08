using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gauth
{
	class Program
	{
		// gauth get -n <name>
		// gauth set -n <name> -k <key>
		// gauth del -n <name>

		[STAThread]
		static void Main(string[] args)
		{
			var options = new Options();
			string verb;
			BaseOption baseOption = null;
			bool help = false;

			Action<string, object> onVerbCommand = delegate(string v, object s)
			{
				verb = v;
				help = string.Equals(verb, "help", StringComparison.OrdinalIgnoreCase);
				baseOption = (BaseOption)s;
			};

			if (!CommandLine.Parser.Default.ParseArguments(args, options, onVerbCommand))
			{
				if (!help)
					Console.Error.WriteLine("Error on parsing arguments");

				Console.Error.WriteLine(Options.Usage());

				Environment.Exit(CommandLine.Parser.DefaultExitCodeFail);
			}

			KeyManager manager = new KeyManager(".gauth");

			if (baseOption is GetOption)
			{
				var code = manager.Get(baseOption.Name);
				Console.WriteLine(code);
				System.Windows.Clipboard.SetText(code);
			}
			else if (baseOption is SetOption)
			{
				var setOption = baseOption as SetOption;
				manager.Set(setOption.Name, setOption.Key);
			}
			else if (baseOption is DelOption)
			{
				manager.Del(baseOption.Name);
			}
		}
	}
}
