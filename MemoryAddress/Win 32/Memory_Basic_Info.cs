using System;

namespace MemoryAddress.Win32
{
    /// <summary>
    /// Contains information about a range of pages in the virtual address space of a process. The VirtualQuery and VirtualQueryEx functions use this structure.
    /// </summary>
    /// <remarks>Documentation: https://docs.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-memory_basic_information </remarks>
    public struct Memory_Basic_Info
    {
        /// <summary>
        /// A pointer to the base address of the region of pages.
        /// </summary>
        public UIntPtr BaseAddress;

        /// <summary>
        /// The memory protection option when the region was initially allocated. This member can be one of the memory protection constants or 0 if the caller does not have access.
        /// </summary>
        public UIntPtr AllocationBase;

        /// <summary>
        /// The memory protection option when the region was initially allocated.
        /// </summary>
        public MemoryProtection AllocationProtect;

        /// <summary>
        /// The size of the region beginning at the base address in which all pages have identical attributes, in bytes.
        /// </summary>
        public long RegionSize;

        /// <summary>
        /// The state of the pages in the region. This member must be one of the following values:<br/>
        /// • <see cref="MemoryAllocateType.Commit"/><br/>
        /// • <see cref="MemoryAllocateType.Reserve"/><br/>
        /// • <see cref="MemoryAllocateType.Free"/><br/>
        /// </summary>
        public MemoryAllocateType State;

        /// <summary>
        /// The access protection of the pages in the region
        /// </summary>
        public MemoryProtection Protect;

        /// <summary>
        /// The type of pages in the region
        /// </summary>
        public PageType Type;
    }
}
