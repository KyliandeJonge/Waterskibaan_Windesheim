namespace WaterskibaanWpf.classes
{
    public class WachtrijStarten : Wachtrij
    {
        public int MAX_LENGTE_RIJ = 20;

        public void OnInstructieAfgelopen(InstructieAfgelopenArgs args)
        {
            for (int i = 0; i < 5; i++)
            {
                if (args.InstructieAantal >= 5 && wachtrij.Count < MAX_LENGTE_RIJ)
                {

                    wachtrij.Enqueue(args.tempList.Dequeue());
                }
            }
        }
    }
}
