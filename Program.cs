using System;
using System.Collections.Generic;

namespace Lab_9_Refactoring_Time
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string> { "Clayton", "Heather", "Reggie" };
            List<string> foods = new List<string> { "Potato Curry", "Donuts", "Pizza" };
            List<string> towns = new List<string> { "Flat Rock", "Marysville", "Detroit" };
            List<string> movies = new List<string> { "Pulp Fiction", "Air Bud", "Star Wars" };

            string mainMenu = "Would you like to go back to the main menu? (y/n)";
            string tryAgain = "Would you like to try again? (y/n)";
            string otherInfo = "Would you like to see other information? (y/n)";

            bool resume = false;
            
                do
                {
                try
                {
                    string userInput = GetUserInput("Would you like to 1) see a student or 2) add a new student? (Type 'see' or 'add').").ToLower();
                    if (userInput == "see")
                    {
                        for (int i = 0; i < names.Count; i++)
                        {
                            Console.WriteLine($"{i}. {names[i]}");
                        }
                        bool resume2 = false;
                        do
                        {
                            int userChoice1 = int.Parse(GetUserInput("Woud student would you like to see? Enter a number."));
                            for (int i = 0; i < names.Count; i++)
                            {
                                if (userChoice1 == i)
                                {
                                    do
                                    {
                                        string userChoice2 = GetUserInput("What would you like to see? Food, hometown, or movie? (or you can type 'all' for all).");
                                        if (userChoice2 == "food")
                                        {
                                            Console.WriteLine(GetStudentFood(names, foods, i));

                                        }
                                        else if (userChoice2 == "hometown")
                                        {
                                            Console.WriteLine(GetStudentHomeTown(names, towns, i));
                                            resume2 = AskToTryAgain(GetUserInput(otherInfo));


                                        }
                                        else if (userChoice2 == "movie")
                                        {
                                            Console.WriteLine(GetStudentMovie(names, movies, i));
                                            resume2 = AskToTryAgain(GetUserInput(otherInfo));

                                        }
                                        else if (userChoice2 == "all")
                                        {
                                            Console.WriteLine(GetAllStudentInfo(names, foods, towns, movies, i));
                                            resume2 = AskToTryAgain(GetUserInput(otherInfo));

                                        }
                                        else
                                        {
                                            Console.WriteLine("Incorrect input.");
                                            resume2 = AskToTryAgain(GetUserInput(otherInfo));

                                        }
                                    } while (resume2);
                                }

                            }
                            resume2 = AskToTryAgain(GetUserInput(tryAgain));
                        } while (resume2);

                    }
                    else if (userInput == "add")
                    {
                        bool resume3 = false;
                        do
                        {
                            AddStudentInfo(names, "What's the name of the student you would like to add?");
                            AddStudentInfo(foods, "What's the name of the student's favorite food?");
                            AddStudentInfo(towns, "What's the name of the student's hometown?");
                            AddStudentInfo(movies, "What's the name of the student's favorite movie?");
                            resume3 = AskToTryAgain(GetUserInput(tryAgain));

                        } while (resume3);

                    }

                    resume = AskToTryAgain(GetUserInput(mainMenu));
                }
                catch(FormatException)
                {
                    resume = AskToTryAgain(GetUserInput(mainMenu));
                }
                catch (StackOverflowException)
                {
                    resume = AskToTryAgain(GetUserInput(mainMenu));
                }
                } while (resume);
            

        }
        static string GetAllStudentInfo(List<string> names, List<string> foods, List<string> towns, List<string> movies, int index)
        {
            return $"Your student's name is {names[index]}. Their favorite food is {foods[index]}, favorite movie is {movies[index]}, and hometown is {towns[index]}";
        }
        static string GetStudentMovie(List<string> names, List<string> movies, int index)
        {
            return $"Your student's name is {names[index]} and their favorite movie is {movies[index]}.";
        }
        static string GetStudentFood(List<string> names, List<string> foods, int index)
        {
            return $"Your student's name is {names[index]} and their favorite food is {foods[index]}.";
        }
        static string GetStudentHomeTown(List<string> names, List<string> towns, int index)
        {
            return $"Your student's name is {names[index]} and their hometown is {towns[index]}.";
        }

        static void AddStudentInfo(List<string> list, string message)
        {
            list.Add(GetUserInput(message).ToLower());
        }
        static bool AskToTryAgain(string input)
        {
            try
            {
                if (input.ToLower()[0] == 'y')
                {
                    return true;
                }
                else if (input.ToLower()[0] == 'n')
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Wrong input. Would you like to try again? (y/n)");
                    string input2 = Console.ReadLine();
                    AskToTryAgain(input2);
                }

            }
            catch (StackOverflowException)
            {

                string userError = GetUserInput("That's not right. Try again: 'y' or 'n'");
                AskToTryAgain(userError);
            }
            
            return true;

        }

        static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
            
        }






    }
}
