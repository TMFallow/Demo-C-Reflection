// See https://aka.ms/new-console-template for more information
using Demo_Reflection;
using System.Reflection;

class Program
{
    public static void Main(string[] args)
    {
        var reflection = new Reflection();
        reflection.Run();

        Console.ReadKey();
    }
}
