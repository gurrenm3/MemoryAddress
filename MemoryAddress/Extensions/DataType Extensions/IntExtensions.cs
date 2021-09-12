using System;

namespace MemoryAddress
{
    /// <summary>
    /// Extension methods for the Int datatype
    /// </summary>
    public static class IntExtensions
    {
        /// <summary>
        /// Returns the Hex Code equivalent of this number
        /// </summary>
        /// <param name="number"></param>
        /// <param name="include_0x">should "0x" be included at the front of returned value?</param>
        /// <returns></returns>
        public static string ToHexCode(this int number, bool include_0x = true)
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
        public static bool IsHexEqualTo(this int number, string equalToHex)
        {
            return number.ToHexCode(false) == equalToHex;
        }

        /// <summary>
        /// Returns the value of this number after being converted to Int16. Returns -1 if failed;
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static Int16 ToInt16(this int number)
        {
            try { return Convert.ToInt16(number); }
            catch (Exception) { return -1; }
        }

        /// <summary>
        /// Returns the value of this number after being converted to Int64. Returns -1 if failed;
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static Int64 ToInt64(this int number)
        {
            try { return Convert.ToInt64(number); }
            catch (Exception) { return -1; }
        }

        /// <summary>
        /// Returns the value of this number after being converted to Int32. Returns -1 if failed;
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static Int32 ToInt32(this Int16 number)
        {
            try { return Convert.ToInt32(number); }
            catch (Exception) { return -1; }
        }

        /// <summary>
        /// Returns the value of this number after being converted to Int64. Returns -1 if failed;
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static Int64 ToInt64(this Int16 number)
        {
            try { return Convert.ToInt64(number); }
            catch (Exception) { return -1; }
        }

        /// <summary>
        /// Returns the value of this number after being converted to Int16. Returns -1 if failed;
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static Int16 ToInt16(this Int64 number)
        {
            try { return Convert.ToInt16(number); }
            catch (Exception) { return -1; }
        }

        /// <summary>
        /// Returns the value of this number after being converted to Int32. Returns -1 if failed;
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static Int32 ToInt32(this Int64 number)
        {
            try { return Convert.ToInt32(number); }
            catch (Exception) { return -1; }
        }
    }
}
