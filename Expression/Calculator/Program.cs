using System;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

class Program
{
    static async System.Threading.Tasks.Task Main(string[] args)
    {
        Console.Title = "c# expressioner";
        Console.WindowWidth = 120;
        Console.BufferWidth = 120;
        Console.WindowHeight = 25;
        Console.BufferHeight = 25;
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Enter c# expression");
            Console.Write(" ");
            string input = Console.ReadLine();
            ScriptOptions options = ScriptOptions.Default;
            options = options.AddReferences(typeof(System.Math).Assembly); 
            options = options.WithImports("System", "System.Math");

            try
            {
                var result = await CSharpScript.EvaluateAsync(input, options);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(result);
            }
            catch (CompilationErrorException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR \n" + ex.Message);
            }
            Console.Read();
            Console.Clear();
        }
    }
}
