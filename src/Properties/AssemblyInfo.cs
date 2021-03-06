﻿using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("gauth")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("gauth")]
[assembly: AssemblyCopyright("Copyright ©  2013 - joshgo")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

[assembly: CommandLine.AssemblyLicense(
	"This is free software. You may redistribute copies of it under the terms of",
	"the MIT License <http://www.opensource.org/licenses/mit-license.php>.\n")]
[assembly: CommandLine.AssemblyUsage(
	"Usage: gauth set -n <name> -k <key>",
	"       gauth get -n <name>",
	"       gauth del -n <name>")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("e7d20f27-8107-4ab1-8555-25a60206ea7e")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
