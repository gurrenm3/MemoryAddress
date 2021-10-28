using System;

namespace MemoryAddress.Win32
{
    /// <summary>
    /// The following are the memory-protection options; you must specify one of the following values when allocating or protecting a page in memory. Protection attributes cannot be assigned to a portion of a page; they can only be assigned to a whole page.
    /// </summary>
    /// <remarks>Documentation: https://docs.microsoft.com/en-us/windows/win32/memory/memory-protection-constants </remarks>
    [Flags]
    public enum MemoryProtection : uint
    {
        /// <summary>
        /// Enables execute access to the committed region of pages. An attempt to write to the committed region results in an access violation.
        /// </summary>
        Execute = 0x10,

        /// <summary>
        /// Enables execute or read-only access to the committed region of pages. An attempt to write to the committed region results in an access violation.
        /// </summary>
        ExecuteRead = 0x20,

        /// <summary>
        /// Enables execute, read-only, or read/write access to the committed region of pages.
        /// </summary>
        ExecuteReadWrite = 0x40,

        /// <summary>
        /// Enables execute, read-only, or copy-on-write access to a mapped view of a file mapping object. An attempt to write to a committed copy-on-write page results in a private copy of the page being made for the process
        /// </summary>
        ExecuteWriteCopy = 0x80,

        /// <summary>
        /// Disables all access to the committed region of pages. An attempt to read from, write to, or execute the committed region results in an access violation.
        /// </summary>
        NoAccess = 0x01,

        /// <summary>
        /// Enables read-only access to the committed region of pages. An attempt to write to the committed region results in an access violation
        /// </summary>
        ReadOnly = 0x02,

        /// <summary>
        /// Enables read-only or read/write access to the committed region of pages
        /// </summary>
        ReadWrite = 0x04,

        /// <summary>
        /// Enables read-only or copy-on-write access to a mapped view of a file mapping object. An attempt to write to a committed copy-on-write page results in a private copy of the page being made for the process
        /// </summary>
        WriteCopy = 0x08,

        /// <summary>
        /// Pages in the region become guard pages. Any attempt to access a guard page causes the system to raise a STATUS_GUARD_PAGE_VIOLATION exception and turn off the guard page status. Guard pages thus act as a one-time access alarm
        /// </summary>
        GuardModifierflag = 0x100,

        /// <summary>
        /// Sets all pages to be non-cachable. Applications should not use this attribute except when explicitly required for a device.
        /// </summary>
        NoCacheModifierflag = 0x200,

        /// <summary>
        /// Sets all pages to be write-combined. Applications should not use this attribute except when explicitly required for a device. 
        /// </summary>
        WriteCombineModifierflag = 0x400
    }
}
