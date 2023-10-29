internal class Crate
{
	public readonly int ID;

	private Stack<string> stacks;
	
	public Crate(int id, Stack<string> stacks) 
		: this(id) //i hate this tbh and im not gonna do this again
			   //i didnt have a need for it i just wanted to feel like an idiot
	{
		this.stacks = stacks;
	}

	public Crate(int id)
	{
		ID = id;
		this.stacks = new Stack<string>();
	}

	public string Pop()
	{
		return stacks.Pop();
	}

	public void Push(string str)
	{
		stacks.Push(str);
	}

	public override string ToString()
	{
		return $"Crate#{ID}: [{string.Join(", ", stacks.ToList())}], stacks count {stacks.Count}";
	}

	public static IEnumerable<Crate> ParseCrateStacks(string[] src)
	{
		var linesReversed = src.Reverse();
		var stackLength = 3;
		var kostyl = 0;
		var indexLine = linesReversed.First();
		var crates = indexLine
			.Where(e => int.TryParse(e.ToString(), out kostyl))
			.Select(e => int.Parse(e.ToString()))
			.Select(e => new Crate(e))
			.ToList();
			
		linesReversed = linesReversed.Skip(1);

		foreach (var line in linesReversed)
		{
			foreach (var crate in crates)
			{
				var stack = line.Substring(indexLine.IndexOf(crate.ID.ToString().First()) - 1, stackLength);
				if (string.IsNullOrWhiteSpace(stack) == false)
				{
					Console.WriteLine($"Push [{stack}] to Crate#{crate.ID}");
					crate.Push(stack);
				}
			}
		}

		return crates;
	}
}
