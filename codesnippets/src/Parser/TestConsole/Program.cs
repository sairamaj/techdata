using System;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var methodInfo = SimpleParser.Parser.Parse("${add(num1=10,num2=20,num3=30)}");
            Console.WriteLine(methodInfo.Name);
            foreach (var parameter in methodInfo.Parameters)
            {
                Console.WriteLine($"\t{parameter.Key}={parameter.Value}");
            }
        }
    }
}
