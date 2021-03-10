using System;
using System.Collections.Generic;
using System.Linq;

namespace jogo_dos_8
{
    public class Board
    {
        private char[,] _pieces;
        private int _movements;
        private List<char> _wordsRangeForGame;
        private readonly List<char> _words = new List<char>
        {
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
        };

        public Board(ELevel level)
        {
            switch (level)
            {
                case ELevel.Amateur:
                    {
                        BuildBoard(dimension: 3);
                        break;
                    }
                case ELevel.Intermediate:
                    {
                        BuildBoard(dimension: 4);
                        break;
                    }
                case ELevel.Advanced:
                    {
                        BuildBoard(dimension: 5);
                        break;
                    }
            }
        }

        public bool IsOrdered
        {
            get
            {
                int index = 0;
                int lines = _pieces.GetLength(0);
                int columns = _pieces.GetLength(1);

                for (int x = 0; x < lines; x++)
                {
                    for (int y = 0; y < columns; y++)
                    {
                        // Se tiver na última posição linhe a coluna
                        if (x + 1 == lines && y + 1 == columns)
                        {
                            break;
                        }

                        if (_pieces[x, y] != _wordsRangeForGame[index])
                        {
                            return false;
                        }

                        index++;
                    }
                }

                return true;
            }
        }

        public void Draw()
        {
            Console.Clear();

            int lines = _pieces.GetLength(0);
            int columns = _pieces.GetLength(1);

            for (int x = 0; x < lines; x++)
            {
                for (int y = 0; y < columns; y++)
                {
                    if (_pieces[x, y] == '\0')
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write(_pieces[x, y]);
                    }

                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine($"Movimentos: {_movements}");
        }

        public void Move(char word)
        {
            Coordinators coordinators = _pieces.GetCoordinators(word);

            if (coordinators.NotFound || !coordinators.CanMove)
            {
                return;
            }

            char wordToChange = _pieces[coordinators.WordCoordinator.X, coordinators.WordCoordinator.Y];

            _pieces[coordinators.EmptyCoordinator.X, coordinators.EmptyCoordinator.Y] = wordToChange;
            _pieces[coordinators.WordCoordinator.X, coordinators.WordCoordinator.Y] = '\0';

            _movements++;
        }

        private void BuildBoard(int dimension)
        {
            _pieces = new char[dimension, dimension];

            int sizeRangeOfWords = (dimension * dimension) - 1;
            _wordsRangeForGame = _words.GetRange(0, sizeRangeOfWords);

            List<char> wordsDescOrdered = _wordsRangeForGame.OrderByDescending(word => word).ToList();
            int index = 0;

            for (int x = 0; x < dimension; x++)
            {
                for (int y = 0; y < dimension; y++)
                {
                    // Se tiver na última posição linhe a coluna, fica vazia
                    if (x + 1 == dimension && y + 1 == dimension)
                    {
                        break;
                    }

                    _pieces[x, y] = wordsDescOrdered[index];
                    index++;
                }
            }
        }
    }
}