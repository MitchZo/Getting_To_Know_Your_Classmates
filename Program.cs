using System;

namespace Lab8
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Hometown { get; set; }
        public string FavoriteFood { get; set; }
        public string Birthday { get; set; }
        public Person(string name, int age, string hometown, string favoriteFood, string birthday)
        {
            Name = name;
            Age = age;
            Hometown = hometown;
            FavoriteFood = favoriteFood;
            Birthday = birthday;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Create students and give them properties
            Person Abe = new Person("Abraham Lincoln", 56, "Sinking Spring Farm", "Hot Dogs", "February 12, 1809");
            Person Cleo = new Person("Cleopatra", 39, "Alexandria", "Koshari", "August 10, 69BC");
            Person Teddy = new Person("Theodore Roosevelt", 60, "New York City", "elk", "October 27, 1858");
            Person Gandhi = new Person("Mohandas Gandhi", 78, "Porbandar", "N/A", "October 2, 1869");
            Person Joan = new Person("Joan of Arc", 19, "Domremy, Duchy of Bar", "steak", "January 6, 1412");
            //assign students to their position in an array
            Person[] students = { Abe, Cleo, Teddy, Gandhi, Joan };

            //start a loop to run again
            bool runAgain = true;
            while (runAgain)
            {
                bool isValid = false;
                Person matchedPerson = null;
                while (!isValid)
                {
                    //show list of options
                    Console.Clear();
                    DisplayStudentMenu();

                    //ask the user for which student they want information.
                    string input = GetUserInput("Which student would you like information about? Please enter either a number or a name.");

                    //determine if the user gave us a number.
                    bool isNumber = ValidateIsInt(input);

                    //if the user gave us a number, make sure it corresponds to an option in the menu
                    if (isNumber)
                    {
                        int menuOption = (int.Parse(input));
                        isValid = ValidateIsInRange(menuOption);

                        try
                        {
                            matchedPerson = students[menuOption - 1];
                        }
                        catch
                        {
                            Console.WriteLine("that is not a valid entry.");
                            Console.ReadKey();
                        }
                    }
                    //if the user didn't give us a number, make sure it's the name of a student.
                    else
                    {
                        isValid = ValidateIsStudent(input, students);
                        if (isValid)
                        { matchedPerson = SelectPerson(input, students); }
                    }
                }
                while (isValid)
                {
                    Console.Clear();
                    DisplayPropertiesMenu();
                    string input = GetUserInput($"what would you like to know about {matchedPerson.Name}?");

                    //determine if the user gave us a number.
                    bool isNumber = ValidateIsInt(input);

                    //if the user gave us a number, make sure it corresponds to an option in the menu
                    if (isNumber)
                    {
                        while (isValid)
                        {
                            int menuOption = (int.Parse(input));
                            isValid = ValidateIsInRange(menuOption);
                            switch (menuOption)
                            {
                                case
                                    1:
                                    Console.WriteLine(matchedPerson.Name);
                                    break;
                                case
                                    2:
                                    Console.WriteLine(matchedPerson.Age);
                                    break;
                                case
                                    3:
                                    Console.WriteLine(matchedPerson.Hometown);
                                    break;
                                case
                                    4:
                                    Console.WriteLine(matchedPerson.FavoriteFood);
                                    break;
                                case
                                    5:
                                    Console.WriteLine(matchedPerson.Birthday);
                                    break;
                                default:
                                    {
                                        isValid = false;
                                        Console.WriteLine("that is not a valid entry. try again.");
                                        input = Console.ReadLine();
                                    }
                                    break;
                            }
                        }
                    }

                    //if the user didn't give us a number, we assume they gave us the name of what they're looking for
                    else
                    {
                        if ((input.ToLower().Equals("name")) ||
                           (input.ToLower().Equals("age")) ||
                           (input.ToLower().Equals("hometown")) ||
                           (input.ToLower().Equals("favorite food")) ||
                           (input.ToLower().Equals("birthday")))
                        {
                            switch (input)
                            {
                                case
                                "name":
                                    Console.WriteLine(matchedPerson.Name);
                                    break;
                                case
                                    "age":
                                    Console.WriteLine(matchedPerson.Age);
                                    break;
                                case
                                    "hometown":
                                    Console.WriteLine(matchedPerson.Hometown);
                                    break;
                                case
                                    "favorite food":
                                    Console.WriteLine(matchedPerson.FavoriteFood);
                                    break;
                                case
                                    "birthday":
                                    Console.WriteLine(matchedPerson.Birthday);
                                    break;

                            }
                            Console.WriteLine($"would you like to know more information about {matchedPerson.Name}?");
                            if (Console.ReadLine().ToLower() == "y" || Console.ReadLine().ToLower() == "yes")
                            {
                                isValid = false;
                            }
                        }
                        else
                        {
                            isValid = false;
                        }
                    }
                }
                Console.WriteLine($"would you like to know more information about a different student?");
                if (Console.ReadLine().ToLower() == "y" || Console.ReadLine().ToLower() == "yes")
                {
                    runAgain = true;
                }
                else { runAgain = false; }
            }
        }



        public static void DisplayStudentMenu()
        {
            Console.WriteLine(
                $"1.Abraham Lincoln\n" +
                $"2.Cleopatra\n" +
                $"3.Theodore Roosevelt\n" +
                $"4.Mohandas Gandhi\n" +
                $"5.Joan of Arc\n");
        }
        public static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();

        }
        public static bool ValidateIsInt(string input)
        {
            return int.TryParse(input, out int selection);
        }
        public static bool ValidateIsInRange(int selection)
        {
            if ((selection >= 1) && (selection <= 5))
                return true;
            else
                return false;
        }
        public static bool ValidateIsStudent(string input, Person[] students)
        {
            bool isValid = false;
            int i = 0;
            while (!isValid && i < students.Length)
            {
                isValid = string.Equals(input, students[i].Name);
                i++;
            }
            return isValid;
        }
        public static void DisplayPropertiesMenu()
        {
            Console.WriteLine(
               $"1.Name\n" +
               $"2.Age\n" +
               $"3.Hometown\n" +
               $"4.Favorite Food\n" +
               $"5.Birthday\n");
        }
        public static Person SelectPerson(string input, Person[] students)
        {
            Person matchedPerson = null;
            foreach (Person student in students)
            {
                if (input == student.Name)
                {
                    matchedPerson = student;
                }
            }
            return matchedPerson;
        }


    }
}