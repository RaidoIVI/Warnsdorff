namespace Warnsdorff
{
    internal class Board
    {
        private readonly int[,] board;

        internal Board(int x, int y)
        {
            board = new int[x+4, y+4];
            Reset();
        }

        internal void Reset()
        {
            int sizeX = board.GetLength(0);
            int sizeY = board.GetLength(1);

            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    if (i == 0 || i == 1 || i == sizeX - 1 || i == sizeX - 2 ||
                        j == 0 || j == 1 || j == sizeY - 1 || j == sizeY - 2)
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

        internal int GetValue((int, int) coordinats)
        {
            return board[coordinats.Item1 + 2, coordinats.Item2 + 2];
        }

        internal void SetValue((int, int) coordinats, int value)
        {
            board[coordinats.Item1 + 2, coordinats.Item2 + 2] = value;
        }

        internal void Draw()
        {
            int sizeX = board.GetLength(0);
            int sizeY = board.GetLength(1);

            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    if (i == 0 || i == 1 || i == sizeX - 1 || i == sizeX - 2 ||
                        j == 0 || j == 1 || j == sizeY - 1 || j == sizeY - 2)
                    {
                        IO.Send(" ");
                    }
                    else
                    {
                        IO.Send($"{board[i, j], 4}");
                    }
                }
                IO.SendLine("");
            }
        }

        internal bool Complite()
        {
            foreach (int value in board)
            {
                if (value == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
