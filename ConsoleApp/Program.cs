using System;
using ConsoleApp.Basic;
using DesignPattern;
using DesignPrincipal.Basic.Abstract;
using DesignPrincipal.SOLID;
using Temp;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //new ISPTempDemo().run();
            //new DelegateEx().run();
           new EventAndDelegateEx().run();
        }
    }
}
