using System;
using WaterskibaanWpf.classes;

namespace WaterskibaanWpf
{
    public class NieuweBezoekerArgs : EventArgs
    {
        public Sporter sporter;
        public MainWindow window;
        public Kabel kabel;
    }
}