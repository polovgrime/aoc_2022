internal class CommandDispatcher
{
	public static Command ReadCommand(string str)
	{
		if (str.Contains("$") == false)
		{
			return Command.Output;
		}

		if (str == "$ ls")
		{
			return Command.List;
		}

		if (str == "$ cd ..")
		{
			return Command.MoveOut;
		}

		if (str == "$ cd /")
		{
			return Command.MoveRoot;
		}

		return Command.MoveIn;
	}
}
