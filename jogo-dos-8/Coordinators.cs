namespace jogo_dos_8
{
    public class Coordinators
    {
        public Coordinator EmptyCoordinator { get; private set; }
        public Coordinator WordCoordinator { get; private set; }

        public bool NotFound => EmptyCoordinator == null | WordCoordinator == null;

        public void AddEmptyCoordinator(int x, int y)
        {
            if (EmptyCoordinator == null)
            {
                EmptyCoordinator = new Coordinator(x, y);
            }
        }

        public void AddWordCoordinator(int x, int y)
        {
            if (WordCoordinator == null)
            {
                WordCoordinator = new Coordinator(x, y);
            }
        }

        public bool CanMove
        {
            get
            {
                if (EmptyCoordinator == null || WordCoordinator == null)
                {
                    return false;
                }

                // Não pode movimentar na diagonal
                if (WordCoordinator.X != EmptyCoordinator.X && WordCoordinator.Y != EmptyCoordinator.Y)
                {
                    return false;
                }

                bool resultX = WordCoordinator.X - 1 == EmptyCoordinator.X || WordCoordinator.X + 1 == EmptyCoordinator.X;
                bool resultY = WordCoordinator.Y - 1 == EmptyCoordinator.Y || WordCoordinator.Y + 1 == EmptyCoordinator.Y;

                return resultX || resultY;
            }           
        }
    }
}