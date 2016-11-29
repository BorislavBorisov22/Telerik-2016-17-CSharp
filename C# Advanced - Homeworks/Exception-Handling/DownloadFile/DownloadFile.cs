using System;
using System.Net;

class DownloadFile
{
    static void Main()
    {
        

        try
        {
            Console.WriteLine("Enter address you want to download file from");
            string webAdress = Console.ReadLine();
            Console.WriteLine("Enter name for he downloaded file and file format");
            string fileName = Console.ReadLine();

            using (WebClient myWebClient = new WebClient())
            {
                myWebClient.DownloadFile(webAdress, fileName);

            }

            Console.WriteLine("File succesfully downloaded");
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("Addres parameter is null");
        }
        catch (WebException)
        {
            Console.WriteLine("filename is null or empty or the file name does not exist or error happened during downloading");
        }
        catch (NotSupportedException)
        {
            Console.WriteLine("The method has been called simultaneously on multiple threads");
        }

       
    }
}

