namespace thhylR.Common
{
    public class KeyStats
    {
        public List<int> KeyPressCount { get; set; }
        public List<int> QuickKeyPressCount { get; set; }
        public int TotalKeys { get; set; }
        public int TotalKeyLength { get; set; }
        public double AverageKeyLength { get; set; }
        private int maxKeyPressCount = -1;
        public int MaxKeyPressCount
        {
            get
            {
                if (maxKeyPressCount != -1) return maxKeyPressCount;
                if (KeyPressCount == null) return -1;
                maxKeyPressCount = KeyPressCount.Max();
                return maxKeyPressCount;
            }
        }

        public KeyStats()
        {
            KeyPressCount = new List<int>();
            QuickKeyPressCount = new List<int> { 0, 0, 0 };
            AverageKeyLength = 0d;
        }
    }

    public class FullKeyStats
    {
        public KeyStats KeyboardKey { get; set; }
        public KeyStats ControllerKey { get; set; }
        public int TotalFrames { get; set; }
    }
}
