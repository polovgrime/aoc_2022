static class StringEx
{
	public static string[] RemoveLastEmptyLine(this string[] str)
	{
		if (string.IsNullOrEmpty(str[str.Length - 1]))
		{
			str = str
				.Take(str.Length - 1)
				.ToArray();
		}

		return str;
	}
}

