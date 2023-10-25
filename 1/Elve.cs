internal class Elve
{
	private readonly List<Fruit> fruits;

	public int TotalCalories => fruits.Sum(fruit => fruit.Calories);

	public Elve(List<Fruit> fruits)
	{
		this.fruits = fruits;
	}

	public override string ToString()
	{
		return $"Elve with {fruits.Count} fruits. His bag: [{string.Join(", ", fruits)}]. Total calories: {TotalCalories}";
	}
}
