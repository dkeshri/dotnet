using System;
using DesignPrincipal.Basic.Abstract;
using DesignPrincipal.SOLID;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Deepak hello ");
            // AbstractClassHandler abstractClassHandler = new AbstractClassHandler();
            // abstractClassHandler.run();
            ApiHandler apiHandler = new ApiHandler();
            apiHandler.handleModules();
            Console.ReadLine();
        }
    }
}
