string[] hometownArray = { "Marysville", "Fraser", "Wahiawa", "Waipahu" };
string[] favoriteFoodArray = { "Steak", "Crab", "Pizza", "Tacos" };
void Menu()
{
    string[] nameArray = { "Colin", "Zoe", "Ferguson", "Gumby" };
    Console.WriteLine("Student Database\n");
    Console.WriteLine("Select from an option below: ");
    Console.WriteLine("1.) Student Info");
    Console.WriteLine("2.) Search by Student Name");
    Console.WriteLine("3.) List all Students");
    int menuChoice = int.Parse(Console.ReadLine());
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
        default:
            Console.WriteLine("default placeholder");
            break;
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
        Console.WriteLine($"Please enter a number 1-{nameArrayLength} ");
        foreach (string name in nameArray)
        {
            Console.WriteLine($"{nameCount}.) {name}");
            nameCount++;
        }
        try
        {
            student = int.Parse(Console.ReadLine());
            if (student < 1 || student > nameArrayLength)
            {
                Console.Clear();
                Console.WriteLine("Invalid input. Please enter a valid integer from the menu: \n");
            }
            else if (student >= 1 || student <= nameArrayLength)
            {
                StudentCategories(student);
            }
        }
        catch
        {
            Console.Clear();
            Console.WriteLine("Invalid input. Please enter a valid integer from the menu: \n");
        }
    }
}
void StudentCategories(int student)
{
    Console.Clear();
    // string[] hometownArray = {"Marysville", "Fraser", "Wahiawa", "Waipahu"};
    // string[] favoriteFoodArray = {"Steak", "Crab", "Pizza", "Tacos"};
    string hometownString = "Hometown";
    string favoriteFoodString = "Favorite Food";
    while (true)
    {
        Console.WriteLine("Which category would you like to display?");
        Console.WriteLine("Hometown");
        Console.WriteLine("Favorite Food");
        string studentCategory = Console.ReadLine().ToLower().Trim();
        //Need to add support for partial words
        if (studentCategory == "hometown" || hometownString.ToLower().Contains(studentCategory))
        {
            Console.Clear();
            Console.WriteLine(hometownArray[student - 1]);
            break;
        }
        else if (studentCategory == "favoritefood" || favoriteFoodString.ToLower().Contains(studentCategory))
        {
            Console.Clear();
            Console.WriteLine(favoriteFoodArray[student - 1]);
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
            break;
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Invalid input");
            break;
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
            StudentCategories(studentIndex);
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
    while (true)
    {
        Console.WriteLine("Here's the list of students: ");
        foreach (string name in nameArray)
        {
            Console.WriteLine(name);
        }
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
            break;
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Invalid input");
            break;
        }
    }
}
Menu();