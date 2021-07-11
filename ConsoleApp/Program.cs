using System;
using DesignPrincipal.Basic.Abstract;
using DesignPrincipal.SOLID;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            OpenClosePrincipal openClosePrincipal = new OpenClosePrincipal();
            openClosePrincipal.run();
            Console.ReadLine();
        }
    }
}
