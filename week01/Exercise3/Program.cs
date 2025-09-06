using System;

class Program
{
    static void Main()
    {
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101); // número entre 1 y 100

        int guess = -1;

        Console.WriteLine("Guess My Number Game!");

        while (guess != magicNumber)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        }
    }
}
