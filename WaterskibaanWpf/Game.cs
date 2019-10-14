using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using WaterskibaanWpf.classes;

namespace WaterskibaanWpf
{
    public class Game
    {
        // Nieuwe bezoeker
        public delegate void NieuweBezoekerHandler(NieuweBezoekerArgs args);
        public event NieuweBezoekerHandler NieuweBezoeker;

        // Instructie afgelopen
        public delegate void InstructieAfgelopenHandler(InstructieAfgelopenArgs args);
        public event InstructieAfgelopenHandler InstructieAfgelopen;

        // Lijnen verplaatsen
        public delegate void LijnenVerplaatstHandler(LijnenVerplaatstArgs args);
        public event LijnenVerplaatstHandler LijnenVerplaatst;

        WaterskibaanObj waterskibaan = new WaterskibaanObj();

        // Wachtrijen
        WachtrijInstructie wachtrijInstructie = new WachtrijInstructie();
        InstructieGroep instructieGroep = new InstructieGroep();
        WachtrijStarten wachtrijStarten = new WachtrijStarten();

        public void Initialize()
        {
            this.NieuweBezoeker += wachtrijInstructie.OnNieuweBezoeker;

            this.InstructieAfgelopen += wachtrijInstructie.OnInstructieAfgelopen;
            this.InstructieAfgelopen += instructieGroep.OnInstructieAfgelopen;
            this.InstructieAfgelopen += wachtrijStarten.OnInstructieAfgelopen;

            this.LijnenVerplaatst += waterskibaan.VerplaatsKabel;
            /*this.LijnenVerplaatst += this.StartSporter;*/


            int loopCount = 0;

            while (true)
            {
                if (loopCount % 3 == 0 && loopCount != 0)
                {
                    this.NieuweBezoeker(new NieuweBezoekerArgs() { sporter = new Sporter() });
                }

                if (loopCount % 4 == 0 && loopCount != 0)
                {
                    this.LijnenVerplaatst(new LijnenVerplaatstArgs());
                }
                if (loopCount == 25)
                {
                    StartSporter(new LijnenVerplaatstArgs());
                }

                if (loopCount % 20 == 0 && loopCount != 0)
                {
                    this.InstructieAfgelopen(new InstructieAfgelopenArgs());
                }

                Console.WriteLine("Aantal loops: " + loopCount);
                Console.WriteLine("Grootte van instructie wachtrij: " + wachtrijInstructie.wachtrij.Count);
                Console.WriteLine("Grootte vab starten wachtrij: " + wachtrijStarten.wachtrij.Count);
                Console.WriteLine(waterskibaan);
                Console.WriteLine("\n\n");

                loopCount++;
                Thread.Sleep(1000);
            }
        }



        public void StartSporter(LijnenVerplaatstArgs args)
        {
            if (waterskibaan.kabel.IsStartPositieLeeg() && !wachtrijStarten.IsWachtrijLeeg())
            {
                Console.WriteLine("start sporter good");
                List<Sporter> sporters = wachtrijStarten.SportersVerlatenRij(1);
                Sporter sporter = sporters.First();
                sporter.Skies = new Skies();
                sporter.Zwemvest = new Zwemvest();

                waterskibaan.SporterStart(sporter);

            }
            else
            {
                Console.WriteLine("start sporter bad");
            }






        }
    }
}
