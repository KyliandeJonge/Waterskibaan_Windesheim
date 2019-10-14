using System.Linq;

namespace WaterskibaanWpf.classes
{
    public class InstructieGroep : Wachtrij
    {
        public int MAX_LENGTE_RIJ = 25;

        public void OnInstructieAfgelopen(InstructieAfgelopenArgs args)
        {

            args.InstructieAantal = this.wachtrij.Count();

            foreach (Sporter s in args.instructiegroep)
            {
                if (wachtrij.Count < MAX_LENGTE_RIJ)
                {
                    wachtrij.Enqueue(s);
                }
            }
        }
    }
}
