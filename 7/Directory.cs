internal class Directory
{
	public readonly Directory? Parent;
	
	public readonly string Title;
	
	public string WithFiles => $"{this.ToString()}\n{string.Join("\n", files)}";

	public int Size => directories.Select(d => d.Size).Sum() + files.Select(e => e.Size).Sum();
	
	private List<Directory> directories = new List<Directory>();

	private List<File> files = new List<File>();


	public Directory(Directory? parent = null, string title = "")
	{
		Parent = parent;
		this.Title = title;
	}

	public void Add(Directory child)
	{
		directories.Add(child);
	}

	public void Add(File child)
	{
		files.Add(child);
	}

	public override string ToString()
	{
		return $"{Parent?.ToString() ?? ""}/{Title}";
	}

	public Directory? GetSubdirectory(string title)
	{
		return directories.FirstOrDefault(e => e.Title == title);
	}
}
