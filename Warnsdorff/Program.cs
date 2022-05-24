namespace Warnsdorff
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var Board = new Board();

            int X = int.Parse(IO.Get("Введите стартовую позицию коня по X (0-7): "));
            int Y = int.Parse(IO.Get("Введите стартовую позицию коня по Y (0-7): "));
            var Start = (X, Y);

            var ChessKnight = new ChessKnight(Board, Start);
            ChessKnight.Run();
            Board.Draw();

            Console.ReadKey();
        }
    }
}