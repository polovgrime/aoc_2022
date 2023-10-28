internal class InputParser
{
	public static IEnumerable<Elve> ParseElves(string input)
	{
		var allFruits = input.Split("\n\n");
		var elves = new List<Elve>();	
		foreach (var fruitsPerElve in allFruits)
		{
			var fruits = fruitsPerElve
				.Split("\n")
				.Where(e => string.IsNullOrEmpty(e) == false)
				.Select(cal => new Fruit(int.Parse(cal)))
				.ToList();

			var elve = new Elve(fruits);
			
			elves.Add(elve);
		}

		return elves;
	}
}
