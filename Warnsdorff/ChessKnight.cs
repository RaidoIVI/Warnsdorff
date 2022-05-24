using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warnsdorff
{
    internal class ChessKnight
    {
        private Board board;
        private (int, int) currentCoordinat;
        private bool stack;
        private int stepCounter;

        internal ChessKnight(Board board, (int, int) currentCoordinat)
        {
            this.board = board;
            this.currentCoordinat = currentCoordinat;
            stack = false;
            stepCounter = 1;
        }

        private int GetWieght((int, int) coordinats)
        {
            return GetPosibleMove(coordinats).GetLength(0);
        }

        private (int, int)[] GetPosibleMove((int, int) coordinats)
        {
            (int,int) posibleCoordinats;
            List<(int, int)> result = new List<(int, int)>();

            for (int i = -2; i < 3; i++)
            {
                for (int j = -2; j < 3; j++)
                {
                    if ((i + j) % 2 != 0 && i != 0 && j != 0)
                    {
                        posibleCoordinats = (coordinats.Item1 + i, coordinats.Item2 + j);
                        if (board.GetValue(posibleCoordinats) == 0)
                        {
                            result.Add(posibleCoordinats);
                        }
                    }
                }
            }
            if (result.Count == 0)
            {
                stack = true;
                posibleCoordinats = (-1, -1);
                result.Add(posibleCoordinats);
            }
            return result.ToArray();
        }

        private (int, int) FindMove((int, int) coordinats)
        {
            (int, int) lightCoordinat = GetPosibleMove(coordinats)[0];
            if (lightCoordinat.Item1 == -1)
            {
                return lightCoordinat;
            }
            int minWieght = GetWieght(lightCoordinat);

            foreach ((int, int) coordinat in GetPosibleMove(coordinats))
            {
                if (minWieght > GetWieght(coordinat))
                {
                    lightCoordinat = coordinat;
                    minWieght = GetWieght(lightCoordinat);
                }
                else
                {
                    var rnd = new Random();
                    if (rnd.Next(10)%2==0 && minWieght == GetWieght(coordinat))
                    {
                        lightCoordinat = coordinat;
                    }
                }
            }
            return lightCoordinat;
        }

        private bool Move()
        {
            var nextMove = FindMove(currentCoordinat);
            if (!stack)
            {
                board.SetValue(currentCoordinat, stepCounter);
                stepCounter++;
                currentCoordinat = nextMove;
                return true;
            }
            else
            {
                return false;
            }
        }

        private void LastMove()
        {
            board.SetValue(currentCoordinat, stepCounter);
        }

        internal void Run()
        {
            var step = Move();
            while (step)
            {
                step = Move();
            }
            LastMove();
        }
    }
}
