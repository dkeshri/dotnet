using System;
using DesignPrincipal.Basic.Interface;
using Newtonsoft.Json;

namespace ConsoleApp.Basic.Generic
{
    public class GenericEx : IExecute
    {
        public void run()
        {
            string[] listOfString = new string[] { "Deepak", "kumar", "keshri" };
            SerializeArray serializeArray = new SerializeArray();
            string serializeArrayString = serializeArray.SerializeArrayOfString(listOfString);
            System.Console.WriteLine(serializeArrayString);
            string[] list = serializeArray.DeserilizeString(serializeArrayString);
            foreach(string s in list)
            System.Console.WriteLine(s);
        }
    }
}