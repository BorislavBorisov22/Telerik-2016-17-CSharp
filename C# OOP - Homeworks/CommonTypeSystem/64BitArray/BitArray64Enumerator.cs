namespace _64BitArray
{
    using System.Collections;
    using System.Collections.Generic;

    public class BitArray64Enumerator : IEnumerator<ulong>
    {
        private ulong[] bits;
        private int index;

        public BitArray64Enumerator(ulong[] bits)
        {
            this.bits = bits;
            this.index = -1;
        }

        public ulong Current
        {
            get
            {
                return this.bits[this.index];
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return this.Current;
            }
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (this.index >= this.bits.Length - 1)
            {
                return false;
            }

            this.index++;
            return true;
        }

        public void Reset()
        {
            this.index = 0;
        }
    }
}
