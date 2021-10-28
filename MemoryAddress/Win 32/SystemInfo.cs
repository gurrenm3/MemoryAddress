using System;

namespace MemoryAddress.Win32
{
    //Taken from https://github.com/erfg12/memory.dll/blob/master/Memory/memory.cs
    /// <summary>
    /// Contains information about the current computer system. This includes the architecture and type of the processor, the number of processors in the system, the page size, and other such information.
    /// </summary>
    /// <remarks>Documentation: https://docs.microsoft.com/en-us/windows/win32/api/sysinfoapi/ns-sysinfoapi-system_info </remarks>
    public struct SystemInfo
    {
        /// <summary>
        /// The processor architecture of the installed operating system. This member can be one of the following values:<br/>
        /// • PROCESSOR_ARCHITECTURE_AMD64 = 9<br/>
        /// • PROCESSOR_ARCHITECTURE_ARM = 5<br/>
        /// • PROCESSOR_ARCHITECTURE_ARM64 = 12<br/>
        /// • PROCESSOR_ARCHITECTURE_IA64 = 6<br/>
        /// • PROCESSOR_ARCHITECTURE_INTEL = 0<br/>
        /// • PROCESSOR_ARCHITECTURE_UNKNOWN = 0xffff<br/>
        /// </summary>
        public ushort processorArchitecture;

        /// <summary>
        /// The page size and the granularity of page protection and commitment. This is the page size used by the VirtualAlloc function.
        /// </summary>
        public uint pageSize;

        /// <summary>
        /// A pointer to the lowest memory address accessible to applications and dynamic-link libraries (DLLs).
        /// </summary>
        public UIntPtr minimumApplicationAddress;

        /// <summary>
        /// A pointer to the highest memory address accessible to applications and DLLs.
        /// </summary>
        public UIntPtr maximumApplicationAddress;

        /// <summary>
        /// A mask representing the set of processors configured into the system. Bit 0 is processor 0; bit 31 is processor 31.
        /// </summary>
        public IntPtr activeProcessorMask;

        /// <summary>
        /// The number of logical processors in the current group. To retrieve this value, use the GetLogicalProcessorInformation function.
        /// </summary>
        public uint numberOfProcessors;

        /// <summary>
        /// An obsolete member that is retained for compatibility. Use the wProcessorArchitecture, wProcessorLevel, and wProcessorRevision members to determine the type of processor.
        /// </summary>
        public uint processorType;

        /// <summary>
        /// The granularity for the starting address at which virtual memory can be allocated. For more information, see <see cref="Kernel32.VirtualAllocEx(IntPtr, IntPtr, uint, MemoryAllocateType, MemoryProtection)"/>
        /// </summary>
        public uint allocationGranularity;

        /// <summary>
        /// The architecture-dependent processor level. It should be used only for display purposes. To determine the feature set of a processor, use the IsProcessorFeaturePresent function.
        /// </summary>
        public ushort processorLevel;

        /// <summary>
        /// The architecture-dependent processor revision. The following table shows how the revision value is assembled for each type of processor architecture.
        /// </summary>
        public ushort processorRevision;

        ushort reserved;
    }
}
