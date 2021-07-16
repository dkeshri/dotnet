using DesignPrincipal.Basic.Interface;

namespace DesignPattern{
    public class ObserverPatternDemo : IExecute
    {
        public void run()
        {
            // Create the Object of Observee that is a YouTube Channel (GareebDeveloper)
            GareebDeveloper gareebDeveloper = new GareebDeveloper();

            // Create the Subscribers.
            Subscriber1 subscriber1 = new Subscriber1("Shubham");
            Subscriber2 subscriber2 = new Subscriber2("Lakashay");

            // Register the Subscriber to the Observee. 

            gareebDeveloper.add(subscriber1);
            gareebDeveloper.add(subscriber2);

            // now time to change the state of Observee

            gareebDeveloper.UploadVideo = "Solid Design: SRP";





            


        }
    }
}