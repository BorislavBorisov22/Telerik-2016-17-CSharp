using System;
using System.Xml;

namespace DeleteAllAlbumsWithPriceAbove20WithDom
{
    public class StartUp
    {
        public static void Main()
        {
            var document = new XmlDocument();
            document.Load(@"..\..\..\catalog.xml");
            var root = document.DocumentElement;

            decimal maxAlbumPrice = 20;
            DeleteAlbumsAbovePrice(root, maxAlbumPrice, document);
            Console.WriteLine($"Albums with price more than {maxAlbumPrice} were deleted");
        }

        private static void DeleteAlbumsAbovePrice(XmlElement root, decimal maxPrice, XmlDocument document)
        {
            string priceKey = "price";
           
            for (int i = 0; i < root.ChildNodes.Count; i++)
            {
                var currentPrice = decimal.Parse(root.ChildNodes[i][priceKey].InnerXml);
                
                if (currentPrice > maxPrice)
                {
                    root.RemoveChild(root.ChildNodes[i]);
                    i -= 1;
                }
            }

            document.Save(@"..\..\ItemsAbove20PriceDeleted.xml");
        }
    }
}
