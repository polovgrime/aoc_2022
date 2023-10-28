public class Program
{
	private static readonly Dictionary<string, Outcome> outcomes = new Dictionary<string, Outcome>()
	{
		{ "X", Outcome.Lose },
		{ "Y", Outcome.Draw },
		{ "Z", Outcome.Win }
	};

	public static void Main(string[] args)
	{
		Console.WriteLine("Reading input");

		var allHands = File.ReadAllText("./input.txt").Split("\n");

		Console.WriteLine("Reading hands");

		if (string.IsNullOrEmpty(allHands[allHands.Length - 1]))
		{
			allHands = allHands.Take(allHands.Length - 1).ToArray();
		}
		
		Console.WriteLine("Read all the rounds! Length: " + allHands.Length);

		var scoreFirstPart = 0;
		var scoreSecondPart = 0;
		
		Console.WriteLine("Calculating score");

		foreach (var handString in allHands)
		{
			var splitted = handString.Split(" ");
			var enemyHand = ReadHand(splitted[0]);
			var yourHand = ReadHand(splitted[1]);

			scoreFirstPart += (int)yourHand; //your hand

			scoreFirstPart += (int)DecideWin(enemyHand, yourHand);
			
			yourHand = GetHandByOutcome(enemyHand, splitted[1]);
			scoreSecondPart += (int)yourHand;
			scoreSecondPart += (int)DecideWin(enemyHand, yourHand);
		}
		
		Console.WriteLine($"First part answer: {scoreFirstPart}");
		Console.WriteLine($"Second part answer: {scoreSecondPart}");
	}

	private static Outcome DecideWin(Hand enemy, Hand you)
	{
		if (enemy == you)
		{
			return Outcome.Draw;
		}

		if (enemy == Hand.Rock && you == Hand.Scissors)
		{
			return Outcome.Lose;
		}

		if (enemy == Hand.Scissors && you == Hand.Paper)
		{
			return Outcome.Lose;
		}

		if (enemy == Hand.Paper && you == Hand.Rock)
		{
			return Outcome.Lose;
		}
		
		return Outcome.Win;
	}

	private static Hand GetHandByOutcome(Hand hand, string outcomeLetter)
	{
		var outcome = outcomes[outcomeLetter];
		
		var handIterator = Hand.Rock;

		while (handIterator < Hand.Scissors + 1)
		{
			if (DecideWin(hand, handIterator) == outcome)
			{
				break;
			}
			handIterator++;
		}

		return handIterator;
	}

	private static Hand ReadHand(string hand)
	{
		if (hand == "A" || hand == "X")
		{
			return Hand.Rock;
		}
		
		if (hand == "B" || hand == "Y")
		{
			return Hand.Paper;
		}

		return Hand.Scissors;
	}
}
