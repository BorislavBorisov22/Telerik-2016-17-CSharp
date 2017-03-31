namespace ToStringConvertions
{
    public class StartUp
    {
        private const int MaxCount = 6;

        public static void Main()
        {
            var toStringConverter = new ToStringConverter();
            toStringConverter.ConvertBoolToString(true);
        }
    }
}
