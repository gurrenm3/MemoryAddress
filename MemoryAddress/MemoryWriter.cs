using MemoryAddress.Win32;
using System;

namespace MemoryAddress
{
    /// <summary>
    /// High performance class for memory writing.
    /// </summary>.
    /// <remarks>Not meant to be instantiated. Meant to be managed by a MemoryAddress</remarks>
    internal class MemoryWriter<T>
    {
        /// <summary>
        /// The memory address this reader is bound to. Handles all reading for this address
        /// </summary>
        private MemoryAddress<T> memoryAddress;

        private UIntPtr writeSize;

        /// <summary>
        /// Constructor for MemoryWriter. Don't use this. Use MemoryAddress instead
        /// </summary>
        /// <param name="address"></param>
        internal MemoryWriter(MemoryAddress<T> address)
        {
            memoryAddress = address;
            writeSize = (UIntPtr)ByteUtils.SizeOf<T>();
        }

        /// <summary>
        /// Write a value to the MemoryAddress connected to this object
        /// </summary>
        /// <param name="valueToWrite">The value to write to memory</param>
        /// <returns></returns>
        public virtual bool Write(T valueToWrite)
        {
            var bytes = valueToWrite.ToBytes();
            if (bytes is null || bytes.Length == 0)
                return false;

            return Kernel32.WriteProcessMemory(memoryAddress.Address, bytes, writeSize);
        }
    }
}
