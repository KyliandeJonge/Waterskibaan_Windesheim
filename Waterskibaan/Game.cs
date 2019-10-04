using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waterskibaan.classes;
using System.Threading;

namespace Waterskibaan
{
    class Game
    {
        public delegate void NieuweBezoekerHandler(NieuweBezoekerArgs args);
        public event NieuweBezoekerHandler NieuweBezoeker;

        WaterskibaanObj waterskibaan = new WaterskibaanObj();
        WachtrijInstructie wachtrijInstructie = new WachtrijInstructie();
        InstructieGroep instructieGroep = new InstructieGroep();
        WachtrijStarten wachtrijStarten = new WachtrijStarten();


     

        public void Initialize()
        {
            this.NieuweBezoeker += wachtrijInstructie.OnNieuweBezoeker;

            int loopCount = 0;

            //
            
            
            while (true) {
                if (loopCount % 3 == 0)
                {
                    this.NieuweBezoeker(new NieuweBezoekerArgs() { sporter = new Sporter() });
                }
                   
                    
                if (loopCount % 20 == 0)
                {
                    this.NieuweBezoeker(new NieuweBezoekerArgs() { sporter = new Sporter() });
                }
                    

                StartSportersAndVerplaatsBaan();

                
                
                loopCount++;
            }
        }



        public void StartSportersAndVerplaatsBaan()
        {
            Sporter sporter = new Sporter();
            sporter.Skies = new Skies();
            sporter.Zwemvest = new Zwemvest();

            waterskibaan.SporterStart(sporter);
            waterskibaan.VerplaatsKabel();

            Console.WriteLine(waterskibaan);
            Thread.Sleep(1000);
        }
    }
}
