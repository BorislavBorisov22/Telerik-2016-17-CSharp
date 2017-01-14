namespace _64BitArray
{
    using System;
    using System.Collections;

    public class StartUp
    {
        public static void Main()
        {
            var bitArr = new BitArray64(5);
            var anotherBitArr = new BitArray64(5);

            // printing first bit array to check if the ToString() method works correctly
            Console.WriteLine(bitArr);
            Console.WriteLine("-----------");

            // testing the two operators for comaprison == and != for both result cases
            // when the two arrays are equal and when they are not
            Console.WriteLine(bitArr == anotherBitArr);
            Console.WriteLine(bitArr != anotherBitArr);
            anotherBitArr[1] = 1;

            // changing the bit at first position of one of the bit array and comparing the again
            Console.WriteLine(bitArr == anotherBitArr);
            Console.WriteLine(bitArr != anotherBitArr);

            // checking the GetHashCode() method 
            Console.WriteLine(bitArr.GetHashCode());
            Console.WriteLine(anotherBitArr.GetHashCode());

            Console.WriteLine("First bit array decimal value: {0}",bitArr.BitsValue);
            Console.WriteLine("Second bit array decimal value: {0}",anotherBitArr.BitsValue);

            // setting all bits from 31 to 40 to 1 and then
            // printing every bit from the first bit array using foreach
            
            for (int i=31; i <= 40; i++)
            {
                bitArr[i] = 1;
            }

            int counter = 63;

            foreach (var bit in bitArr)
            {
                Console.WriteLine("Bit position: {0} -> Bit value: {1}",counter,bit);
                counter--;
            }
           

            
        }
    }
}
