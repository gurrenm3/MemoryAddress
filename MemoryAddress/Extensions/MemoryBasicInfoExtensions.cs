using MemoryAddress.Win32;

namespace MemoryAddress
{
    /// <summary>
    /// Extension methods for MemoryBasicInfo
    /// </summary>
    public static class MemoryBasicInfoExtensions
    {
        /// <summary>
        /// Returns if this region in memory is free or not
        /// </summary>
        /// <param name="memoryInfo"></param>
        /// <returns></returns>
        public static bool IsRegionFree(this Memory_Basic_Info memoryInfo)
        {
            return memoryInfo.State == MemoryAllocateType.Free;
        }
    }
}
