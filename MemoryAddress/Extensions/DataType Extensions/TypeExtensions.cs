using System;

namespace MemoryAddress
{
    /// <summary>
    /// Extension methods for System.Type
    /// </summary>
    public static class TypeExtensions
    {
        /// <summary>
        /// Returns whether or not this type is one that can have a decimal point. Ex: float, double, decimal
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool IsDecimalType(this Type t)
        {
            return (t == typeof(double) || t == typeof(float) || t == typeof(decimal));
        }
    }
}
