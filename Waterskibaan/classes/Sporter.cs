﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waterskibaan.interfaces;

namespace Waterskibaan.classes
{
    public class Sporter
    {
        public Zwemvest Zwemvest { get; set; }
        public Skies Skies { get; set; }
        public int AantalRondenTeGaan { get; set; }
        public int AantalBehaaldePunten { get; set; } = 0;

        public IMoves huidigeMove { get; set; }
        public Color KledingKleur { get; set; } = Color.Red;
        public List<IMoves> Moves { get; set; }

       

        public Sporter()
        {
            this.Moves = MoveCollection.GetWillekeurigeMoves();
            this.getBehaaldePunten();
            AantalRondenTeGaan = this.setAantalRondenTeGaan(); 
        }

 

        private int setAantalRondenTeGaan()
        {
            return Random.Next(1,2);
        }

        private void getBehaaldePunten()
        {
            if (this.Moves == null)
                return;

            foreach (IMoves move in this.Moves)
            {
                AantalBehaaldePunten += move.Move();
            }
        }

        public string getNaamHuidigeMove()
        {
            return (huidigeMove != null) ? huidigeMove.Naam() : "geen move";
        }

        public override string ToString()
        {
            return $"{AantalRondenTeGaan} rondes te gaan \n" +
                $"Punten behaald: {AantalBehaaldePunten} \n";
        }
    }
}
