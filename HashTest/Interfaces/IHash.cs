﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hasher.Interfaces
{
    public interface IHash
    {
        public string HashFile(IFile file, long bufferSize);
    }
}