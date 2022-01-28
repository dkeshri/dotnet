using System;
using DesignPrincipal.Basic.Interface;

namespace ConsoleApp.Basic.Temp{

    public class Parent{
        protected string Name = "Parent class";
    }
    
    interface IStudent{
        void getName();
    }
    interface ITeacher{
        void getName();
    }
    public class Drived:Parent,ITeacher,IStudent{
    
        public delegate int MyDelegate();
        void IStudent.getName()
        {
            Console.WriteLine("Student Name");
        }
        void ITeacher.getName(){
            Console.WriteLine("Teacher Name");
        }

        public void getName(){

            Console.WriteLine(Name);
        }
    }
    class Test{
        public int testMethod(){
            Console.WriteLine("Test Method");
            return 0;
        }
    }
    public class InterViewPractice : IExecute
    {
        public void run()
        {
            IStudent student = new Drived();
            student.getName();
            ITeacher teacher = new Drived();
            teacher.getName();
            Drived drived = new Drived();
            drived.getName();
            
            Test test = new Test();
            Drived.MyDelegate myDelegate;
            myDelegate = test.testMethod;

            myDelegate();

            //Console.WriteLine();
        }
    }
}