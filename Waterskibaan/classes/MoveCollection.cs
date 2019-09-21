using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using System.Threading.Tasks;
using Waterskibaan.interfaces;
using Waterskibaan.moves;

namespace Waterskibaan.classes
{
    class MoveCollection
    {
        public static List<IMoves> GetWillekeurigeMoves()
        {
            Random gen = new Random();
            List<IMoves> moves = new List<IMoves>();

            for (int i = 0; i < gen.Next(1, 8); i++)
            {
                int random = gen.Next(1, 4);
                IMoves move = null;
                switch (random)
                {
                    case 1:
                        move = new Backflip();
                        break;
                    case 2:
                        move = new Frontflip();
                        break;
                    case 3:
                        move = new Jump();
                        break;
                    case 4:
                        move = new Draai360();
                        break;
                }

                moves.Add(move);
            }

            return moves;
        }

    }
}
