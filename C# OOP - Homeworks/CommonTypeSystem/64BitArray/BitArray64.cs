namespace _64BitArray
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class BitArray64 : IEnumerable<ulong>
    {
        public const int Length = 64;

        private ulong[] bits;

        public BitArray64(ulong value = 0)
        {
            this.bits = new ulong[Length];
            this.FillBits(value);
        }

        public ulong BitsValue
        {
            get
            {
                ulong decimalValue = 0;
                for (int i = 0; i < Length; i++)
                {
                    decimalValue = (decimalValue * 2) + this.bits[i];
                }

                return decimalValue;
            }
        }

        public ulong this[int index]
        {
            get
            {
                this.ValidateIndex(index);
                return this.bits[Length - 1 - index];
            }

            set
            {
                this.ValidateIndex(index);
                this.ValidateBit(value);
                this.bits[Length - 1 - index] = value;
            }
        }

        public static bool operator ==(BitArray64 first, BitArray64 second)
        {
            return BitArray64.Equals(first, second);
        }

        public static bool operator !=(BitArray64 first, BitArray64 second)
        {
            return !BitArray64.Equals(first, second);
        }

        public override string ToString()
        {
            return string.Join(" ", this.bits);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var objAsBitArray64 = obj as BitArray64;

            return this.BitsValue == objAsBitArray64.BitsValue;
        }

        public override int GetHashCode()
        {
            return this.bits.GetHashCode();
        }

        public IEnumerator<ulong> GetEnumerator()
        {
            for (int i = 0; i < this.bits.Length; i++)
            {
                yield return this.bits[i];
            }

            // return new BitArray64Enumerator(this.bits);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void FillBits(ulong value)
        {
            for (int i = 0; i < Length; i++)
            {
                ulong currentBit = (value >> (63 - i)) & 1;
                this.bits[i] = currentBit;
            }
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.bits.Length)
            {
                throw new IndexOutOfRangeException("Index was outside the boundaries of the array");
            }
        }

        private void ValidateBit(ulong bit)
        {
            if (bit != 1 && bit != 0)
            {
                throw new ArgumentException("Invalid bit value! Bits of the array can only be 1 or 0");
            }
        }
    }
}
