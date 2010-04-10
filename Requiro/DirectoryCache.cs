using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Requiro
{
    class DirectoryCache
    {
        private Dictionary<string, Dictionary<string, long>> m_Cache;

        public DirectoryCache()
        {
            m_Cache = new Dictionary<string, Dictionary<string, long>>();
        }

        public void AddPathFiles(string fullPath, Dictionary<string, long> directoryFiles)
        {
            if (!m_Cache.ContainsKey(fullPath))
            {
                m_Cache.Add(fullPath, directoryFiles);
            }
        }

        public Dictionary<string, long> GetPathFiles(string fullPath)
        {
            if (HasPath(fullPath))
                return m_Cache[fullPath];
            else
                return null;
        }

        public bool HasPath(string fullPath)
        {
            return m_Cache.ContainsKey(fullPath);
        }
    }
}
