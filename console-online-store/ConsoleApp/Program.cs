namespace ConsoleApp1
{
    /// <summary>
    /// Application entry point.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Starts the console UI, beginning as a guest.
        /// </summary>
        /// <param name="args">Command-line arguments (unused).</param>
        public static void Main(string[] args)
        {
            UserMenuController.Start();
        }
    }
}
