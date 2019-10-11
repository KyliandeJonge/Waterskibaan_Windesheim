using System;
using System.Collections.Generic;
using Waterskibaan.classes;

namespace Waterskibaan
{
    public class InstructieAfgelopenArgs : EventArgs
    {
        public List<Sporter> sporters = new List<Sporter>();
    }
}