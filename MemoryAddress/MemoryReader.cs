using MemoryAddress.Win32;
using System;

namespace MemoryAddress
{
    /// <summary>
    /// High performance class for memory reading.
    /// </summary>
    /// <remarks>Not meant to be instantiated. Meant to be managed by a MemoryAddress</remarks>
    internal class MemoryReader<T>
    {
        /// <summary>
        /// The memory address this reader is bound to. Handles all reading for this address
        /// </summary>
        private MemoryAddress<T> memoryAddress;

        /// <summary>
        /// Stores the bytes read when reading memory. This is a class variable to improve performance
        /// </summary>
        private byte[] memoryBytes;

        private UIntPtr readSize;

        /// <summary>
        /// Constructor for MemoryReader. Don't use this. Use MemoryAddress instead
        /// </summary>
        /// <param name="address"></param>
        internal MemoryReader(MemoryAddress<T> address)
        {
            memoryAddress = address;

            int size = (typeof(T) == typeof(string)) ? 32 : ByteUtils.SizeOf<T>();
            memoryBytes = new byte[size];
            readSize = (UIntPtr)size;
        }

        /// <summary>
        /// Reads the value stored at the MemoryAddress connected to this object
        /// </summary>
        /// <param name="result">The value stored in memory</param>
        /// <returns></returns>
        public virtual bool Read(out T result)
        {
            bool success = Kernel32.ReadProcessMemory(memoryAddress.Address, memoryBytes, readSize);
            result = memoryBytes.FromBytes<T>();
            return success;
        }

        /// <summary>
        /// Read the value stored in memory
        /// </summary>
        /// <returns></returns>
        public virtual T Read()
        {
            Kernel32.ReadProcessMemory(memoryAddress.Address, memoryBytes, readSize);
            return memoryBytes.FromBytes<T>();
        }
    }
}
