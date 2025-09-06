using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter your grade percentage: ");
        int grade = int.Parse(Console.ReadLine());

        string letter;

        if (grade >= 90) letter = "A";
        else if (grade >= 80) letter = "B";
        else if (grade >= 70) letter = "C";
        else if (grade >= 60) letter = "D";
        else letter = "F";

        Console.WriteLine($"Your letter grade is: {letter}");

        if (grade >= 70)
        {
            Console.WriteLine("Congratulations, you passed!");
        }
        else
        {
            Console.WriteLine("Keep working hard, you can do it next time!");
        }
    }
}
