using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warnsdorff
{
    internal class Board
    {
        private readonly int[,] board;

        internal Board()
        {
            board = new int[12,12];

            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    if (i == 0 || i == 1 || i == 10 || i == 11 ||
                        j == 0 || j == 1 || j == 10 || j == 11)
                    {
                        board[i, j] = -1;
                    }
                    else
                    {
                        board[i, j] = 0;
                    }
                }
            }
        }

        internal int GetValue((int,int) coordinats)
        {
            return board[coordinats.Item1+2,coordinats.Item2+2];
        }

        internal void SetValue((int,int) coordinats, int value)
        {
            board[coordinats.Item1 + 2, coordinats.Item2 + 2]=value;
        }

        internal void Draw()
        {
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    if (i == 0 || i == 1 || i == 10 || i == 11 ||
                        j == 0 || j == 1 || j == 10 || j == 11)
                    {
                        IO.Send(" ");
                    }
                    else
                    {
                        IO.Send($"{board[i, j].ToString(),3}");
                    }
                }
                IO.SendLine("");
            }
        }
    }
}
