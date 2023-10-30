var input = File.ReadAllLines("./input.txt");
//var input = File.ReadAllLines("./test_input.txt");
var height = input.Length;
var width = input[0].Length;
var visibleTrees = (width + height - 2) * 2;

var innerVisibleTrees = new HashSet<Tuple<int,int>>();


for (int i = 1; i < height - 1; i++)
{
	var maxHorizontal = input[i][0];
	var maxVertical = input[0][i];	
	
	for (int j = 0; j < width - 1; j++)
	{
		if (input[i][j] > maxHorizontal)
		{
			maxHorizontal = input[i][j];
			WritePoint(i, j, innerVisibleTrees);
		}

		if (input[j][i] > maxVertical)
		{
			maxVertical = input[j][i];
			WritePoint(j, i, innerVisibleTrees);
		}
	}
	
	maxHorizontal = input[i][width - 1];
	maxVertical = input[height - 1][i];

	for (int j = width - 1; j > 0; j--)
	{
		if (input[i][j] > maxHorizontal)
		{
			maxHorizontal = input[i][j];
			WritePoint(i, j, innerVisibleTrees);
		}

		if (input[j][i] > maxVertical)
		{
			maxVertical = input[j][i];
			WritePoint(j, i, innerVisibleTrees);
		}
	}
}

Console.WriteLine("Visible from inner: " + innerVisibleTrees.Count);
Console.WriteLine("All Visible trees: " + (innerVisibleTrees.Count + visibleTrees));
void WritePoint(int i, int j, HashSet<Tuple<int, int>> innerVisibleTrees)
{

	var point = new Tuple<int, int>(i, j);
	if (innerVisibleTrees.Contains(point) == false)
	{
		innerVisibleTrees.Add(point);
	}
}

