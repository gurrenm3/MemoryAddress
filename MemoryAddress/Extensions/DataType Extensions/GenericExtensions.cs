using System;
using System.Text;

namespace MemoryAddress
{
    /// <summary>
    /// Extension methods for datatypes, uses generics
    /// </summary>
    public static class GenericExtensions
    {
        /// <summary>
        /// Convert an object from one type to another. Useful for generics
        /// </summary>
        /// <typeparam name="TFrom"></typeparam>
        /// <typeparam name="TNew"></typeparam>
        /// <param name="self"></param>
        /// <returns></returns>
        public static TNew ChangeType<TFrom, TNew>(this TFrom self)
        {
            try
            {
                return (TNew)Convert.ChangeType(self, typeof(TNew));
            }
            catch (Exception ex)
            {
                throw;
                //return default;
            }
        }

        /// <summary>
        /// Convert this object to bytes for memory modding
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static byte[] ToBytes<T>(this T obj)
        {
            var type = typeof(T);
            if (type == typeof(bool) || type == typeof(byte)) return BitConverter.GetBytes(Convert.ToByte(obj));
            if (type == typeof(char)) return BitConverter.GetBytes(Convert.ToChar(obj));
            if (type == typeof(Int16)) return BitConverter.GetBytes(Convert.ToInt16(obj));
            if (type == typeof(Int32)) return BitConverter.GetBytes(Convert.ToInt32(obj));
            if (type == typeof(Int64)) return BitConverter.GetBytes(Convert.ToInt64(obj));
            if (type == typeof(Single)) return BitConverter.GetBytes(Convert.ToSingle(obj));
            if (type == typeof(Double)) return BitConverter.GetBytes(Convert.ToDouble(obj));
            if (type == typeof(String)) return Encoding.UTF8.GetBytes(obj.ChangeType<T, string>());

            // if we get down here we failed to convert the object
            return null;
        }
    }
}
