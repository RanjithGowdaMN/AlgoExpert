using System.Collections.Generic;
using System;


public static class ClassPhoto
{
	public static void Main()
	{

	}
	public static bool ClassPhotos(List<int> redShirtHeights, List<int> blueShirtHeights)
	{
		// Write your code here.
		redShirtHeights.Sort((a, b) => b.CompareTo(a));
		blueShirtHeights.Sort((a, b) => b.CompareTo(a));

		string shirtInFrontRow = (redShirtHeights[0] > blueShirtHeights[0]) ? "RED" : "BLUE";

		for (int i = 0; i < blueShirtHeights.Count; i++)
		{
			int redShirtHeight = redShirtHeights[i];
			int blueShirtHeight = blueShirtHeights[i];

			if (shirtInFrontRow == "RED")
			{
				if (redShirtHeight <= blueShirtHeight)
				{
					return false;
				}
			}
			else
			{
				if (redShirtHeight >= blueShirtHeight)
				{
					return false;
				}
			}
		}
		return true;
	}
}

