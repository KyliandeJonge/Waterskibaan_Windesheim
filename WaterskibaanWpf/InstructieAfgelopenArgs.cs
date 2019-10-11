using System;
using System.Collections.Generic;
using WaterskibaanWpf.classes;

namespace WaterskibaanWpf
{
    public class InstructieAfgelopenArgs : EventArgs
    {
        public List<Sporter> sporters = new List<Sporter>();
    }
}