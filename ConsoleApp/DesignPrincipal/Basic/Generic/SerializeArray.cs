using System;
using DesignPrincipal.Basic.Interface;
using Newtonsoft.Json;

namespace ConsoleApp.Basic.Generic
{
    class SerializeArray
    {
        public string SerializeArrayOfString(string[] list)
        {
            // string[] list = new string[] { "Deepak", "kumar", "keshri" };
            // combine all the string in array to a single string.
            string singleString = JsonConvert.SerializeObject(list);
            return singleString;
        }
        public string[] DeserilizeString(string s)
        {
            return JsonConvert.DeserializeObject<string[]>(s);
        }
    }
}