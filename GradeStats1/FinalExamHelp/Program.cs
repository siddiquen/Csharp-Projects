using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FinalExamHelp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool index = true;
            while (index == true)
            {
                // **Load in the file of grades
                string filepath = @"C:\Users\curio\OneDrive\Documents\University\Spring 21\Opim 3220 BSD\FinalExamHelp\FinalExamHelp\Grades.txt";
                // **Put these grades in a list
                List<string> gradesList = File.ReadAllLines(filepath).ToList();

                // **create a new list that will contain the grades in a different datatype
                List<double> convertedGradesList = new List<double>();
                // **convert each item in the original list to a double
                // **add these converted numbers into the new convertedGradesList
                foreach (string grade in gradesList)
                {
                    double convertedGrade = Convert.ToDouble(grade);
                    convertedGradesList.Add(convertedGrade);
                    
                }
                
                // **Put the list in order from least to greatest
                double[] convertedGradesArray = convertedGradesList.ToArray();
                Array.Sort(convertedGradesArray);
                List<double> orderedGradesList = convertedGradesArray.ToList();

                //Ask if the user wants to see the list of grades
                Console.WriteLine("Here is the current list of grade:");
                
                // check to see if order it correct
                foreach (double value in orderedGradesList)
                {
                    Console.Write(value + " ");
                }



                //Ask if the user wants to add to the list of grades
                Console.WriteLine();
                Console.WriteLine("Would like to add a grade to the list before proceeding?");
                Console.WriteLine("Please type 'Y' for yes or 'N' for no.");
                string answer2 = Console.ReadLine();

                if (answer2 == "Y" | answer2 == "y")
                {
                    bool index2 = true;
                    while (index2 == true)
                    {
                        Console.WriteLine("Please type the number you would like to add");
                        string newValue = Console.ReadLine();
                        double convertedNewValue = Convert.ToDouble(newValue);

                        // add the new value to the data set and sort it
                        orderedGradesList.Add(convertedNewValue);
                        convertedGradesArray = orderedGradesList.ToArray();
                        Array.Sort(convertedGradesArray);
                        orderedGradesList = convertedGradesArray.ToList();

                        // check to see if order it correct
                        Console.WriteLine("Here is the new list:");
                        foreach (double value in orderedGradesList)
                        {
                            Console.Write(value + " ");
                        }
                        
                        Console.WriteLine();
                        Console.WriteLine("Would you like to add another value");
                        Console.WriteLine("Please type 'Y' for yes or 'N' for no.");
                        answer2 = Console.ReadLine();

                        if (answer2 == "Y" | answer2 == "y")
                        {
                            // let the user add another value
                            continue;
                        }
                        else
                        {
                            // Have the program continue to the next part
                            index2 = false;
                        }
                    }
                }

                //Ask if the user wants to remove something from the list of grades
                Console.WriteLine();
                Console.WriteLine("Would like to remove a grade to the list before proceeding?");
                Console.WriteLine("Please type 'Y' for yes or 'N' for no.");
                string answer3 = Console.ReadLine();

                if (answer3 == "Y" | answer3 == "y")
                {
                    bool index2 = true;
                    while (index2 == true)
                    {
                        Console.WriteLine("Here is the current list:");
                        foreach (double number in orderedGradesList)
                        {
                            Console.Write(number + " ");
                        }
                        
                        Console.WriteLine();
                        Console.WriteLine("Please type the number you would like to remove");
                        string Value = Console.ReadLine();
                        double convertedValue = Convert.ToDouble(Value);

                        // remove the value to the data set
                        orderedGradesList.Remove(convertedValue);

                        // check to see if order is correct
                        Console.WriteLine("Here is the new revised list:");
                        foreach (double number in orderedGradesList)
                        {
                            Console.Write(number + " ");
                        }
                        
                        Console.WriteLine();
                        Console.WriteLine("Would you like to remove another value");
                        Console.WriteLine("Please type 'Y' for yes or 'N' for no.");
                        answer3 = Console.ReadLine();

                        if (answer3 == "Y" | answer3 == "y")
                        {
                            // let the user remove another value
                            continue;
                        }
                        else
                        {
                            // Have the program continue to the next part
                            index2 = false;
                        }
                    }
                }

                Console.WriteLine();
                Console.WriteLine();
                // **calculate total
                double total = 0;
                foreach (double item in orderedGradesList)
                {
                    total = total + item;
                }
                Console.WriteLine("The total of all the grades is " + total);

                // **calculate count
                double count = orderedGradesList.Count;
                Console.WriteLine("There are a total of " + count + " entries.");

                // **calculate average
                double average = total / count;

                // **calculate min
                double min = orderedGradesList[0];
                Console.WriteLine("The minimum is " + min);

                // **calculate max
                int convertedCount = Convert.ToInt32(count);
                int maxLocation = convertedCount - 1;
                double max = orderedGradesList[maxLocation];
                Console.WriteLine("The maximum is " + max);

                // Question user if they want to run the program again
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Would you like to stop here?");
                Console.WriteLine("Please type 'Y' for yes or 'N' for no.");
                string answer4 = Console.ReadLine();


                if (answer4 == "Y" | answer4 == "y")
                {
                    // Have the program stop if the user wants to
                    index = false;
                }
                else
                {
                    // Have the program run again if the user wants to
                    continue;
                }

            }
        }
    }
}
