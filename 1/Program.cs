namespace aoc.first;

public class Program
{
	public static void Main(string[] args)
	{
		Console.WriteLine("Hello, Advent of Code!");
		var elves = InputParser.ParseElves(File.ReadAllText("./input.txt"));
		Console.WriteLine($"Elves below:\n {string.Join(",\n", elves)}");
		var orderedElves = elves
			.OrderByDescending(e => e.TotalCalories)
			.ToList();
		
		var topOneMax = orderedElves
			.Select(e => e.TotalCalories)
			.First();

		var topThreeMax = orderedElves
			.Take(3)
			.Select(e => e.TotalCalories)
			.Sum();

		Console.WriteLine($"Top 1 calories: {topOneMax}\nTop 3 elves combined: {topThreeMax}");
	}

	private static int FindMax(IEnumerable<Elve> elves)
	{
		return elves
			.OrderByDescending(e => e.TotalCalories)
			.Select(e => e.TotalCalories)
			.First(); //i don't really care rn
	}	
}
