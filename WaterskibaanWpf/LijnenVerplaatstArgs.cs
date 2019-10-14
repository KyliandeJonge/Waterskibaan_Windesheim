using System;
using System.Collections.Generic;
using WaterskibaanWpf.classes;

namespace WaterskibaanWpf
{
    public class LijnenVerplaatstArgs : EventArgs
    {
        public Queue<Sporter> wachtendeSporters = new Queue<Sporter>();

    }
}