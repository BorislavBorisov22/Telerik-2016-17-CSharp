namespace CohesionAndCoupling.Files
{
    public class FileNameManager
    {
        public static string GetFileExtension(string fileName)
        {
            FileNameManager.ValidateFileName(fileName);

            int indexOfLastDot = fileName.LastIndexOf(".");

            if (indexOfLastDot == -1)
            {
                return string.Empty;
            }

            string extension = fileName.Substring(indexOfLastDot + 1);
            return extension;
        }

        public static string GetFileNameWithoutExtension(string fileName)
        {
            FileNameManager.ValidateFileName(fileName);

            int indexOfLastDot = fileName.LastIndexOf(".");

            if (indexOfLastDot == -1)
            {
                return fileName;
            }

            string extension = fileName.Substring(0, indexOfLastDot);
            return extension;
        }

        private static void ValidateFileName(string fileName)
        {
            Validator.ValidateNullOrEmptyString(fileName, "Filename cannot be null or me");
        }
    }
}
