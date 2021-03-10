namespace jogo_dos_8
{
    public static class Extensions
    {
        public static Coordinators GetCoordinators(this char[,] array, char word)
        {
            Coordinators coordinators = new Coordinators();

            int lines = array.GetLength(0);
            int columns = array.GetLength(1);

            for (int x = 0; x < lines; x++)
            {
                for (int y = 0; y < columns; y++)
                {
                    if (array[x, y] == word)
                    {
                        coordinators.AddWordCoordinator(x, y);
                    }

                    if (array[x, y] == '\0')
                    {
                        coordinators.AddEmptyCoordinator(x, y);
                    }
                }
            }

            return coordinators;
        }
    }
}