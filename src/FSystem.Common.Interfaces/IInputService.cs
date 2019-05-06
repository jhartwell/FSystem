﻿using System;
using System.Collections.Generic;
using System.IO;

namespace FSystem.Common.Interfaces
{
    public interface IInputService
    {
        IEnumerable<IRecord> GetPipeDelimitedRecords(Stream input);
        IEnumerable<IRecord> GetSpaceDelimitedRecords(Stream input);
        IEnumerable<IRecord> GetCommaDelimitedRecords(Stream input);
    }
}