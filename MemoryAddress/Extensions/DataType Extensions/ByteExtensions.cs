using System;
using System.Text;

namespace MemoryAddress
{
    /// <summary>
    /// Extension methods for the Byte datatype
    /// </summary>
    public static class ByteExtensions
    {
        /// <summary>
        /// Returns the Hex Code equivalent of this number
        /// </summary>
        /// <param name="b"></param>
        /// <param name="include_0x">should "0x" be included at the front of returned value?</param>
        /// <returns></returns>
        public static string ToHexCode(this byte b, bool include_0x = true)
        {
            if (b < 0 || b > 15)
                return null; // input out of range for Hex value

            var hex = b < 10 ? (char)(b + 48) : (char)(b + 55);
            return hex.ToString();
        }

        /// <summary>
        /// Return if the Hex Value of this number is equal to another Hex Value
        /// </summary>
        /// <param name="number"></param>
        /// <param name="equalToHex">Hex Value that we're comparing to</param>
        /// <returns></returns>
        public static bool IsHexEqualTo(this byte number, string equalToHex)
        {
            return number.ToHexCode(false) == equalToHex;
        }

        /// <summary>
        /// Convert an object from bytes to type T
        /// </summary>
        /// <typeparam name="T">Type to convert bytes to</typeparam>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static T FromBytes<T>(this byte[] bytes)
        {
            var type = typeof(T);
            if (type == typeof(bool)) return BitConverter.ToBoolean(bytes).ChangeType<bool, T>();
            if (type == typeof(byte)) return bytes[0].ChangeType<byte, T>();
            if (type == typeof(char)) return BitConverter.ToChar(bytes).ChangeType<char, T>();
            if (type == typeof(Int16)) return BitConverter.ToInt16(bytes).ChangeType<Int16, T>();
            if (type == typeof(Int32)) return BitConverter.ToInt32(bytes).ChangeType<Int32, T>();
            if (type == typeof(Int64)) return BitConverter.ToInt64(bytes).ChangeType<Int64, T>();
            if (type == typeof(Single)) return BitConverter.ToSingle(bytes).ChangeType<Single, T>();
            if (type == typeof(Double)) return BitConverter.ToDouble(bytes).ChangeType<Double, T>();
            if (type == typeof(String)) return Encoding.UTF8.GetString(bytes).Split('\0')[0].ChangeType<String, T>();

            // if we got here we failed to convert the bytes to object
            
            return default;
        }
    }
}
