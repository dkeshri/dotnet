using System;
using DesignPrincipal.Basic.Abstract;
using DesignPrincipal.SOLID;
using Temp;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // OpenClosePrincipal openClosePrincipal = new OpenClosePrincipal();
            // openClosePrincipal.run();

            ExecuteAreaClass executeAreaClass = new ExecuteAreaClass();
            executeAreaClass.run();

            Console.ReadLine();
        }
    }
}
