var priorities = FillPriorities();
var input = File.ReadAllText("./input.txt");
var rucksacks = GetWithoutEmptyLastRow(input.Split("\r\n"));


foreach (var rucksack in rucksacks)
{
	var half = rucksack.Length / 2;
	var firstCompartment = rucksack.Take(half);
	var secondCompartment = rucksack.Skip(half);
	

}

private char GetRepeating(char[] first, char[] second)
{

}

IEnumerable<string> GetWithoutEmptyLastRow(string[] rucksacks)
{
	var item = rucksacks[rucksacks.Length - 1];

	if (string.IsNullOrEmpty(item))
	{
		return rucksacks.Take(rucksacks.Length - 1);	
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
