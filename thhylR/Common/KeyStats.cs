using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace thhylR.Common
{
    public class KeyStats
    {
        public List<int> KeyPressCount { get; set; }
        public List<List<int>> KeyCounts { get; set; }
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

        public List<int> KeyPress1FCount
        {
            get
            {
                return KeyCounts[0];
            }
        }

        public List<int> KeyPress2FCount
        {
            get
            {
                return KeyCounts[1];
            }
        }

        public List<int> KeyPress3FCount
        {
            get
            {
                return KeyCounts[2];
            }
        }

        public KeyStats()
        {
            KeyPressCount = new List<int>();
            KeyCounts = new List<List<int>>() { new(), new(), new() };
            AverageKeyLength = 0d;
        }
    }

    public class FullKeyStats
    {
        public KeyStats KeyboardKey { get; set; }
        public KeyStats ControllerKey { get; set; }
        public int TotalFrames { get; set; }
        public bool HasConflictKeys { get; set; }
    }
}
