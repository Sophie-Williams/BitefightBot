namespace BitefightBot.Service
{
    public static class DirectoryService
    {
        public static string Directory { get; private set; }

        public static string BaseDir()
        {
            return Directory;
        }

        public static void Set(string text)
        {
            Directory = text;
        }
    }
}