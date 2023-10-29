var input = File.ReadAllText("./input.txt");

Console.WriteLine("Package Marker");
PrintMarker(FindMarker(4));

Console.WriteLine("Message Marker");
PrintMarker(FindMarker(14), 25);

int FindMarker(int distinctCount)
{
	char[] buffer = new char[distinctCount];

	for (int i = 0; i < input!.Length; i++)
	{
		buffer = input.FillBuffer(i, buffer.Length);
		if (buffer.AllCharactersUnique())
		{
			return i + buffer.Length;
		}
	}
	
	throw new Exception("better luck next time~");
}

void PrintMarker(int marker, int extraCharactersCount = 10)
{
	Console.WriteLine($"Index before marker: {marker}");
	Console.Write($"Place in line here: {input!.Substring(marker - extraCharactersCount, extraCharactersCount)}");
	Console.Write($"_{input[marker]}");
	if (marker + extraCharactersCount + 1 < input.Length - 1)
	{
		Console.Write($"_{input.Substring(marker + 1, extraCharactersCount)}");
	}
	else if (marker + 1 < input.Length - 1)
	{
		Console.Write($"_{input.Substring(marker + 1, input.Length - marker - 2)}");
	}
	Console.Write("\n");
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
