﻿using System;
using System.Collections;
using System.Collections.Generic;
using WaterskibaanWpf.classes;

namespace WaterskibaanWpf
{
    public class LijnenVerplaatstArgs : EventArgs
    {
        /*public Queue<Sporter> wachtendeSporters = new Queue<Sporter>();*/
        InstructieAfgelopenArgs afgelopenArgs;

        public void test()
        {
            Console.WriteLine(afgelopenArgs.sporters.Count + " asdfasfas");
        }
    }
}