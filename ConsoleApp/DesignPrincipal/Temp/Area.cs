using System;
using DesignPrincipal.Basic.Interface;

namespace Temp{
    public class Shape{
        string shape;
        const double PI = 3.14;
        public Shape(string shape){
            this.shape = shape;
        }
        public double Area(){
            double area = 0;
            
            if(this.shape.ToLower().Contains("circle")){
                Console.WriteLine("Enter the radius");
                string radius = Console.ReadLine();
                area = 2*PI*Convert.ToInt64(radius);
            }
            return area;
        }
    }


    public class ExecuteAreaClass : IExecute
    {
        public void run()
        {
            
            Shape shape = new Shape("circle");
            Console.WriteLine("Area of circle is: "+shape.Area());
        }
    }
}