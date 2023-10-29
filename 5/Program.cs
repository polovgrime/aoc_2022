var crateLines = File.ReadAllLines("./input_crates.txt");

if (string.IsNullOrEmpty(crateLines[crateLines.Length - 1]))
{
	crateLines = crateLines
		.Take(crateLines.Length - 1)
		.ToArray();
}

var crates = Crate.ParseCrateStacks(crateLines);

Console.WriteLine("Stacks");
Console.WriteLine(string.Join(",\n", crates));
var movements = File.ReadAllText("./input.txt");
