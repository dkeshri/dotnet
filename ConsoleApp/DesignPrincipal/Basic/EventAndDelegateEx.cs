using System;
using System.Threading;
using DesignPrincipal.Basic.Interface;

namespace ConsoleApp.Basic
{

    public class VideoEncoder
    {
        //1. define Delegate
        //2. define Event based on delegate
        //3. raise the event.
        public delegate void VideoEncodedEventHandler(object sender, EventArgs eventArgs); // define delegate
        public event VideoEncodedEventHandler VideoEncoded; // defaine event.
        public void Encode()
        {

            Console.WriteLine("Video Encoding.....");
            Thread.Sleep(3000);

            onVideoEncoded(); // raise Event
        }
        protected virtual void onVideoEncoded(){
            if(VideoEncoded!=null)
                VideoEncoded(this,EventArgs.Empty);
        }
    }
    public class EventAndDelegateEx : IExecute
    {
        public void run()
        {
            VideoEncoder videoEncoder = new VideoEncoder(); // Publisher who fire event.
            Mailservice mailservice = new Mailservice(); // subscriber1
            MessageService messageService = new MessageService(); // subscriber 2
            videoEncoder.VideoEncoded += mailservice.onVideoEncoded;
            videoEncoder.VideoEncoded += messageService.sentMessage;

            videoEncoder.Encode();

        }
    }
    public class Mailservice{
        public void onVideoEncoded(object sender,EventArgs args){
            Console.WriteLine("Sending mail");
        }
    }
    public class MessageService{
        public void sentMessage(object sender, EventArgs args){
            Console.WriteLine("Sending Message");
        }
    }
}