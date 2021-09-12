using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace MemoryAddress
{
    public static class ByteUtils
    {
        //taken from https://stackoverflow.com/questions/39005931/generic-method-using-bitconverter-getbytes#39006109
        static readonly Dictionary<long, int> SizeOfDict = new Dictionary<long, int>();
        /// <summary>
        /// Get the size of a type. Used for calculating the size of a Byte array
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static int SizeOf<T>()
        {
            var type = typeof(T);

            if (type == typeof(string)) return 32; // returning default value of 32

            // --- Highspeed Compiler-Hack ---
            if (type == typeof(byte)) return sizeof(byte);
            if (type == typeof(sbyte)) return sizeof(sbyte);
            if (type == typeof(ushort)) return sizeof(ushort);
            if (type == typeof(short)) return sizeof(short);
            if (type == typeof(uint)) return sizeof(uint);
            if (type == typeof(int)) return sizeof(int);
            if (type == typeof(ulong)) return sizeof(ulong);
            if (type == typeof(long)) return sizeof(long);
            if (type == typeof(float)) return sizeof(float);
            if (type == typeof(double)) return sizeof(double);
            // --- fix wrong sizes ---
            if (type == typeof(char)) return sizeof(char);
            if (type == typeof(bool)) return sizeof(bool);

            long id = (long)typeof(T).TypeHandle.Value;
            int len;
            if (!SizeOfDict.TryGetValue(id, out len))
            {
                len = Marshal.SizeOf(type);
                SizeOfDict.Add(id, len);
            }
            return len;
        }
    }
}
