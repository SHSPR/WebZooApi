namespace WebZoo
{
    public static class InMemoryDatabase
    {
        public static List<Animal> Animals { get; } = new List<Animal>();

        private static int _nextId = 1;

        public static int GetNextId()
        {
            return _nextId++;
        }
    }
}
