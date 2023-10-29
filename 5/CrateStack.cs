internal class CrateStack
{
	public readonly int ID;

	private List<string> crates;
	
	public CrateStack(int id)
	{
		ID = id;
		this.crates = new List<string>();
	}

	public string Pop()
	{
		var crate = crates[crates.Count - 1];
		crates.RemoveAt(crates.Count - 1);
		return crate;
	}

	public void Push(string str)
	{
		crates.Add(str);
	}

	public IEnumerable<string> Take(int count)
	{
		var target = crates.Skip(crates.Count - count).Take(count);
		crates = crates.Take(crates.Count - count).ToList();
		return target;
	}

	public void Add(IEnumerable<string> newCrates)
	{
		crates.AddRange(newCrates);
	}

	public override string ToString()
	{
		return $"Crate#{ID}: [{string.Join(", ", crates.ToList())}], stacks count {crates.Count}";
	}

	public static List<CrateStack> ParseCrateStacks(string[] src)
	{
		var linesReversed = src.Reverse();
		var stackLength = 3;
		var kostyl = 0;
		var indexLine = linesReversed.First();
		var crates = indexLine
			.Where(e => int.TryParse(e.ToString(), out kostyl))
			.Select(e => int.Parse(e.ToString()))
			.Select(e => new CrateStack(e))
			.ToList();
			
		linesReversed = linesReversed.Skip(1);

		foreach (var line in linesReversed)
		{
			foreach (var crate in crates)
			{
				var stack = line.Substring(indexLine.IndexOf(crate.ID.ToString().First()) - 1, stackLength);
				if (string.IsNullOrWhiteSpace(stack) == false)
				{
					crate.Push(stack);
				}
			}
		}

		return crates;
	}
}
