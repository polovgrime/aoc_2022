internal class File
{
	public readonly int Size;

	private readonly Directory directory;

	private readonly string title;

	public File(int size, string title, Directory directory)
	{
		this.directory = directory;
		this.title = title;
		Size = size;
	}

	public override string ToString()
	{
		return $"{directory}/{title} - (size){Size}";
	}
}
