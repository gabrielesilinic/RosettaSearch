using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

public class trgm
{

	private static int Clamp(int val, int min, int max)
	{
		if (val < min)
			return min;
		else if (val > max)
			return max;
		return val;
	}

	private static string[] genTrigrams(string word, bool unique = false)
	{
		List<string> trigrams = new List<string>();
		word = word.Replace(" ", "");
		word = " " + word.Trim().ToLower() + " ";
		for (int i = 0; i < word.Length; i++)
		{
			var trgm = word.Substring(i, Clamp(3, 0, word.Length - i));
			if (!(unique && trigrams.Contains(trgm)))
			{
				if (trgm != "" && trgm != " ")
					trigrams.Add(trgm);
			}
		}

		return trigrams.ToArray();
	}
	
	public static float trgmRatio(string query, string word)
	{
		var querytrgm = genTrigrams(query, unique: true);
		var wordtrgm = genTrigrams(word);
		int matches = 0;
		foreach (var item in querytrgm)
		{
			matches += wordtrgm.Count(x => x == item);
		}

		return (matches / (float)wordtrgm.Length);
	}
}
