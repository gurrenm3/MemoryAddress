using System;

namespace MemoryAddress.Win32
{
    /// <summary>
    /// Flags that control the creation of remote threads
    /// </summary>
    /// <remarks>Documentation: https://docs.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-createremotethread </remarks>
    [Flags]
    public enum RemoteThreadCreationFlags : uint
    {
        /// <summary>
        /// The thread runs immediately after creation. 
        /// </summary>
        None = 0,

        /// <summary>
        /// The thread is created in a suspended state, and does not run until the ResumeThread function is called. 
        /// </summary>
        Create_Suspend = 0x00000004,

        /// <summary>
        /// The dwStackSize parameter specifies the initial reserve size of the stack. If this flag is not specified, dwStackSize specifies the commit size. 
        /// </summary>
        Stack_Size_Param_Is_A_Reservation = 0x00010000
    }
}
