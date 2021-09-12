using MemoryAddress.Win32;
using System;
using System.Diagnostics;
using System.Linq;

namespace MemoryAddress
{
    public class MemoryAddressController : IDisposable
    {
        #region Properties

        public static IntPtr AttachedProcHandle { get; private set; }

        #endregion

        /// <summary>
        /// Attach to a Process so memory values can be read and written to
        /// </summary>
        /// <param name="process">Process to attach to</param>
        /// <returns>Returns true if successfully attached to Process. False if it failed</returns>
        public bool AttachToProcess(Process process) => AttachToProcess(process.Id);


        /// <summary>
        /// Attach to a Process so memory values can be read and written to
        /// </summary>
        /// <param name="processName">Name of the process to attach to. If there is more than one with the same name only the first will be chosen</param>
        /// <returns>Returns true if successfully attached to Process. False if it failed</returns>
        public bool AttachToProcess(string processName)
        {
            var processes = Process.GetProcessesByName(processName);
            return AttachToProcess(processes.First());
        }


        // Based off of https://github.com/erfg12/memory.dll/blob/28548c4ce53b769c023e48b4da9604ece8d4e15b/Memory/memory.cs#L411
        /// <summary>
        /// Attach to a Process so memory values can be read and written to. Make sure to run as Admin otherwise this may fail
        /// </summary>
        /// <param name="processId">The Process ID of the Process to attach to</param>
        /// <returns>Returns true if successfully attached to Process. False if it failed</returns>
        public bool AttachToProcess(int processId)
        {
            if (processId <= 0)
                return false;

            var procHandle = Kernel32.OpenProcess(0x1F0FFF, true, processId);
            if (procHandle == IntPtr.Zero)
                return false;

            AttachedProcHandle = procHandle;
            return true;
        }

        private void CloseAttachedProcess()
        {
            if (AttachedProcHandle != IntPtr.Zero)
                Kernel32.CloseHandle(AttachedProcHandle);
        }


        #region Deconstructor

        bool disposed;

        ~MemoryAddressController() { Dispose(); }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Closes <see cref="AttachedProcHandle"/> when disposed
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

            // Release unmanaged resources.
            CloseAttachedProcess();

            disposed = true;
        }

        #endregion
    }
}
