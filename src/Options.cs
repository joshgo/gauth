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

		[CommandLine.HelpVerbOption()]
		public string Usage(string verb)
		{
			if (verb == null)
				return CommandLine.Text.HelpText.AutoBuild(this, 
					current => CommandLine.Text.HelpText.DefaultParsingErrorsHandler(this, current));

			return CommandLine.Text.HelpText.AutoBuild(this, verb);
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
