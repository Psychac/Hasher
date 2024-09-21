using HasherTest.HashClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HasherTest.Interfaces
{
    public interface IHash
    {
        public double CurrentProgressPercent { get; set; }
        public EventHandler<double>? ProgressUpdater { get; set; }
        public abstract string HashFile(FileData file, long bufferSize);
    }
}
