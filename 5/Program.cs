var crateLines = File.ReadAllLines("./input_crates.txt")
	.RemoveLastEmptyLine();

var movements = File.ReadAllLines("./input.txt")
	.RemoveLastEmptyLine();

Console.WriteLine($"Task#1 result: {Task(MoveCratesOneByOne)}");
Console.WriteLine($"Task#2 result: {Task(MoveCratesSavingOrder)}");

string Task(Action<CrateStack, CrateStack, int> act)
{
	var stacks = CrateStack.ParseCrateStacks(crateLines!);
	MoveCrates(stacks, movements!, act);
	var result = stacks
		.Select(e => e
			.Pop()
			.Replace("[", "")
			.Replace("]", "")
                );

	return string.Join("", result);
}

void MoveCrates(List<CrateStack> stacks, string[] movements, Action<CrateStack, CrateStack, int> act)
{
	var firstIndex = movements.First().IndexOf("move ") + "move ".Length;

	foreach (var movement in movements)
	{
		var fromWordFirstIndex = movement.IndexOf(" from ");
		var fromWordLastIndex = fromWordFirstIndex + " from ".Length;
		var toWordFirstIndex = movement.IndexOf(" to ");
		var toWordLastIndex = toWordFirstIndex + " to ".Length;

		var count = int.Parse(movement.Substring(firstIndex, fromWordFirstIndex - firstIndex));
		var fromStackId = int.Parse(movement.Substring(fromWordLastIndex, toWordFirstIndex - fromWordLastIndex));
		var targetStackId = int.Parse(movement.Substring(toWordLastIndex, movement.Length - toWordLastIndex));

		var fromStack = stacks.First(e => e.ID == fromStackId);
		var targetStack = stacks.First(e => e.ID == targetStackId);

		act(fromStack, targetStack, count);
	}
}

void MoveCratesOneByOne(CrateStack from, CrateStack target, int count)
{
	while(count > 0)
	{
		target.Push(from.Pop());
		count--;
	}
}

void MoveCratesSavingOrder(CrateStack from, CrateStack target, int count)
{
	target.Add(from.Take(count));
}
