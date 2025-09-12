using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        List<string> entries = new List<string>();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Write entry");
            Console.WriteLine("2. Display entries");
            Console.WriteLine("3. Save to file");
            Console.WriteLine("4. Load from file");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Write your journal entry: ");
                    string entry = Console.ReadLine();
                    entries.Add($"{DateTime.Now}: {entry}");
                    Console.WriteLine("Entry saved!");
                    break;

                case "2":
                    if (entries.Count == 0)
                    {
                        Console.WriteLine("No entries yet.");
                    }
                    else
                    {
                        Console.WriteLine("\nYour Journal:");
                        foreach (var e in entries)
                        {
                            Console.WriteLine(e);
                        }
                    }
                    break;

                case "3":
                    Console.Write("Enter filename: ");
                    string saveFile = Console.ReadLine();
                    File.WriteAllLines(saveFile, entries);
                    Console.WriteLine($"Journal saved to {saveFile}");
                    break;

                case "4":
                    Console.Write("Enter filename: ");
                    string loadFile = Console.ReadLine();
                    if (File.Exists(loadFile))
                    {
                        entries = new List<string>(File.ReadAllLines(loadFile));
                        Console.WriteLine("Journal loaded!");
                    }
                    else
                    {
                        Console.WriteLine("File not found.");
                    }
                    break;

                case "5":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid option, try again.");
                    break;
            }
        }
    }
}
