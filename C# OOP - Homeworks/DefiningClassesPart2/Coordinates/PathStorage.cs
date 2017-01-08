namespace Coordinates
{
    using System;
    using System.IO;
    using System.Linq;

    public static class PathStorage
    {
        public static void SavePath(Path path, string directory)
        {
            using (StreamWriter file = new StreamWriter(directory))
            {
                foreach (var point in path.Points)
                {
                    file.WriteLine(point.ToString());
                }
            }
        }

        public static Path LoadPath(string directory)
        {
            var path = new Path();
            using (var reader = new StreamReader(directory))
            {
                string currentLine = reader.ReadLine();
                while (currentLine != null)
                {
                    var currentPointArgs = currentLine
                        .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(double.Parse).ToArray();

                    var currentPoint = new Point3D(currentPointArgs[0], currentPointArgs[1], currentPointArgs[2]);

                    path.AddPoint(currentPoint);
                    currentLine = reader.ReadLine();
                }
            }

            return path;
        }
    }
}
