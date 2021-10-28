using System;

namespace MemoryAddress.Win32
{
    /// <summary>
    /// The type of memory allocation for <see cref="Kernel32.VirtualAllocEx(IntPtr, IntPtr, uint, MemoryAllocateType, MemoryProtection)"/>
    /// </summary>
    /// <remarks>Documentation: https://docs.microsoft.com/en-us/windows/win32/api/memoryapi/nf-memoryapi-virtualallocex </remarks>
    [Flags]
    public enum MemoryAllocateType : uint
    {
        /// <summary>
        /// Allocates memory charges (from the overall size of memory and the paging files on disk) for the specified reserved memory pages
        /// </summary>
        Commit = 0x00001000,

        /// <summary>
        /// Reserves a range of the process's virtual address space without allocating any actual physical storage in memory or in the paging file on disk. 
        /// </summary>
        Reserve = 0x00002000,

        /// <summary>
        /// The value of a free location in memory
        /// </summary>
        Free = 0x00010000,

        /// <summary>
        /// Indicates that data in the memory range specified by lpAddress and dwSize is no longer of interest. The pages should not be read from or written to the paging file. However, the memory block will be used again later, so it should not be decommitted. This value cannot be used with any other value. 
        /// </summary>
        Reset = 0x00080000,

        /// <summary>
        /// should only be called on an address range to which MEM_RESET was successfully applied earlier. It indicates that the data in the specified memory range specified by lpAddress and dwSize is of interest to the caller and attempts to reverse the effects of MEM_RESET.
        /// </summary>
        ResetUndo = 0x10000000,

        /// <summary>
        /// Allocates memory using large page support. The size and alignment must be a multiple of the large-page minimum
        /// </summary>
        /// <remarks>More info here: https://docs.microsoft.com/en-us/windows/win32/api/memoryapi/nf-memoryapi-getlargepageminimum </remarks>
        LargePages = 0x20000000,

        /// <summary>
        /// Reserves an address range that can be used to map Address Windowing Extensions (AWE) pages.
        /// </summary>
        Physical = 0x00400000,

        /// <summary>
        /// Allocates memory at the highest possible address. This can be slower than regular allocations, especially when there are many allocations. 
        /// </summary>
        TopDown = 0x00100000
    }
}
