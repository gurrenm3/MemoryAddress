using System;

namespace MemoryAddress.Win32
{
    /// <summary>
    /// The type of pages in the region
    /// </summary>
    /// <remarks>Documentation: https://docs.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-memory_basic_information#members </remarks>
    [Flags]
    public enum PageType : uint
    {
        /// <summary>
        /// Indicates that the memory pages within the region are mapped into the view of an image section. 
        /// </summary>
        Mem_Image = 0x1000000,

        /// <summary>
        /// Indicates that the memory pages within the region are mapped into the view of a section. 
        /// </summary>
        Mem_Mapped = 0x40000,

        /// <summary>
        /// Indicates that the memory pages within the region are private (that is, not shared by other processes). 
        /// </summary>
        Mem_Private = 0x20000
    }
}
