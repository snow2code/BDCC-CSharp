using Godot;
using System;

public partial class Logger : Node
{
	public static void LogPrefix(string prefix, string message, params object[] args)
	{
		for (int i = 0; i < args.Length; i++)
		{
			message = message.ReplaceFirst("%s", $"{{{i}}}");
		}

		GD.Print(string.Format($"[{prefix}] {message}", args));
	}
	
	public static void Log(string message, params object[] args)
	{
		for (int i = 0; i < args.Length; i++)
		{
			message = message.ReplaceFirst("%s", $"{{{i}}}");
		}

		GD.Print(string.Format(message, args));
	}
	
	public static void Error(string message, params object[] args)
	{
		for (int i = 0; i < args.Length; i++)
		{
			message = message.ReplaceFirst("%s", $"{{{i}}}");
		}

		GD.PrintErr(string.Format(message, args));
	}
	
	
}

public static class StringExtensions
{
	public static string ReplaceFirst(this string text, string search, string replace)
	{
		int pos = text.IndexOf(search);
		if ( pos < 0 ) return text;
		return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
	}
}
