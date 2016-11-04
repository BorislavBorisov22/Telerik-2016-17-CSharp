using System;



class Batman
{
    static void Main()
    {

        int size = int.Parse(Console.ReadLine());
        char sign = char.Parse(Console.ReadLine());

        int sideSpaces = 0;
        // print top of bat
        for (int i = 0; i < size / 2 - 1; i++)
        {
            Console.WriteLine("{0}{1}{2}{1}{0}",new string(' ',i),new string(sign,size-i),
                new string(' ',size));
            sideSpaces = i;
        }
        sideSpaces++;
        // print ears of bat
        Console.Write(new string(' ',sideSpaces));
        Console.Write(new string(sign,size - sideSpaces));
        Console.Write(new string(' ',(size-3)/2));
        Console.Write("{0} {0}",sign);
        Console.Write(new string(' ', (size - 3) / 2));
        Console.Write(new string(sign, size - sideSpaces));
        Console.WriteLine();
        sideSpaces++;

        // print body of bat
        for (int i = 0; i < size / 3; i++)
        {
            Console.WriteLine("{0}{1}{0}", new string(' ',sideSpaces), new string(sign, size * 2 + 1));

        }
        // print tail of bat
        sideSpaces = size;
        int signCount = size - 2;
        for (int i = 0; i < size / 2; i++)
        {
            Console.WriteLine("{0}{1}{0}",new string(' ',sideSpaces),new string(sign,signCount));
            sideSpaces++;
            signCount -= 2;
        }
    }
}

