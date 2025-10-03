using System;
using System.Collections.Generic;
using System.Threading;

class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration; // en segundos

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void DisplayStartMessage()
    {
        Console.WriteLine($"\n--- {_name} ---");
        Console.WriteLine(_description);
        Console.Write("\n¿Cuántos segundos deseas durar en esta actividad?: ");
        _duration = int.Parse(Console.ReadLine());
        Console.Clear();
        Console.WriteLine("Prepárate...");
        ShowSpinner(3);
    }

    public void DisplayEndMessage()
    {
        Console.WriteLine($"\n¡Has completado {_duration} segundos en la actividad {_name}!");
        ShowSpinner(3);
    }

    protected void ShowSpinner(int seconds)
    {
        List<string> spinner = new List<string>() { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int i = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(spinner[i]);
            Thread.Sleep(200);
            Console.Write("\b \b");
            i++;
            if (i >= spinner.Count) i = 0;
        }
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    public virtual void Run() { } // Método sobrescrito en las hijas
}

class BreathingActivity : Activity
{
    public BreathingActivity() : base("Actividad de Respiración",
        "Esta actividad te guiará a respirar profundamente y relajarte.")
    { }

    public override void Run()
    {
        DisplayStartMessage();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            Console.Write("\nInhala...");
            ShowCountdown(4);
            Console.Write("\nExhala...");
            ShowCountdown(6);
            Console.WriteLine();
        }

        DisplayEndMessage();
    }
}

class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "Piensa en un momento en que ayudaste a alguien.",
        "Recuerda un reto que superaste.",
        "Reflexiona sobre algo que agradeces hoy.",
        "Piensa en alguien que te inspire."
    };

    public ReflectionActivity() : base("Actividad de Reflexión",
        "Esta actividad te invitará a reflexionar sobre momentos importantes.")
    { }

    public override void Run()
    {
        DisplayStartMessage();
        Random rand = new Random();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            string prompt = _prompts[rand.Next(_prompts.Count)];
            Console.WriteLine($"\n> {prompt}");
            ShowSpinner(5);
        }

        DisplayEndMessage();
    }
}

class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "Enumera cosas que te hagan feliz:",
        "Enumera personas que te apoyan:",
        "Enumera logros de los que estés orgulloso:"
    };

    public ListingActivity() : base("Actividad de Listado",
        "Esta actividad te pedirá enumerar tantas respuestas como puedas.")
    { }

    public override void Run()
    {
        DisplayStartMessage();
        Random rand = new Random();
        string prompt = _prompts[rand.Next(_prompts.Count)];

        Console.WriteLine($"\n{prompt}");
        Console.WriteLine("¡Empieza a escribir! (tienes tiempo limitado)");

        List<string> respuestas = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            if (Console.KeyAvailable)
            {
                string item = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(item))
                {
                    respuestas.Add(item);
                }
            }
        }

        Console.WriteLine($"\n¡Tiempo terminado! Has escrito {respuestas.Count} elementos.");
        DisplayEndMessage();
    }
}

// 🚀 Nueva actividad creativa
class GratitudeActivity : Activity
{
    public GratitudeActivity() : base("Actividad de Gratitud",
        "Esta actividad te invita a escribir cosas por las que estás agradecido.")
    { }

    public override void Run()
    {
        DisplayStartMessage();

        Console.WriteLine("\nEscribe cosas por las que estás agradecido. Tienes tiempo limitado.");
        List<string> agradecimientos = new List<string>();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            if (Console.KeyAvailable)
            {
                string item = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(item))
                {
                    agradecimientos.Add(item);
                }
            }
        }

        Console.WriteLine($"\n¡Tiempo terminado! Has escrito {agradecimientos.Count} cosas por las que estás agradecido.");
        Console.WriteLine("Algunas de ellas:");
        foreach (string a in agradecimientos)
        {
            Console.WriteLine($"- {a}");
        }

        DisplayEndMessage();
    }
}

class Program
{
    static void Main(string[] args)
    {
        int choice = 0;

        while (choice != 5)
        {
            Console.Clear();
            Console.WriteLine("=== Programa de Mindfulness ===");
            Console.WriteLine("1. Actividad de Respiración");
            Console.WriteLine("2. Actividad de Reflexión");
            Console.WriteLine("3. Actividad de Listado");
            Console.WriteLine("4. Actividad de Gratitud");
            Console.WriteLine("5. Salir");
            Console.Write("\nElige una opción: ");

            if (int.TryParse(Console.ReadLine(), out choice))
            {
                Activity activity = null;

                switch (choice)
                {
                    case 1:
                        activity = new BreathingActivity();
                        break;
                    case 2:
                        activity = new ReflectionActivity();
                        break;
                    case 3:
                        activity = new ListingActivity();
                        break;
                    case 4:
                        activity = new GratitudeActivity();
                        break;
                    case 5:
                        Console.WriteLine("¡Hasta luego!");
                        return;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

                if (activity != null)
                {
                    activity.Run();
                    Console.WriteLine("\nPresiona cualquier tecla para regresar al menú...");
                    Console.ReadKey();
                }
            }
        }
    }
}
