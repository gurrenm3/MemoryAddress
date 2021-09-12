using System;

namespace MemoryAddress
{
    /// <summary>
    /// Extension methods for the Float datatype
    /// </summary>
    public static class FloatExtensions
    {
        /// <summary>
        /// Returns the Hex Code equivalent of this number
        /// </summary>
        /// <param name="number"></param>
        /// <param name="include_0x">should "0x" be included at the front of returned value?</param>
        /// <returns></returns>
        public static string ToHexCode(this float number, bool include_0x = true)
        {
            var numToConvert = (int)number.Round();
            string hex = numToConvert.ToString("X");
            if (include_0x)
                hex = "0x" + hex;

            return hex;
        }

        /// <summary>
        /// Return if the Hex Value of this number is equal to another Hex Value
        /// </summary>
        /// <param name="number"></param>
        /// <param name="equalToHex">Hex Value that we're comparing to</param>
        /// <returns></returns>
        public static bool IsHexEqualTo(this float number, string equalToHex)
        {
            return number.ToHexCode(false) == equalToHex;
        }

        /// <summary>
        /// Return a rounded version of this number
        /// </summary>
        /// <param name="number"></param>
        /// <param name="decimals">Number of decimal places to round to. Default is 2</param>
        /// <returns></returns>
        public static float Round(this float number, int decimals = 2)
        {
            return MathF.Round(number, decimals);
        }
    }
}
