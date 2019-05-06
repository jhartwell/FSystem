using System;
using System.Collections.Generic;
using FSystem.Common.Interfaces;
using Newtonsoft.Json;

namespace FSystem.Common
{
    public class JsonFormat : IFormat
    {
        public string Format<T>(T value)
        {
            return JsonConvert.SerializeObject(value);
        }
    }
}
