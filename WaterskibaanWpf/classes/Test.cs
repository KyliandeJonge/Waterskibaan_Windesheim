using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace WaterskibaanWpf.classes
{
    class Test
    {
        private static System.Timers.Timer aTimer;

       /* public void test()
        {
            aTimer = new System.Timers.Timer(2000);

            MainWindow.mainWindow.lblLijnenVoorraad.Content = Random.Next(5,55);

            aTimer.Enabled = true;
            aTimer.AutoReset = true;

        }*/

        public static void test()
        {
            string voorraad = "";
            Thread thread = new Thread(() => { voorraad = "55"; });
            thread.Start();
            MainWindow.mainWindow.lblLijnenVoorraad.Content = "wait";
            thread.Join();
            MainWindow.mainWindow.lblLijnenVoorraad.Content = voorraad;


            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(2000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            /*            MainWindow.mainWindow.lblLijnenVoorraad.Content = e.SignalTime; */
            
            
        }
    }
}
