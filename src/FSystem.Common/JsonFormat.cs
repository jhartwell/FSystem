using System;
using System.Collections.Generic;
using FSystem.Common.Interfaces;
using Newtonsoft.Json;

namespace FSystem.Common
{
    /// <summary>
    /// Concrete implementation of <see cref="IFormat"/>
    /// </summary>
    public class JsonFormat : IFormat
    {
        /// <summary>
        /// Formats the given value to Json
        /// </summary>
        /// <returns>A string that contains the serialized Json.</returns>
        /// <param name="value">The object that is going to be serialized
        /// into JSON</param>
        /// <typeparam name="T">The type of the object that is going to be
        /// formatted.</typeparam>
        public string Format<T>(T value)
        {
            return JsonConvert.SerializeObject(new { items = value });
        }
    }
}
