//Console.WriteLine("Hello, tmux?"); // also started using tmux so i can use terminal side by side with vim
//maybe i could use something in vim but the way i had it - it was not really convinient to keep track of where I am
//in the directory

var sections = File.ReadAllText("./input.txt");

var sectionPairs = sections.Split("\n");

if (string.IsNullOrEmpty(sectionPairs[sectionPairs.Length - 1]))
{
	sectionPairs = sectionPairs.Take(sectionPairs.Length - 1).ToArray();
}

var pairedElvesCount = sectionPairs
	.Select(e => e.Split(","))
	.Select(e => new Tuple<Elf, Elf>(new Elf(e[0]), new Elf(e[1])))
	.Where(e => e.Item1.Contains(e.Item2) || e.Item2.Contains(e.Item1))
	.Count();

Console.WriteLine($"Pairs count where one elf contains another elf's sections fully: {pairedElvesCount}");

var overlappedElvesCount = sectionPairs
	.Select(e => e.Split(","))
	.Select(e => new Tuple<Elf, Elf>(new Elf(e[0]), new Elf(e[1])))
	.Where(e => e.Item1.Overlap(e.Item2))
	.Count();

Console.WriteLine($"Pairs count where one elf overlaps another elf: {overlappedElvesCount}");


//using tmux is great so far. i3's good too
//why didn't I use it all before?
