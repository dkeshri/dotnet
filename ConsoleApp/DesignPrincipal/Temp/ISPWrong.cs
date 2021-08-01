using System;
using DesignPrincipal.Basic.Interface;

namespace DesignPrincipal.SOLID
{
    public interface IDrivers
    {
        void PrinterDriver();
        void MouseDriver();
        void DisplayDriver();

    }
    public class Mouse : IDrivers
    {
        public void DisplayDriver()
        {
            throw new System.NotImplementedException();
        }

        public void MouseDriver()
        {
            Console.WriteLine("Implement the logic for install mouse Driver.");
        }

        public void PrinterDriver()
        {
            throw new System.NotImplementedException();
        }
    }
    public class FHDScreen : IDrivers
    {
        public void DisplayDriver()
        {
            Console.WriteLine("Write the logic to install Display driver.");
        }

        public void MouseDriver()
        {
            throw new NotImplementedException();
        }

        public void PrinterDriver()
        {
            throw new NotImplementedException();
        }
    }
    public class HpPrinter : IDrivers
    {
        public void DisplayDriver()
        {
            throw new NotImplementedException();
        }

        public void MouseDriver()
        {
            throw new NotImplementedException();
        }

        public void PrinterDriver()
        {
            Console.WriteLine("Write the logic to install Printer driver.");
        }
    }

    public class ISPTempDemo : IExecute
    {
        public void run()
        {
            Mouse mouse = new Mouse();
            mouse.MouseDriver();
            HpPrinter hpPrinter = new HpPrinter();
            hpPrinter.PrinterDriver();
            FHDScreen fHDScreen = new FHDScreen();
            fHDScreen.DisplayDriver();
        }
    }
}