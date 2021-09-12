using System;
using System.Text;

namespace MemoryAddress
{
    /// <summary>
    /// Extension methods for the String datatype
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Returns the Hex Code equivalent of this string
        /// </summary>
        /// <param name="str"></param>
        /// <param name="include_0x">should "0x" be included at the front of returned value?</param>
        /// <returns></returns>
        public static string ToHexCode(this string str, bool include_0x = true)
        {
            if (str.StartsWith("0x"))
                str = str.Replace("0x", "");

            byte[] bytes = Encoding.UTF8.GetBytes(str);

            string hex = Convert.ToHexString(bytes);
            if (include_0x)
                hex = "0x" + hex;

            return hex;
        }

        /// <summary>
        /// Return if the Hex Value of this number is equal to another Hex Value
        /// </summary>
        /// <param name="str"></param>
        /// <param name="equalToHex">Hex Value that we're comparing to</param>
        /// <returns></returns>
        public static bool IsHexEqualTo(this int str, string equalToHex)
        {
            return str.ToHexCode(false) == equalToHex;
        }
    }
}
