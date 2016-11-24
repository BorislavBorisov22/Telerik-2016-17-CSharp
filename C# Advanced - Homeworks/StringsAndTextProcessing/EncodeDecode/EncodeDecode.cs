using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class EncodeDecode
{
    public static string EncodeMessage(string text,string encryptionKey)
    {
        var result = new List<string>();


        for (int i = 0, j = 0;i < text.Length; i++, j++)
        {
            if (j == encryptionKey.Length)
            {
                j = 0;
            }
            int currSymbolTextValue = (int)text[i];
            int currSymbolKeyValue = (int)encryptionKey[j];

            int encryptionValue = currSymbolKeyValue ^ currSymbolTextValue;
            result.Add(encryptionValue.ToString());
        }


        return string.Join(" ",result);
    }

    public static string DecodeMessage(string text,string key)
    {
        List<string> message = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToList();
        var decryptedMessage = new StringBuilder();

        for (int i = 0,j= 0; i < message.Count; i++, j++)
        {
            if (j == key.Length)
            {
                j = 0;
            }
            int messageSymbolValue = int.Parse(message[i]);
            int keySymbolValue = (int)key[j];

            char decryptedSymbol = (char)(messageSymbolValue ^ keySymbolValue);
            decryptedMessage.Append(decryptedSymbol);
        }


        return decryptedMessage.ToString();
    }
    static void Main()
    {
        string encodingKey = Console.ReadLine();
        string textToEncode = Console.ReadLine();
        string encryptedMessage = EncodeMessage(textToEncode, encodingKey);
        Console.WriteLine(encryptedMessage);
        string decryptedMessage = DecodeMessage(encryptedMessage, encodingKey);

        Console.WriteLine(decryptedMessage);
    }
}

