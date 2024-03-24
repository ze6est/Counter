using System;

namespace Assets.CodeBase
{
    public class Points
    {
        private const int AddCount = 1;

        private int _count;

        public event Action<int> CountChanged;

        public void Add()
        {
            _count += AddCount;
            CountChanged?.Invoke(_count);
        }
    }
}