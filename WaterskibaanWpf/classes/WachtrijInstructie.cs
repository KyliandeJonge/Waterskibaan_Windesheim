namespace WaterskibaanWpf.classes
{
    public class WachtrijInstructie : Wachtrij
    {
        public int MAX_LENGTE_RIJ = 100;
        public int instructieGrootte;

        public void OnNieuweBezoeker(NieuweBezoekerArgs args)
        {
            if (wachtrij.Count < this.MAX_LENGTE_RIJ)
            {
                wachtrij.Enqueue(args.sporter);
            }
        }

        public void OnInstructieAfgelopen(InstructieAfgelopenArgs args)
        {
            int counter = 5;
            if (args.InstructieAantal >= 19)
            {
                counter = 24 - args.InstructieAantal;
            }
            

            for (int i = 0; i < counter; i++)
            {
                args.instructiegroep.Add(wachtrij.Dequeue());
            }
        }
    }
}
