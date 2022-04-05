using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



	public class WordFinder
	{
		private IEnumerable<string> matrix;

		public WordFinder(IEnumerable<string> matrix)
		{
			this.matrix = matrix;
		}

		public IEnumerable<string> Find(IEnumerable<string> wordstream)
		{
			HashSet<string> result = new HashSet<string>();
			StringBuilder topToDownText = new StringBuilder();
			HashSet<string> words = new(wordstream); // store wordstream in hashset as it does matter if word is repeated in WORDSTREAM

			string leftToRightText = string.Join(string.Empty, matrix);// save list into one string to search from left to right
			result.UnionWith(words.Where(currentWord => leftToRightText.Contains(currentWord)));

			char[][] characterMatrix = matrix.Select(row => row.ToCharArray()).ToArray(); //convert list of strings to char matrix
			for (int i = 0; i < characterMatrix.Length; i++)
			{
				for (int j = 0; j < characterMatrix[i].Length; j++)
				{
					topToDownText.Append(characterMatrix[j][i]);// store text from top to down in one string using stringbuilder
				}
			}
			result.UnionWith(words.Where(currentWord => topToDownText.ToString().Contains(currentWord)));

			if (result.Count > 0)
				return result.Take(10).ToList();
			else
				return result.ToList();
		}
	}

