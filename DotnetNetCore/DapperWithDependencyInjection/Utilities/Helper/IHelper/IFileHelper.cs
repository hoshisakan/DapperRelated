using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Helper.IHelper
{
    public interface IFileHelper
    {
        public bool IsFileExists(string path);
        public bool IsDirExists(string path);
        public bool IsFileExistsInDir(string dir, string filename);
        public bool SaveValue(string filepath, string dt, bool append);
        public void ReadFile(string filePath);
    }
}
