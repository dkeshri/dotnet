using System;

namespace DesignPattern{

    // Observer 
    public interface IObsever{
        public void update(IObservee observee); 
    }

    public class Subscriber1 : IObsever
    {
        public string Name{get;set;}
        public Subscriber1(string name){
            this.Name = name;
        }
        public void update(IObservee observee)
        {
            if(observee is GareebDeveloper gareebDeveloper){
                Console.Write("Subscriber: "+this.Name+" is notified that Video is Uploaded: => ");
                Console.WriteLine(gareebDeveloper.UploadVideo);
            }
        }
    }
    public class Subscriber2 : IObsever
    {
        public string Name{get;set;}
        public Subscriber2(string name){
            this.Name = name;
        }
        public void update(IObservee observee)
        {
            if(observee is GareebDeveloper gareebDeveloper){
                Console.Write("Subscriber: "+this.Name+" is notified that Video is Uploaded: => ");
                Console.WriteLine(gareebDeveloper.UploadVideo);
            }
        }
    }
}