using System;

namespace jogo_dos_8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(">>>>>>>>>>> Jogos dos 8 <<<<<<<<<<<");
            Console.WriteLine();
            Console.WriteLine("Informe o nível de dificuldade:");
            Console.WriteLine("1 - Iniciante");
            Console.WriteLine("2 - Intermediário");
            Console.WriteLine("3 - Avançado");

            ELevel level = (ELevel)Convert.ToInt32(Console.ReadLine());

            Board board = new Board(level);
            board.Draw();

            do
            {
                Console.WriteLine();
                Console.WriteLine("Informe a letra que gostaria de movimentar:");
                char word = Convert.ToChar(Console.ReadLine().ToUpper());

                board.Move(word);
                board.Draw();
            } while (!board.IsOrdered);

            Console.WriteLine();
            Console.WriteLine("Parabéns! Você ordenou o tabuleiro");

            Console.ReadKey();
        }
    }
}