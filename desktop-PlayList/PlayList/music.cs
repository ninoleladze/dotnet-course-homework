namespace music
{
    internal class Song
    {
        private static int _counter = 1;
        public int Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public int Year { get; set; }
        public bool IsPlaying { get; set; } = false;

        public Song()
        {
            Id = _counter++;
        }

        public override string ToString()
        {
            return $"id : {Id}, title: {Title}, artist:{Artist}, year:{Year}, isplaying: {IsPlaying} ";
        }
    }
}