namespace jogo_dos_8
{
    public class Coordinator
    {
        public Coordinator(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; private set; }
        public int Y { get; private set; }
    }
}