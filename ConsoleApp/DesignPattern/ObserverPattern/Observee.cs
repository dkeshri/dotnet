using System.Collections.Generic;

namespace DesignPattern{
    // Observee

    public interface IObservee{
        public void add(IObsever obsever);
        public void remove(IObsever obsever);
        public void notify();
    }

    // a youtTube channel.
    public class GareebDeveloper : IObservee
    {
        private List<IObsever> ObseverList;
        private string uploadVideo;
        public string UploadVideo{ get{ return this.uploadVideo;} 
        set{
            this.uploadVideo = value;
            this.notify();
        }
        }
        public GareebDeveloper(){
            ObseverList = new List<IObsever>();
        }
        public void add(IObsever obsever)
        {
            this.ObseverList.Add(obsever);
        }

        public void notify()
        {
            foreach(IObsever obsever in ObseverList){
                obsever.update(this);
            }
        }

        public void remove(IObsever obsever)
        {
            this.ObseverList.Remove(obsever);
        }
    }
}