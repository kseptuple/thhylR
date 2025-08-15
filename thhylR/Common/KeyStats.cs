namespace thhylR.Common
{
    public class KeyStats
    {
        public List<List<int>> KeyPressCount { get; set; }
        public List<int> QuickKeyPressCount { get; set; }
        public int TotalKeys { get; set; }
        public int TotalKeyLength { get; set; }
        public double AverageKeyLength { get; set; }
        public KeyType Type { get; private set; }
        private int[] maxKeyPressCount = [-1, -1, -1, -1];
        public int GetMaxKeyPressCount(int index)
        {
            if (maxKeyPressCount[index] != -1) return maxKeyPressCount[index];
            if (KeyPressCount == null) return -1;
            maxKeyPressCount[index] = KeyPressCount[index].Max();
            return maxKeyPressCount[index];
        }

        public KeyStats(KeyType keyType)
        {
            Type = keyType;
            KeyPressCount = [[], [], [], []];
            QuickKeyPressCount = [0, 0, 0];
            AverageKeyLength = 0d;
        }
    }

    public class FullKeyStats
    {
        public KeyStats KeyboardKey { get; set; }
        public KeyStats ControllerKey { get; set; }
        public int TotalFrames { get; set; }
    }

    public enum KeyType
    {
        Keyboard,
        Controller
    }
}
