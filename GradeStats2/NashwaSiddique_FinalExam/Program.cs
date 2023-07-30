using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NashwaSiddique_FinalExam
{
    class Program
    {
        static void Main(string[] args)
        {
            //----------Part 1-------------//
            // Part 4.1 - prompt user for the filepath
            Console.WriteLine("Please provide the filepath of the grades text file.");
            string userInput = Console.ReadLine();
            // Load in the file of grades
            string filepath = userInput;
            // Put these grades in a list
            List<string> gradesList = File.ReadAllLines(filepath).ToList();
            // create a new list that will contain the grades in a different datatype
            List<double> convertedGradesList = new List<double>();
            // convert each item in the original list to a double
            // add these converted numbers into the new convertedGradesList
            foreach (string grade in gradesList)
            {
                double convertedGrade = Convert.ToDouble(grade);
                convertedGradesList.Add(convertedGrade);

            }
            // Put the list in order from least to greatest
            double[] convertedGradesArray = convertedGradesList.ToArray();
            Array.Sort(convertedGradesArray);
            List<double> orderedGradesList = convertedGradesArray.ToList();

            // part 4.2 - curve grades less than 60 to 60
            // create a new list that will contain the curved grades
            List<double> curvedGradesList = new List<double>();
            int index = 0;
            // develop the new curved grades list
            foreach (double value in orderedGradesList)
            {
                if (value >= 60)
                {
                    double grade = orderedGradesList[index];
                    curvedGradesList.Add(grade);
                }
                else
                {
                    curvedGradesList.Add(60);
                }
                index++;
            }

            //----------Part 2-------------//
            Console.WriteLine();
            Console.WriteLine("Successfully processed the grades.");
            // calculate count
            double count = curvedGradesList.Count;
            Console.WriteLine("Total Count: " + count);
            // calculate the number of passing grades
            double passing = 0;
            foreach (double number in curvedGradesList)
            {
                if (number >= 62)
                {
                    passing++;
                }
                else
                {
                    passing = passing + 0;
                }
            }
            Console.WriteLine("Passing Grades: " + passing);
            // calculate total for the average
            double total = 0;
            foreach (double item in curvedGradesList)
            {
                total = total + item;
            }
            // calculate average
            double average = total / count;
            Console.WriteLine("Average: " + Math.Round(average,2));
            // calculate max
            int convertedCount = Convert.ToInt32(count);
            int maxLocation = convertedCount - 1;
            double max = curvedGradesList[maxLocation];
            Console.WriteLine("Maximum: " + max);
            // calculate min
            double min = curvedGradesList[0];
            Console.WriteLine("Minimum: " + min);
            // part 4.3 - calculate median
            double remainder = count % 2;
            int numberOfValues = Convert.ToInt32(count);
            if (remainder == 0)
            {
                int medianIndex = numberOfValues / 2;
                double number1 = curvedGradesList[medianIndex];
                double number2 = curvedGradesList[(medianIndex - 1)];
                double median = (number1 + number2) / 2;
                Console.WriteLine("Median: " + Math.Round(median, 2));
            }
            else
            {
                int medianIndex = numberOfValues / 2;
                double median = curvedGradesList[medianIndex];
                Console.WriteLine("Median: " + median);
            }
            // part 4.4 - calculate mode
            double mode = curvedGradesList.GroupBy(v => v)
            .OrderByDescending(g => g.Count())
            .First()
            .Key;
            Console.WriteLine("Mode: " + mode);

        }
    }
}
