﻿// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

using System;
using System.Diagnostics.Contracts;
using System.IO;
using SchwabenCode.QuickIO.Win32;

namespace SchwabenCode.QuickIO.Engine
{
    /// <summary>
    /// Provides several methods for internal purposes.
    /// </summary>
    internal static partial class QuickIOEngine
    {
        /// <summary>
        /// Common Constants
        /// </summary>
        public static class Constants
        {
            /// <summary>
            /// Represents return value of invalid request of get the file attributes of a system entry.
            /// Is equal to UInt32.MaxValue
            /// See http://msdn.microsoft.com/en-us/library/windows/desktop/aa364944(v=vs.85).aspx
            /// </summary>
            public const UInt32 InvalidFileAttributes = 0xffffffff;
        }

        /// <summary>
        /// Determines the type based on the attributes of the path
        /// </summary>
        /// <param name="fullPath">Full path</param>
        /// <returns><see cref="QuickIOFileSystemEntryType"/></returns>
        internal static QuickIOFileSystemEntryType DetermineFileSystemEntry(string fullPath)
        {
            Contract.Requires(!String.IsNullOrWhiteSpace(fullPath));

            Win32FindData findData = Engine.QuickIOEngine.GetFindDataFromPath(fullPath);

            return !findData.dwFileAttributes.Contains(FileAttributes.Directory) ? QuickIOFileSystemEntryType.File : QuickIOFileSystemEntryType.Directory;
        }

        /// <summary>
        /// Determines the type based on the attributes of the handle
        /// </summary>
        /// <param name="findData"><see cref="Win32FindData"/></param>
        /// <returns><see cref="QuickIOFileSystemEntryType"/></returns>
        internal static QuickIOFileSystemEntryType DetermineFileSystemEntry(Win32FindData findData)
        {
            Contract.Requires(findData != null);

            return !findData.dwFileAttributes.Contains(FileAttributes.Directory) ? QuickIOFileSystemEntryType.File : QuickIOFileSystemEntryType.Directory;
        }
    }
}
