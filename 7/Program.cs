var lines = System.IO.File.ReadAllLines("./input.txt");

var directories = new List<Directory>();
var rootDirectory = new Directory();
var currentDirectory = rootDirectory;
foreach (var line in lines)
{
	var splitted = line.Split(" ");
	switch(CommandDispatcher.ReadCommand(line))
	{
		case Command.List: continue;
		case Command.MoveIn: 
			var newDir = directories.FirstOrDefault(e => e.Title == splitted[2]);
			
			if (newDir is null)
			{
				newDir = new Directory(currentDirectory, splitted[2]);
				directories.Add(newDir);
			}

			currentDirectory = newDir;
			break;
		case Command.MoveOut:
			currentDirectory = currentDirectory.Parent ?? rootDirectory;
			break;
		case Command.MoveRoot:
			currentDirectory = rootDirectory;
			break;
		case Command.Output:
			if (splitted[0] != "dir")
			{
				var newFile = new File(int.Parse(splitted[0]), splitted[1], currentDirectory);
				currentDirectory.Add(newFile);
			}
			break;
	}
}
var selection = directories
	.Where(e => e.Size < 100000)
	.ToList();
Console.WriteLine(directories.Sum(e => e.Size));
//Console.WriteLine(string.Join("\n", selection.Select(e => e.WithFiles).ToList()));
Console.WriteLine(selection.Count + " " + selection.Sum(e => e.Size));
/*Console.WriteLine(directories
		.Select(e => e.Size)
		.Where(size => size < 100000)
		.Sum());*/
