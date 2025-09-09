using System;

class Program
{
    static void Main()
    {
        // Uso de abstracción con una función del sistema
        Console.WriteLine("Demostración de Abstracción en C#");

        // Uso de nuestra propia abstracción
        Logger.Log("El programa inició correctamente.");
        Calculator calc = new Calculator();

        int suma = calc.Add(10, 5);
        Logger.Log($"La suma es: {suma}");

        int resta = calc.Subtract(10, 5);
        Logger.Log($"La resta es: {resta}");
    }
}

// Clase que abstrae la lógica de logging
class Logger
{
    public static void Log(string message)
    {
        // El detalle (timestamp y formato) está oculto al usuario de la clase
        Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] {message}");
    }
}

// Clase que abstrae operaciones matemáticas
class Calculator
{
    public int Add(int a, int b)
    {
        return a + b;
    }

    public int Subtract(int a, int b)
    {
        return a - b;
    }
}
