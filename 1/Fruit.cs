internal class Fruit
{
	public int Calories;

	public Fruit(int calories)
	{
		Calories = calories;
	}

	public override string ToString()
	{
		return Calories.ToString();
	}
}
