using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text; 
using System.Threading.Tasks;
using WaterskibaanWpf.interfaces;
using WaterskibaanWpf.moves;

namespace WaterskibaanWpf.classes
{
    class MoveCollection
    {
        public static List<IMoves> GetWillekeurigeMoves()
        {
            List<IMoves> moves = new List<IMoves>();

            for (int i = 0; i < Random.Next(1, 8); i++)
            {
                int random = Random.Next(1, 4);
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

        public static int Next(int min, int max)
        {
            if (min >= max)
            {
                throw new ArgumentException("Min value is greater or equals than Max value.");
            }
            byte[] intBytes = new byte[4];
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetNonZeroBytes(intBytes);
            }
            return min + Math.Abs(BitConverter.ToInt32(intBytes, 0)) % (max - min + 1);
        }

    }
}
