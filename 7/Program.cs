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
			var dir = currentDirectory.GetSubdirectory(splitted[2]) ?? throw new Exception("too bad");
			currentDirectory = dir;
			break;
		case Command.MoveOut:
			currentDirectory = currentDirectory.Parent ?? rootDirectory;
			break;
		case Command.MoveRoot:
			currentDirectory = rootDirectory;
			break;
		case Command.Output:
			if (splitted[0] == "dir" && currentDirectory.GetSubdirectory(splitted[1]) == null)
			{
				var newDir = new Directory(currentDirectory, splitted[1]);
				currentDirectory.Add(newDir);
				directories.Add(newDir);
			}
			if (splitted[0] != "dir")
			{
				var newFile = new File(int.Parse(splitted[0]), splitted[1], currentDirectory);
				currentDirectory.Add(newFile);
			}
			break;
	}
}
var selection = directories
	.Where(e => e.Size <= 100000)
	.ToList();

Console.WriteLine("Task #1: " + selection.Sum(e => e.Size));

var totalSize = 70000000;
var totalUsed = rootDirectory.Size;
var currentFree = totalSize - totalUsed;
var needFree = 30000000;
var leftToFree = needFree - currentFree;

Console.WriteLine($"Used: {totalUsed}/{totalSize}. Current free: {currentFree}, leftToFree: {leftToFree}");

var smallestBigEnoughDirectory = directories
	.Select(e => e.Size)
	.Where(e => e > leftToFree)
	.OrderBy(e => e)
	.First(); 

Console.WriteLine($"Task #2: {smallestBigEnoughDirectory}");
