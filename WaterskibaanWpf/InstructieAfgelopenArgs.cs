using System;
using System.Collections.Generic;
using WaterskibaanWpf.classes;

namespace WaterskibaanWpf
{
    public class InstructieAfgelopenArgs : EventArgs
    {
        public List<Sporter> sporters = new List<Sporter>();

        public List<Sporter> instructiegroep = new List<Sporter>();

        public Queue<Sporter> tempList = new Queue<Sporter>();
        
        public int InstructieAantal { get; set; }
        public int InstructieWachtrijAantal { get; set; }
    }
}