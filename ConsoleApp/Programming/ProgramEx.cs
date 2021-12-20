using System;
using DesignPrincipal.Basic.Interface;

namespace ConsoleApp.Programming{
    public class ProgramEx : IExecute
    {
        private void fibonacciSerise(int n){
            // 0 1 1 2 3 5 8 13
            int a = 0;
            int b= 1;
            int sum = 0;
            for(int i=0;i<n;i++){
                Console.Write(sum + " ");
                a=b;
                b= sum;
                sum = a+b;
            }
        }
        private bool IsArmstrongNum(int n){
            int orignalNumber = n;
            int sum = 0;
            while(n!=0){
                int temp = n%10;
                sum = sum + (temp*temp*temp);
                n = n/10;
            }
            return orignalNumber==sum; 
        }
        private void SeriseOfArmstrongNumber(int n){
            // from 0 to n.

            for(int i=0;i<=n;++i){
                if(IsArmstrongNum(i)){
                    Console.Write(i + " ");
                }
            }

        }
        
        public void run()
        {
            //fibonacciSerise(8);
            SeriseOfArmstrongNumber(1000);
        }
    }
}