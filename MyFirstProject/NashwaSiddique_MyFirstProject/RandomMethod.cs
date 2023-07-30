using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NashwaSiddique_MyFirstProject
{
    class Random_method
    {

		// Takes in a file
		public List<string> LoadFile(string filepath)
		{
			// Converts it to a list of strings
			List<string> ideaList = File.ReadAllLines(filepath).ToList();
			return ideaList;
		}

		// Method that picks a random item from the string
		public string GetOutput(string filepath)
		{
			
			List<string> list = LoadFile(filepath);

			//gets the length of the list and subtracts 1 to capture all strings when used to index the list
			int lengthOfList = list.Count - 1;
			
			// Generate a new number
			Random random = new Random();
			int randomNumber = random.Next(0, lengthOfList);

			// Pick an item from the list at the randomNumber index location
			// Store the chosen string in a variable
			string output = list[randomNumber];

			return output;
		}

	}
}
