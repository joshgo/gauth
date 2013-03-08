using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gauth
{
	public class Options
	{
		[CommandLine.VerbOption("set", HelpText = "Adds or sets the private key")]
		public SetOption SetOption { get; set; }
		[CommandLine.VerbOption("get", HelpText = "Gets a generated code for the specified name")]
		public GetOption GetOption { get; set; }
		[CommandLine.VerbOption("del", HelpText = "Deletes the private key for specified name")]
		public DelOption DelOption { get; set; }

		[CommandLine.HelpVerbOption("help")]
		public static string Usage()
		{
			return
				"GAuth command usage:\n\n" + 
				"gauth help\n\n" +
				"gauth set -n <name> -k <key>\n" +
				"   sets the key for the specified account name\n\n" +
				"gauth get -n <name>\n" +
				"   gets the one-time-password for the specified name\n\n";
		}
	}

	public class BaseOption
	{
		[CommandLine.Option('n', "name", Required = true, HelpText = "Specifies the name of the account")]
		public string Name { get; set; }
	}

	public class SetOption : BaseOption
	{
		[CommandLine.Option('k', "key", Required = true, HelpText = "Specifies the name of the account")]
		public string Key { get; set; }
	}

	public class GetOption : BaseOption
	{
	}

	public class DelOption : BaseOption
	{
	}
}
