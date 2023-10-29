// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
var input = File.ReadAllText("./input.txt");

char[] buffer = new char[4];

for (int i = 0; i < input.Length; i++)
{
	buffer = input.FillBuffer(i, buffer.Length);
	if (buffer.AllCharactersUnique())
	{
		var marker = i + buffer.Length;
		Console.WriteLine($"Index before marker: {marker}");
		Console.Write($"Place in line here: {input.Substring(marker - 10, 10)}");
		Console.Write($"_{input[marker]}");
		if (marker + 11 < input.Length - 1)
		{
			Console.Write($"_{input.Substring(marker + 1, 10)}");
		}
		else if (marker + 1 < input.Length - 1)
		{
			Console.Write($"_{input.Substring(marker + 1, input.Length - marker - 2)}");
		}

		break;
	}
}

internal static class TaskEx
{
	public static char[] FillBuffer(this string src, int index, int count)
	{
		var currentIndex = index;
		var buffer = new char[count];
		while (currentIndex < index + count)
		{
			buffer[currentIndex - index] = src[currentIndex];
			currentIndex++;
		}

		return buffer;
	}

	public static bool AllCharactersUnique(this char[] buffer)
	{
		var uniqueBuffer = new char[buffer.Length];
		var existIndex = 0;
		var bufferIndex = 0;
		
		while (bufferIndex < buffer.Length)
		{
			if (uniqueBuffer.Contains(buffer[bufferIndex]) == true)
			{
				return false;
			}

			uniqueBuffer[existIndex] = buffer[bufferIndex];
			existIndex++;
			bufferIndex++;
		}

		return true;
	}
}
