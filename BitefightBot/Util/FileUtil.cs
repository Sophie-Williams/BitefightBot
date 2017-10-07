using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitefightBot.Util
{
    /// <summary>
    /// File Utility
    /// </summary>
    public static class FileUtil
    {
        /// <summary>
        /// Reads the content of a file and returns the content as a string.
        /// </summary>
        /// <param name="file">File location</param>
        /// <returns>string</returns>
        public static string ReadFileContent(string file)
        {
            return File.ReadAllText(file);
        }
    }
}