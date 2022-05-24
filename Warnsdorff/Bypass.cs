namespace Warnsdorff
{
    internal static class Bypass
    {
        private static Board board;
        private static ChessKnight chessKnight;

        internal static void Run()
        {
            IO.Send("ESC Выход, любая другая клавиша начать.");
            var enter = IO.ReadKey();
            IO.SendLine("");
            while (enter != ConsoleKey.Escape)
            {
                if (board == null || chessKnight == null)
                {
                    IO.SendLine("Значения не инициализированны.");
                    BoardInit();
                    ChessKnightInit();
                    chessKnight.Run();
                }
                enter = Choice();
                switch (enter)
                {
                    case ConsoleKey.Enter:
                        chessKnight.Run();
                        break;
                    case ConsoleKey.F1:
                        BoardInit();
                        ChessKnightInit();
                        chessKnight.Run();
                        break;
                    case ConsoleKey.F2:
                        ChessKnightInit();
                        chessKnight.Run();
                        break;
                }
            }
        }

        private static ConsoleKey Choice()
        {
            IO.SendLine("Сделайте выбор: \nEnter запуск с предыдущими параметрами. \nF1 Запуск с новыми параметрами. \nF2 Задать новое положение коня. \nESC Выход");
            return IO.ReadKey();
        }

        private static void BoardInit()
        {
            IO.SendLine("");
            int X = int.Parse(IO.Get("Введите размер доски по X: "));
            int Y = int.Parse(IO.Get("Введите размер доски по Y: "));
            board = new Board(X, Y);
        }
        private static void ChessKnightInit()
        {
            IO.SendLine("");
            int X = int.Parse(IO.Get("Введите стартовую позицию коня по X (0-7): "));
            int Y = int.Parse(IO.Get("Введите стартовую позицию коня по Y (0-7): "));
            var Start = (X, Y);
            chessKnight = new ChessKnight(board, Start);
        }
    }
}
