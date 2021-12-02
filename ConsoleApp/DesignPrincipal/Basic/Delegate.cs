using System;
using DesignPrincipal.Basic.Interface;

namespace ConsoleApp.Basic{
    public class DelegateEx : IExecute
    {
        public delegate int MyDelegate (int a,int b);
        public int test(int a, int b){
            return a+b;
        }
        public void run()
        {
            MyDelegate myDelegate = test;
            
            Console.WriteLine(myDelegate(2,8));

            // we can do this way too.
            Console.WriteLine(new MyDelegate(test)(9,7));
            
        }
    }
}