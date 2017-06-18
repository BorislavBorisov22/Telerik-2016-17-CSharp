using System.Xml;

namespace _07.ExtractAndWriteAlbums
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string catalogPath = "../../../catalog.xml";
            string otputPath = "../../album.xml";

            using (var writer = XmlWriter.Create(otputPath))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("albums");
                using (var reader = XmlReader.Create(catalogPath))
                {
                    Album album;
                    while (true)
                    {
                        album = ReadNextAlbum(reader);

                        if(album == null)
                        {
                            break;
                        }

                        WriteNextAlbum(writer, album);
                    }
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        private static Album ReadNextAlbum(XmlReader node)
        {
            bool isArtistRead = false;
            bool isNameRead = false;

            var album = new Album();

            while ((!isArtistRead || !isNameRead) && node.Read())
            {
                if (node.IsStartElement() && node.Name == "artist")
                {
                    node.Read();
                    album.Artist = node.Value;
                    isArtistRead = true;
                }

                if (node.IsStartElement() && node.Name == "name")
                {
                    node.Read();
                    album.Name = node.Value;
                    isNameRead = true;
                }
            }

            if (!isNameRead || !isArtistRead)
            {
                return null;
            }

            return album;
        }

        private static void WriteNextAlbum(XmlWriter writer, Album album)
        {
            writer.WriteStartElement("album");
                writer.WriteElementString("name", album.Name);
                writer.WriteElementString("artist", album.Artist);
            writer.WriteEndElement();
        }
    }
}
