using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace NashwaSiddique_MyFirstProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Random Art Idea Generator");
            Console.WriteLine("Before we begin, please answer a few questions:");

            // index that runs the program until the user wants to stop
            bool index = true;

            while (index == true)
            {
            
                Console.WriteLine();
                // Code to inform you how many items you can chose from
                string file = @"C:\Users\curio\OneDrive\Documents\University\Spring 21\Opim 3220 BSD\NashwaSiddique_MyFirstProject\NashwaSiddique_MyFirstProject\Items.txt";

                // Call upon the class and generate a random idea from the file
                Random_method itemList = new Random_method();
                List<string> fullItemList= itemList.LoadFile(file);
                int amount = fullItemList.Count;
                Console.WriteLine("Notice: you have " + amount + " items to chose from.");
                Console.WriteLine();

                // Question about how many ideas to generate
                Console.WriteLine("How many ideas do you want in this generation?");
                string number = Console.ReadLine();
                Console.WriteLine();
                // Question if the user wants a style idea
                Console.WriteLine("Would you like a style suggestion?");
                Console.WriteLine("Please type 'Y' for yes or 'N' for no.");
                string answer1 = Console.ReadLine();
                Console.WriteLine();
                // Question if the user wants a challenge
                Console.WriteLine("Would you also like a challenge with this generation?");
                Console.WriteLine("Please type 'Y' for yes or 'N' for no.");
                string answer2 = Console.ReadLine();
                Console.WriteLine();

                Console.WriteLine("Create:");

                // convert the number to an integer type
                int convertedNumber = Convert.ToInt32(number);
                
                // Create an index for the while loop
                int x = 1;

                // Create a list where the ideas get added to prevent repetition
                List<string> prompts = new List<string>();

                // Have the class generate a random idea as many times as the user requested
                while (x <= convertedNumber)
                {
                    // use this print the idea if there is no repetition thus far, this will be used later in the program
                    int startNum = x;

                    // import the file of ideas
                    string filepath = @"C:\Users\curio\OneDrive\Documents\University\Spring 21\Opim 3220 BSD\NashwaSiddique_MyFirstProject\NashwaSiddique_MyFirstProject\Items.txt";
                    
                    // Call upon the class and generate a random idea from the file
                    Random_method generation = new Random_method();
                    string idea = generation.GetOutput(filepath);
                    
                    // Create a loop that checks if ideas are repeated
                    // if the idea is repeated, the program is made to run once more fore each repeated item
                    foreach (string item in prompts)
                    {
                        if (prompts.Count >= 1 & idea == item)
                        {
                            // If the idea is repeated, then x decreases by one.
                            // This new x will be compared to the startNum, where if the new x is less
                            // than the startNum, then the x will be increased by 1 to equal the startNum so
                            // the program can be run again for that round to generate a new idea that (hopefully)
                            // hasn't been generated before
                            x = x - 1;
                        }
                    }
                    
                    if (startNum > x)
                    {
                        // Doesn't print the idea, and goes on to redo this round of random selection
                        x++;
                    }
                    else
                    {
                        // print the idea if there is no repetation thus far
                        prompts.Add(idea);
                        Console.WriteLine(idea);
                        x++;
                    }
                }

                // Have the class generate a random style for the user
                if (answer1 == "Y" | answer1 == "y")
                {
                    string filepath = @"C:\Users\curio\OneDrive\Documents\University\Spring 21\Opim 3220 BSD\NashwaSiddique_MyFirstProject\NashwaSiddique_MyFirstProject\Styles.txt";
                    Random_method generation = new Random_method();
                    Console.WriteLine("In the style of " + generation.GetOutput(filepath));
                }

                // Have the class generate a random challenge for the user
                if (answer2 == "Y" | answer2 == "y")
                {
                    string filepath = @"C:\Users\curio\OneDrive\Documents\University\Spring 21\Opim 3220 BSD\NashwaSiddique_MyFirstProject\NashwaSiddique_MyFirstProject\Challenges.txt";
                    Random_method generation = new Random_method();
                    Console.WriteLine("Challenging yourself with the " + generation.GetOutput(filepath) + " challenge");
                }

                // Question user if they want to run the program again
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Would you like to stop here?");
                Console.WriteLine("Please type 'Y' for yes or 'N' for no.");
                string answer3 = Console.ReadLine();

                 
                if (answer3 == "Y" | answer3 == "y")
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
