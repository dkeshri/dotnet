using System;
using DesignPrincipal.Basic.Abstract;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Deepak hello ");
            AbstractClassHandler abstractClassHandler = new AbstractClassHandler();
            abstractClassHandler.run();
            Console.ReadLine();
        }
    }
}
