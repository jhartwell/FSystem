using System;
using System.Collections.Generic;

namespace FSystem.Common.Interfaces
{
    public interface IFormat
    {
        string Format<T>(T value);
    }
}
