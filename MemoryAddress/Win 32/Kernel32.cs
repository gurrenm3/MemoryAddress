using System;
using System.Runtime.InteropServices;

namespace MemoryAddress.Win32
{
    /// <summary>
    /// DLL Imports from Window's api for Kernel32.dll
    /// </summary>
    public static class Kernel32
    {
        /// <summary>
        /// Reserves, commits, or changes the state of a region of memory within the virtual address space of a specified process. The function initializes the memory it allocates to zero.
        /// </summary>
        /// <param name="hProcess">The handle to a process. The function allocates memory within the virtual address space of this process.</param>
        /// <param name="lpAddress">The pointer that specifies a desired starting address for the region of pages that you want to allocate. 
        /// If you are reserving memory, the function rounds this address down to the nearest multiple of the allocation granularity.</param>
        /// <param name="dwSize">The size of the region of memory to allocate, in bytes.</param>
        /// <param name="flAllocationType">The type of memory allocation</param>
        /// <param name="flProtect">The memory protection for the region of pages to be allocated</param>
        /// <returns>If the function succeeds, the return value is the base address of the allocated region of pages. If the function fails, the return value is NULL. To get extended error information, call <see cref="GetLastError"/>.</returns>
        /// <remarks>Documentation: https://docs.microsoft.com/en-us/windows/win32/api/memoryapi/nf-memoryapi-virtualallocex </remarks>
        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        public static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, MemoryAllocateType flAllocationType, MemoryProtection flProtect);


        /// <summary>
        /// Creates a thread that runs in the virtual address space of another process.
        /// </summary>
        /// <param name="hProcess">A handle to the process in which the thread is to be created.</param>
        /// <param name="lpThreadAttributes">A pointer to a SECURITY_ATTRIBUTES structure that specifies a security descriptor for the new thread and determines whether child processes can inherit the returned handle.</param>
        /// <param name="dwStackSize">The initial size of the stack, in bytes. The system rounds this value to the nearest page. If this parameter is 0 (zero), the new thread uses the default size for the executable.</param>
        /// <param name="lpStartAddress">A pointer to the application-defined function of type LPTHREAD_START_ROUTINE to be executed by the thread and represents the starting address of the thread in the remote process. The function must exist in the remote process.</param>
        /// <param name="lpParameter">A pointer to a variable to be passed to the thread function.</param>
        /// <param name="dwCreationFlags">The flags that control the creation of the thread.</param>
        /// <param name="lpThreadId"></param>
        /// <returns>If the function succeeds, the return value is a handle to the new thread. If the function fails, the return value is NULL. To get extended error information, call <see cref="GetLastError"/>.</returns>
        /// <remarks>Documentation: https://docs.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-createremotethread </remarks>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, RemoteThreadCreationFlags dwCreationFlags, IntPtr lpThreadId);


        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern UInt32 WaitForSingleObject(IntPtr hHandle, UInt32 dwMilliseconds);


        /// <summary>
        /// Closes an open object handle.
        /// </summary>
        /// <param name="hObject">A valid handle to an open object.</param>
        /// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error information, call <see cref="GetLastError"/></returns>
        /// <remarks>Documentation: https://docs.microsoft.com/en-us/windows/win32/api/handleapi/nf-handleapi-closehandle </remarks>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool CloseHandle(IntPtr hObject);


        /// <summary>
        /// Retrieves the termination status of the specified thread.
        /// </summary>
        /// <param name="hThread">A handle to the thread. The handle must have the THREAD_QUERY_INFORMATION or THREAD_QUERY_LIMITED_INFORMATION access right</param>
        /// <param name="lpExitCode">A pointer to a variable to receive the thread termination status. For more information, see Remarks on the documentation.</param>
        /// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error information, call <see cref="GetLastError"/></returns>
        /// <remarks>Documentation: https://docs.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-getexitcodethread </remarks>
        [DllImport("kernel32.dll")]
        public static extern bool GetExitCodeThread(IntPtr hThread, out uint lpExitCode);


        /// <summary>
        /// Frees the loaded dynamic-link library (DLL) module and, if necessary, decrements its reference count. When the reference count reaches zero, the module is unloaded from the address space of the calling process and the handle is no longer valid.
        /// </summary>
        /// <param name="hModule">A handle to the loaded library module. The <see cref="LoadLibrary(string)"/>, LoadLibraryEx, <see cref="GetModuleHandle(string)"/>, or GetModuleHandleEx function returns this handle</param>
        /// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error information, call <see cref="GetLastError"/></returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FreeLibrary(IntPtr hModule);


        /// <summary>
        /// Loads the specified module into the address space of the calling process. The specified module may cause other modules to be loaded.
        /// </summary>
        /// <param name="lpFileName">The name of the module. This can be either a library module (a .dll file) or an executable module (an .exe file). The name specified is the file name of the module and is not related to the name stored in the library module itself</param>
        /// <returns>If the function succeeds, the return value is a handle to the module. If the function fails, the return value is NULL. To get extended error information, call <see cref="GetLastError"/></returns>
        /// <remarks>Documentation: https://docs.microsoft.com/en-us/windows/win32/api/libloaderapi/nf-libloaderapi-loadlibrarya </remarks>
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Ansi)]
        public static extern IntPtr LoadLibrary([MarshalAs(UnmanagedType.LPStr)] string lpFileName);


        /// <summary>
        /// Retrieves the address of an exported function or variable from the specified dynamic-link library (DLL).
        /// </summary>
        /// <param name="hModule">A handle to the DLL module that contains the function or variable. The <see cref="LoadLibrary(string)"/>, LoadLibraryEx, LoadPackagedLibrary, or <see cref="GetModuleHandle(string)"/> function returns this handle.</param>
        /// <param name="lpProcName">The function or variable name, or the function's ordinal value. If this parameter is an ordinal value, it must be in the low-order word; the high-order word must be zero.</param>
        /// <returns>If the function succeeds, the return value is the address of the exported function or variable. If the function fails, the return value is NULL. To get extended error information, call <see cref="GetLastError"/></returns>
        /// <remarks>Documentation: https://docs.microsoft.com/en-us/windows/win32/api/libloaderapi/nf-libloaderapi-getprocaddress </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);


        /// <summary>
        /// Retrieves a module handle for the specified module. The module must have been loaded by the calling process.
        /// </summary>
        /// <param name="lpModuleName">The name of the loaded module (either a .dll or .exe file). If the file name extension is omitted, the default library extension .dll is appended</param>
        /// <returns>If the function succeeds, the return value is a handle to the specified module. If the function fails, the return value is NULL. To get extended error information, call <see cref="GetLastError"/></returns>
        /// <remarks>Documentation: https://docs.microsoft.com/en-us/windows/win32/api/libloaderapi/nf-libloaderapi-getmodulehandlea </remarks>
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);


        /// <summary>
        /// Retrieves information about the current system.
        /// </summary>
        /// <param name="lpSystemInfo">A pointer to a SYSTEM_INFO structure that receives the information.</param>
        /// <remarks>Documentation: https://docs.microsoft.com/en-us/windows/win32/api/sysinfoapi/nf-sysinfoapi-getsysteminfo </remarks>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern void GetSystemInfo(out SystemInfo lpSystemInfo);


        /// <summary>
        /// Changes the protection on a region of committed pages in the virtual address space of a specified process.
        /// </summary>
        /// <param name="hProcess">A handle to the process whose memory protection is to be changed. The handle must have the PROCESS_VM_OPERATION access right</param>
        /// <param name="lpAddress">A pointer to the base address of the region of pages whose access protection attributes are to be changed.</param>
        /// <param name="dwSize">The size of the region of memory to free, in bytes.</param>
        /// <param name="flNewProtect">The memory protection option</param>
        /// <param name="lpflOldProtect">A pointer to a variable that receives the previous access protection of the first page in the specified region of pages. If this parameter is NULL or does not point to a valid variable, the function fails.</param>
        /// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error information, call <see cref="GetLastError"/>.</returns>
        /// <remarks>Documentation: https://docs.microsoft.com/en-us/windows/win32/api/memoryapi/nf-memoryapi-virtualprotectex </remarks>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool VirtualProtectEx(IntPtr hProcess, UIntPtr lpAddress,
            IntPtr dwSize, MemoryProtection flNewProtect, out MemoryProtection lpflOldProtect);


        /// <summary>
        /// Determines whether the specified process is running under WOW64 or an Intel64 of x64 processor.
        /// </summary>
        /// <param name="hProcess">A handle to the process. The handle must have the PROCESS_QUERY_INFORMATION or PROCESS_QUERY_LIMITED_INFORMATION access right.</param>
        /// <param name="Wow64Process"></param>
        /// <returns>Returns true if it is 32bit. If the function succeeds, the return value is a nonzero value. If the function fails, the return value is zero. To get extended error information, call <see cref="GetLastError"/>.</returns>
        /// <remarks>Documentation: https://docs.microsoft.com/en-us/windows/win32/api/wow64apiset/nf-wow64apiset-iswow64process </remarks>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool IsWow64Process(IntPtr hProcess, out bool Wow64Process);


        /// <summary>
        /// ReadProcessMemory copies the data in the specified address range from the address space of the specified process into the specified buffer of the current process
        /// </summary>
        /// <param name="hProcess">A handle to the process with memory that is being read. The handle must have PROCESS_VM_READ access to the process.</param>
        /// <param name="lpBaseAddress">A pointer to the base address in the specified process from which to read. Before any data transfer occurs, the system verifies that all data in the base address and memory of the specified size is accessible for read access, and if it is not accessible the function fails.</param>
        /// <param name="lpBuffer">A pointer to a buffer that receives the contents from the address space of the specified process.</param>
        /// <param name="nSize">The number of bytes to be read from the specified process.</param>
        /// <param name="lpNumberOfBytesRead">A pointer to a variable that receives the number of bytes transferred into the specified buffer. If lpNumberOfBytesRead is NULL, the parameter is ignored.</param>
        /// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is 0 (zero). To get extended error information, call <see cref="GetLastError"/></returns>
        /// <remarks>Documentation: https://docs.microsoft.com/en-us/windows/win32/api/memoryapi/nf-memoryapi-readprocessmemory </remarks>
        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(IntPtr hProcess, UIntPtr lpBaseAddress, [Out] byte[] lpBuffer, UIntPtr nSize, IntPtr lpNumberOfBytesRead);


        /// <summary>
        /// ReadProcessMemory copies the data in the specified address range from the address space of the specified process into the specified buffer of the current process.
        /// This overload uses <see cref="MemoryManager.ProcessHandle"/> as for the ProcessHandle to search
        /// </summary>
        /// <param name="address">A pointer to the base address in the specified process from which to read. Before any data transfer occurs, the system verifies that all data in the base address and memory of the specified size is accessible for read access, and if it is not accessible the function fails.</param>
        /// <param name="arrayToStoreBytes">A pointer to a buffer that receives the contents from the address space of the specified process.</param>
        /// <param name="size">The number of bytes to be read from the specified process.</param>
        /// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is 0 (zero). To get extended error information, call <see cref="GetLastError"/></returns>
        /// <remarks>Documentation: https://docs.microsoft.com/en-us/windows/win32/api/memoryapi/nf-memoryapi-readprocessmemory </remarks>
        public static bool ReadProcessMemory(UIntPtr address, byte[] arrayToStoreBytes, UIntPtr size)
        {
            return ReadProcessMemory(MemoryAddressController.AttachedProcHandle, address, arrayToStoreBytes, size, IntPtr.Zero);
        }


        /// <summary>
        /// Writes data to an area of memory in a specified process. The entire area to be written to must be accessible or the operation fails.
        /// </summary>
        /// <param name="hProcess">A handle to the process memory to be modified. The handle must have PROCESS_VM_WRITE and PROCESS_VM_OPERATION access to the process.</param>
        /// <param name="lpBaseAddress">A pointer to the base address in the specified process to which data is written. Before data transfer occurs, the system verifies that all data in the base address and memory of the specified size is accessible for write access, and if it is not accessible, the function fails.</param>
        /// <param name="lpBuffer">A pointer to the buffer that contains data to be written in the address space of the specified process.</param>
        /// <param name="nSize">The number of bytes to be written to the specified process.</param>
        /// <param name="lpNumberOfBytesWritten">A pointer to a variable that receives the number of bytes transferred into the specified process. This parameter is optional. If lpNumberOfBytesWritten is NULL, the parameter is ignored.</param>
        /// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is 0 (zero). To get extended error information, call <see cref="GetLastError"/></returns>
        /// <remarks>Documentation: https://docs.microsoft.com/en-us/windows/win32/api/memoryapi/nf-memoryapi-writeprocessmemory</remarks>
        [DllImport("kernel32.dll")]
        public static extern bool WriteProcessMemory(IntPtr hProcess, UIntPtr lpBaseAddress, byte[] lpBuffer, UIntPtr nSize, IntPtr lpNumberOfBytesWritten);


        /// <summary>
        /// Writes data to an area of memory in a specified process. The entire area to be written to must be accessible or the operation fails.
        /// This overload uses <see cref="MemoryManager.ProcessHandle"/> as for the ProcessHandle to search
        /// </summary>
        /// <param name="address">A pointer to the base address in the specified process to which data is written. Before data transfer occurs, the system verifies that all data in the base address and memory of the specified size is accessible for write access, and if it is not accessible, the function fails.</param>
        /// <param name="bytesToWrite">A pointer to the buffer that contains data to be written in the address space of the specified process.</param>
        /// <param name="size">The number of bytes to be written to the specified process.</param>
        /// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is 0 (zero). To get extended error information, call <see cref="GetLastError"/></returns>
        /// <remarks>Documentation: https://docs.microsoft.com/en-us/windows/win32/api/memoryapi/nf-memoryapi-writeprocessmemory</remarks>
        public static bool WriteProcessMemory(UIntPtr address, byte[] bytesToWrite, UIntPtr size)
        {
            return WriteProcessMemory(MemoryAddressController.AttachedProcHandle, address, bytesToWrite, size, IntPtr.Zero);
        }


        /// <summary>
        /// Opens an existing local process object.
        /// </summary>
        /// <param name="dwDesiredAccess">The access to the process object. This access right is checked against the security descriptor for the process. This parameter can be one or more of the</param>
        /// <param name="bInheritHandle">If this value is TRUE, processes created by this process will inherit the handle. Otherwise, the processes do not inherit this handle.</param>
        /// <param name="dwProcessId">The identifier of the local process to be opened.</param>
        /// <returns>If the function succeeds, the return value is an open handle to the specified process. If the function fails, the return value is NULL. To get extended error information, call <see cref="GetLastError"/></returns>
        /// <remarks>Documentation: https://docs.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-openprocess </remarks>
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(UInt32 dwDesiredAccess, bool bInheritHandle, Int32 dwProcessId);


        /// <summary>
        /// Retrieves the calling thread's last-error code value. The last-error code is maintained on a per-thread basis. Multiple threads do not overwrite each other's last-error code.
        /// </summary>
        /// <returns>The return value is the calling thread's last-error code.</returns>
        /// <remarks>Documentation: https://docs.microsoft.com/en-us/windows/win32/api/errhandlingapi/nf-errhandlingapi-getlasterror </remarks>
        [DllImport("kernel32.dll")]
        public static extern int GetLastError();

        /// <summary>
        /// Retrieves information about a range of pages within the virtual address space of a specified process.
        /// </summary>
        /// <param name="hProcess">A handle to the process whose memory information is queried. The handle must have been opened with the PROCESS_QUERY_INFORMATION access right, which enables using the handle to read information from the process object.</param>
        /// <param name="lpAddress">A pointer to the base address of the region of pages to be queried. This value is rounded down to the next page boundary</param>
        /// <param name="lpBuffer">A pointer to a MEMORY_BASIC_INFORMATION structure in which information about the specified page range is returned.</param>
        /// <param name="dwLength">The size of the buffer pointed to by the lpBuffer parameter, in bytes.</param>
        /// <returns>The return value is the actual number of bytes returned in the information buffer. If the function fails, the return value is zero. To get extended error information, call <see cref="GetLastError"/></returns>
        /// <remarks>Documentation: https://docs.microsoft.com/en-us/windows/win32/api/memoryapi/nf-memoryapi-virtualqueryex </remarks>
        [DllImport("kernel32.dll", EntryPoint = "VirtualQueryEx")]
        public static extern UIntPtr Native_VirtualQueryEx(IntPtr hProcess, UIntPtr lpAddress,
            out Memory_Basic_Info64 lpBuffer, UIntPtr dwLength);


        /// <summary>
        /// Retrieves information about a range of pages within the virtual address space of a specified process.
        /// </summary>
        /// <param name="hProcess">A handle to the process whose memory information is queried. The handle must have been opened with the PROCESS_QUERY_INFORMATION access right, which enables using the handle to read information from the process object.</param>
        /// <param name="lpAddress">A pointer to the base address of the region of pages to be queried. This value is rounded down to the next page boundary</param>
        /// <param name="lpBuffer">A pointer to a MEMORY_BASIC_INFORMATION structure in which information about the specified page range is returned.</param>
        /// <returns>The return value is the actual number of bytes returned in the information buffer. If the function fails, the return value is zero. To get extended error information, call <see cref="GetLastError"/></returns>
        /// <remarks>Documentation: https://docs.microsoft.com/en-us/windows/win32/api/memoryapi/nf-memoryapi-virtualqueryex </remarks>
        public static UIntPtr VirtualQueryEx(IntPtr hProcess, UIntPtr lpAddress, out Memory_Basic_Info lpBuffer)
        {
            Memory_Basic_Info64 tmp64 = new Memory_Basic_Info64();
            var returnValue = Native_VirtualQueryEx(hProcess, lpAddress, out tmp64,
                new UIntPtr((uint)Marshal.SizeOf(tmp64)));

            lpBuffer.BaseAddress = tmp64.BaseAddress;
            lpBuffer.AllocationBase = tmp64.AllocationBase;
            lpBuffer.AllocationProtect = tmp64.AllocationProtect;
            lpBuffer.RegionSize = (long)tmp64.RegionSize;
            lpBuffer.State = tmp64.State;
            lpBuffer.Protect = tmp64.Protect;
            lpBuffer.Type = tmp64.Type;

            return returnValue;
        }
    }
}
