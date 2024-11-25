using System.Runtime.InteropServices;
using System.Threading.Channels;


/* A Company has 3 working groups
Group 1 has 5 members
Group 2 has 3 members
Group 3 has 6 members
The data stored for each member has an ID number, full name, and completed task. 
An ID identifies each member 

Select an appropriate data structure to save this info. 
Then write functions to perform the following the tasks:
1. Initialize an array with pre-assigned values or values entered from the keyboard 
2. Print a list of all members
3. Print the information on a member when the ID is known
4. Print the member with the highest number of completed tasks

Create the main program with menus that allow you to select the tasks to be performed.
Hint: Create a jagged array to store these members in the form [ID, [Name, Tasks]] */
internal class Program
{
    static void Main()
    {
        int[] colsize = { 5, 3, 6 };
        int rowsize = 3;
        object[][] database = new object[rowsize][];

        Random rand = new Random();
        string[] randomNames = { "Alice", "Bob", "Charlie", "Diana", "Eve" };

        for (int i = 0; i < rowsize; i++)
        {
            database[i] = new object[colsize[i]];

            for (int j = 0; j < colsize[i]; j++)
            {
                object[] staffinfo = new object[3];
                staffinfo[0] = rand.Next(0, 30);
                staffinfo[1] = randomNames[rand.Next(randomNames.Length)];
                staffinfo[2] = rand.Next(50, 200);
                database[i][j] = staffinfo;
            }
        }

        Console.WriteLine(@"Choose function: 
1. List of all members
2. Member information
3. Most productive member");
        int option = int.Parse(Console.ReadLine());

        switch (option)
        {
            case 1:
                for (int i = 0; i < rowsize; i++)
                {
                    for (int j = 0; j < colsize[i]; j++)
                    {
                        object[] staffinfo = (object[])database[i][j];
                        Console.WriteLine($"ID: {staffinfo[0]}, Name: {staffinfo[1]}, Tasks: {staffinfo[2]}");
                    }
                }
                break;

            case 2:
                Console.Write("Enter member ID: ");
                int searchID = int.Parse(Console.ReadLine());
                bool found = false;
                for (int i = 0; i < rowsize; i++)
                {
                    for (int j = 0; j < colsize[i]; j++)
                    {
                        object[] staffinfo = (object[])database[i][j];
                        if ((int)staffinfo[0] == searchID)
                        {
                            Console.WriteLine($"ID: {staffinfo[0]}, Name: {staffinfo[1]}, Tasks: {staffinfo[2]}");
                            found = true;
                            break;
                        }
                    }
                    if (found) break;
                }
                if (!found) Console.WriteLine("Member not found.");
                break;

            case 3:
                int maxTasks = int.MinValue;
                object[] mostProductiveMember = null;
                for (int i = 0; i < rowsize; i++)
                {
                    for (int j = 0; j < colsize[i]; j++)
                    {
                        object[] staffinfo = (object[])database[i][j];
                        if ((int)staffinfo[2] > maxTasks)
                        {
                            maxTasks = (int)staffinfo[2];
                            mostProductiveMember = staffinfo;
                        }
                    }
                }
                if (mostProductiveMember != null)
                {
                    Console.WriteLine($"Most Productive Member -> ID: {mostProductiveMember[0]}, Name: {mostProductiveMember[1]}, Tasks: {mostProductiveMember[2]}");
                }
                break;

            default:
                Console.WriteLine("Invalid option.");
                break;
        }
    }
}