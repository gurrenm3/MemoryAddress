namespace MemoryAddress
{
    /// <summary>
    /// Extension methods for the "long" datatype
    /// </summary>
    public static class LongExtensions
    {
        /// <summary>
        /// Returns the Hex Code equivalent of this number
        /// </summary>
        /// <param name="number"></param>
        /// <param name="include_0x">should "0x" be included at the front of returned value?</param>
        /// <returns></returns>
        public static string ToHexCode(this long number, bool include_0x = true)
        {
            string hex = number.ToString("X");
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
        public static bool IsHexEqualTo(this long number, string equalToHex)
        {
            return number.ToHexCode(false) == equalToHex;
        }
    }
}
