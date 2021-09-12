using MemoryAddress.Win32;
using System.Diagnostics;

namespace MemoryAddress
{
    /// <summary>
    /// Extension methods for System.Diagnostics.Process
    /// </summary>
    public static class ProcessExtensions
    {
        /// <summary>
        /// Returns whether or not this is a 32bit Process
        /// </summary>
        /// <param name="process"></param>
        /// <returns></returns>
        public static bool Is32Bit(this Process process)
        {
            Kernel32.IsWow64Process(process.Handle, out bool is32Bit);
            return is32Bit;
        }
    }
}
