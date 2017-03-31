namespace ToStringConvertions
{
    using System;

    public class ToStringConverter
    {
        public void ConvertBoolToString(bool valueToConvert)
        {
            string valueAsString = valueToConvert.ToString();
            Console.WriteLine(valueAsString);
        }
    }
}
