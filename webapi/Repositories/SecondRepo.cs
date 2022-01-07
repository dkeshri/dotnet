using System;

namespace Webapi.Repositories{
    public class SecondRepo : ISecondRepo
    {
        // just to test how to pass multiple Dependency in a class. by using .net core
        // Dependency Injetion functionality.
        public void display()
        {
            Console.Write("Secondry repo test deepak");
        }
    }
}