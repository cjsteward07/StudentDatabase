string[] hometownArray = { "Marysville", "Fraser", "Wahiawa", "Waipahu" };
string[] favoriteFoodArray = { "Steak", "Crab", "Pizza", "Tacos" };
void Menu()
{
    string[] nameArray = { "Colin", "Zoe", "Ferguson", "Gumby" };
    string userInput = string.Empty;
    Console.WriteLine("Student Database\n");

    while (true)
    {
        Console.WriteLine("Select from an option below: ");
        Console.WriteLine("1.) Student Info");
        Console.WriteLine("2.) Search by Student Name");
        Console.WriteLine("3.) List all Students");
        Console.WriteLine("4.) Quit");
        userInput = Console.ReadLine();
        if (int.TryParse(userInput, out int menuChoice))
        {
            if (menuChoice >= 1 && menuChoice <= 4)
            {
                switch (menuChoice)
                {
                    case 1:
                        StudentSelector(nameArray);
                        break;
                    case 2:
                        StudentSearch(nameArray);
                        break;
                    case 3:
                        StudentList(nameArray);
                        break;
                    case 4:
                        Console.WriteLine("Goodbye");
                        Environment.Exit(0);
                        break;
                    default:
                        Environment.Exit(0);
                        break;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid input. Please enter a valid integer from the menu: \n");
            }
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Invalid input. Please enter a valid integer from the menu: \n");
        }
    }
}
void StudentSelector(string[] nameArray)
{
    Console.Clear();
    while (true)
    {
        int nameArrayLength = nameArray.Length;
        int student;
        int nameCount = 1;
        string userInput = string.Empty;
        Console.WriteLine($"Please enter a number 1-{nameArrayLength} ");
        foreach (string name in nameArray)
        {
            Console.WriteLine($"{nameCount}.) {name}");
            nameCount++;
        }
        userInput = Console.ReadLine();
        if (int.TryParse(userInput, out student))
        {
            if (student >= 1 && student <= nameArrayLength)
            {
                string studentName = nameArray[student - 1];
                StudentCategories(student, studentName);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid input. Please enter a valid integer from the menu: \n");
            }
        }          
        else
        {
            Console.Clear();
            Console.WriteLine("Invalid input. Please enter a valid integer from the menu: \n");
        }
    }
}

void StudentCategories(int student, string studentName)
{
    Console.Clear();
    string hometownString = "Hometown";
    string favoriteFoodString = "Favorite Food";
    while (true)
    {
        Console.WriteLine($"Which category would you like to display for {studentName}?");
        Console.WriteLine("Hometown");
        Console.WriteLine("Favorite Food");
        string studentCategory = Console.ReadLine().ToLower().Trim();
        //Need to add support for partial words
        if (studentCategory == "hometown" || hometownString.ToLower().Contains(studentCategory))
        {
            Console.Clear();
            Console.WriteLine($"Student Name: {studentName}");
            Console.WriteLine($"Student Hometown: {hometownArray[student - 1]}");
            break;
        }
        else if (studentCategory == "favoritefood" || favoriteFoodString.ToLower().Contains(studentCategory))
        {
            Console.Clear();
            Console.WriteLine($"Student Name: {studentName}");
            Console.WriteLine($"Student Favorite Food: {favoriteFoodArray[student - 1]}");
            break;
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Sorry, I didn't catch that.\n");
        }
    }
    while (true)
    {
        Console.Write("\nWould you like to run again [y]/[n]?: ");
        string userChoice = Console.ReadLine().ToLower().Trim();
        if (userChoice == "y")
        {
            Console.Clear();
            Menu();
        }
        else if (userChoice == "n")
        {
            Console.Clear();
            Console.WriteLine("Goodbye!");
            Environment.Exit(0);
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Invalid input");
        }
    }
}
void StudentSearch(string[] nameArray)
{
    Console.Clear();
    while (true)
    {
        Console.Write("Please enter the student's name you'd like to search for: ");
        string studentSearch = Console.ReadLine().ToLower().Trim();
        string firstLetter = studentSearch.Substring(0, 1).ToUpper();
        string restOfWord = studentSearch.Substring(1);
        studentSearch = firstLetter + restOfWord;
        if (nameArray.Contains(studentSearch))
        {
            Console.Clear();
            int studentIndex = Array.IndexOf(nameArray, studentSearch) + 1;
            Console.WriteLine($"Found {studentSearch}!\n");
            StudentCategories(studentIndex, studentSearch);
        }
        else if (!(nameArray.Contains(studentSearch)))
        {
            Console.Clear();
            Console.WriteLine($"{studentSearch} not found\n");
        }
    }
}
void StudentList(string[] nameArray)
{
    Console.Clear();
    Console.WriteLine("Here's the list of students: ");
    foreach (string name in nameArray)
    {
        Console.WriteLine(name);
    }
    while (true)
    {
        Console.Write("\nWould you like to run again [y]/[n]?: ");
        string userChoice = Console.ReadLine().ToLower().Trim();
        if (userChoice == "y")
        {
            Console.Clear();
            Menu();
        }
        else if (userChoice == "n")
        {
            Console.Clear();
            Console.WriteLine("Goodbye!");
            Environment.Exit(0);
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Invalid input");
        }
    }
}
Menu();
