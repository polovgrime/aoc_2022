internal class Elf
{
	public readonly int FirstIndex;

	public readonly int SecondIndex;

	public Elf(string sectionStr)
	{
		var splitted = sectionStr.Split("-");
		FirstIndex = int.Parse(splitted[0]);
		SecondIndex = int.Parse(splitted[1]);
	}

	public override string ToString()
	{
		return $"[{{{FirstIndex}, {SecondIndex}}}]";
	}

	public bool Contains(Elf elf)
	{
		return FirstIndex <= elf.FirstIndex && SecondIndex >= elf.SecondIndex;
	}

	public bool Overlap(Elf elf)
	{
		if (Contains(elf) || elf.Contains(this))
		{
			return true;
		}

		var overlapWithHead = elf.FirstIndex >= this.FirstIndex && elf.FirstIndex <= this.SecondIndex;  
		var overlapWithTail = elf.SecondIndex >= this.FirstIndex && elf.SecondIndex <= this.SecondIndex;  
		
		return overlapWithHead || overlapWithTail;
		//1 . . . . . . 9
		//. . . . . 7 . . 10
		//elf.FirstIndex >= this.FirstIndex && elf.FirstIndex <= this.SecondIndex
		//. . . . 5 . . 9 
		//. . 3 . . 7 . .
		//elf.SecondIndex >= this.FirstIndex && elf.SecondIndex <= this.SecondIndex
	}
}
