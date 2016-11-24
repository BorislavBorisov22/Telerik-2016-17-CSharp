using System;
using System.Text;
using System.Text.RegularExpressions;

class ParseURL
{
    static string protocol = string.Empty;
    static string server = string.Empty;
    static string resource = string.Empty;
    static string input;


    public static void URLParse()
    {
        if (!input.Contains(":") && !input.Contains("/") && !input.Contains("//"))
        {
            server = input;
            return;
        }
        else if (!input.Contains(":"))
        {
            int indexResource = input.IndexOf("/");
            server = input.Substring(0, indexResource);
            resource = input.Substring(indexResource);

        }
        else
        {
            int indexProtocol = input.IndexOf(":");
            int indexServer = input.IndexOf("//");
            int indexResource = input.IndexOf("/", indexServer + 2);
            if (indexResource < 0)
            {
                protocol = input.Substring(0, indexProtocol);
                server = input.Substring(indexServer+2);
            }
            else
            {
                protocol = input.Substring(0, indexProtocol);
                server = input.Substring(indexServer + 2, indexResource - indexServer - 2);
                resource = input.Substring(indexResource);
            }
        }




    }
    static void Main()
    {
        input = Console.ReadLine();
        URLParse();
        Console.WriteLine("[protocol] = {0}", protocol);
        Console.WriteLine("[server] = {0}", server);
        Console.WriteLine("[resource] = {0}", resource);

    }


}

