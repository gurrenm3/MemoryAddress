using MemoryAddress.Win32;
using System;

namespace MemoryAddress
{
    /// <summary>
    /// Custom class for memory scanning. About 3x better performance than the leading
    /// libraries
    /// </summary>
    public class MemoryAddress<T> : IDisposable
    {
        #region Properties

        /// <summary>
        /// A name for this address. Not necessary but can help with identification
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The pointer of the address
        /// </summary>
        public UIntPtr Address { get; protected set; }

        /// <summary>
        /// Handles reading the value of this address
        /// </summary>
        private MemoryReader<T> reader;

        /// <summary>
        /// Handles writing values to this address
        /// </summary>
        private MemoryWriter<T> writer;

        private bool initialized = false;
        private bool disposed = false;
        private MemoryProtection originalProtection;

        #endregion


        #region Constructors

        public MemoryAddress(UIntPtr addressPointer, string hookToRunOnChange = "")
        {
            Address = addressPointer;
            Init();
        }

        public MemoryAddress(long addressPointer, string hookToRunOnChange = "")
        {
            Address = (UIntPtr)addressPointer;
            Init();
        }
        #endregion

        /// <summary>
        /// Initialize this memory address.
        /// </summary>
        protected virtual void Init()
        {
            if (ThrowIfAddressBad(Address))
                return;

            writer = new MemoryWriter<T>(this);
            reader = new MemoryReader<T>(this);
            RemoveAddressProtection();
            initialized = true;
        }

        /// <summary>
        /// Write a value to this address
        /// </summary>
        /// <param name="valueToWrite">The value to write to the address</param>
        /// <returns>True if the value was successfully written. False if it failed</returns>
        public virtual bool Write(T valueToWrite)
        {
            if (ThrowIfAddressBad(Address))
                return false;

            return writer.Write(valueToWrite);
        }

        /// <summary>
        /// Read the value currently stored at this address
        /// </summary>
        /// <returns>The value that was read from the address. If it failed to read, this will be the default value of T</returns>
        public virtual T Read()
        {
            if (ThrowIfAddressBad(Address))
                return default;

            return reader.Read();
        }

        /// <summary>
        /// Read the value currently stored at this address
        /// </summary>
        /// <param name="readValue">The value that was read from the address. If it failed to read, this will be the default value of T</param>
        /// <returns>True if the value was successfully written. False if it failed</returns>
        public virtual bool Read(out T readValue)
        {
            if (ThrowIfAddressBad(Address))
            {
                readValue = default;
                return false;
            }

            return reader.Read(out readValue);
        }

        /// <summary>
        /// Removes the protection level of the address. Allows for significantly faster reading and writing
        /// </summary>
        /// <returns></returns>
        protected virtual bool RemoveAddressProtection()
        {
            return ChangeProtection(MemoryAddressController.AttachedProcHandle, Address,
                MemoryProtection.ExecuteReadWrite, out originalProtection);
        }

        /// <summary>
        /// Change the protection level of an address. Required for faster memory modding
        /// </summary>
        /// <param name="processHandle"></param>
        /// <param name="address"></param>
        /// <param name="newProtection"></param>
        /// <param name="oldProtection"></param>
        /// <returns></returns>
        public virtual bool ChangeProtection(IntPtr processHandle, UIntPtr address, MemoryProtection newProtection, out MemoryProtection oldProtection)
        {
            return Kernel32.VirtualProtectEx(processHandle, address, (IntPtr)(8), newProtection, out oldProtection);
        }

        /// <summary>
        /// Throw an error if the address was bad
        /// </summary>
        /// <returns></returns>
        public virtual bool ThrowIfAddressBad(UIntPtr address)
        {
            if (address != UIntPtr.Zero)
                return false;

            throw new Exception("Failed to write value because the address is invalid");
        }

        public override string ToString()
        {
            return Read().ToString();
        }

        #region Dispose

        /// <summary>
        /// Deconstructor for the class. Resets MemoryProtection to original value
        /// </summary>
        ~MemoryAddress()
        {
            Dispose(false);
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Resets MemoryProtection when disposed
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Manual release of managed resources.
            }

            if (!initialized)
                return;

            // Release unmanaged resources.
            ChangeProtection(MemoryAddressController.AttachedProcHandle, Address, originalProtection, out var old);

            disposed = true;
        }

        #endregion
    }
}
