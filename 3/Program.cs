Console.WriteLine("Filling priorities for items");

var priorities = FillPriorities();

Console.WriteLine("Reading input");

var input = File.ReadAllText("./input.txt");
var rucksacks = GetWithoutEmptyLastRow(input.Split("\n"));
var repeatedItems = new List<char>();

Console.WriteLine("Analyzing input");

foreach (var rucksack in rucksacks)
{
	var half = rucksack.Length / 2;
	var firstCompartment = rucksack.Take(half);
	var secondCompartment = rucksack.Skip(half);
	
	var repeatedItem = GetRepeating(firstCompartment, secondCompartment);

	if (repeatedItem.HasValue)
	{
		repeatedItems.Add(repeatedItem.Value);
	}
}

//Console.WriteLine($"Repeated items: {string.Join(", ", repeatedItems)}");
Console.WriteLine($"Sum of priorities(task 1): {repeatedItems.Select(e => priorities[e]).Sum()}");

var splitted = SplitToGroups(rucksacks);

Console.WriteLine($"Group count: {splitted.Count}");

Console.WriteLine($"First group: {string.Join("\n", splitted.First())}");

var badges = splitted.Select(e => GetBadge(e));

Console.WriteLine($"All badges: {string.Join(", ", badges)}");

Console.WriteLine($"Sum of all badges(task 2): {badges.Select(e => priorities[e]).Sum()}");

char GetBadge(List<string> group)
{
	var enumerator = group.GetEnumerator();
	enumerator.MoveNext();
	var first = new HashSet<char>();

	foreach (var character in enumerator.Current)
	{
		if (first.Contains(character) == false)
		{
			first.Add(character);
		}
	}

	var repeated = first;

	while (enumerator.MoveNext())
	{
		var newRepeated = new HashSet<char>();

		foreach (var character in enumerator.Current)
		{
			if (repeated.Contains(character) == true && newRepeated.Contains(character) == false)
			{
				newRepeated.Add(character);
			}
		}

		repeated = newRepeated;
	}

	return repeated.First();
}

List<List<string>> SplitToGroups(string[] all, int step = 3)
{
	var result = new List<List<string>>();

	var i = 0;
	
	while (i < all.Length)
	{
		var group = new List<string>();
		
		var groupIndex = i;

		while (groupIndex < i + step)
		{
			group.Add(all[groupIndex]);
			groupIndex++;
		}

		i += step;
		result.Add(group);
	}

	return result;
}

char? GetRepeating(IEnumerable<char> first, IEnumerable<char> second)
{
	var hash = new HashSet<char>();

	foreach (var character in first)
	{
		if (hash.Contains(character) == false)
		{
			hash.Add(character);
		}
	}

	foreach (var character in second)
	{
		if (hash.Contains(character))
		{
			return character;
		}
	}

	return null;
}

string[] GetWithoutEmptyLastRow(string[] rucksacks)
{
	var item = rucksacks[rucksacks.Length - 1];

	if (string.IsNullOrEmpty(item))
	{
		return rucksacks
			.Take(rucksacks.Length - 1)
			.ToArray();	
	}

	return rucksacks;
}

Dictionary<char, int> FillPriorities()
{
	var priorities = new Dictionary<char, int>();
	var character = 'a';
	var i = 1;

	while (i <= 26)
	{
		priorities.Add(character++, i++);
	}

	character = 'A';

	while (i <= 52)
	{
		priorities.Add(character++, i++);
	}

	return priorities;
}
