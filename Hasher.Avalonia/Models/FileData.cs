using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hasher.Avalonia.Models
{
    public class FileData
    {
        public string Name { get; set; } = string.Empty;
        public ulong Size { get; set; }
        public ulong SizeInKBs { get; set; }
        public ulong SizeInMBs { get; set; }
        public bool IsSelected { get; set; }
    }
}
