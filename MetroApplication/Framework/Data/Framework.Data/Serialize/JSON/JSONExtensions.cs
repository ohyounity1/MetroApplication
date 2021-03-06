﻿using System;

using Newtonsoft.Json.Linq;

using Framework.Data.Exception;

using OurException = Framework.Patterns.Exception.Exception;

namespace Framework.Data.Serialize.JSON
{
    /// <summary>
    /// Extension helpers for reading JSON
    /// </summary>
    public static class JSONExtensions
    {
        /// <summary>
        /// Helper for reading properties from a <see cref="JObject"/> and casting and returning the proper type
        /// </summary>
        /// <typeparam name="T">Type to convert <see cref="JToken"/> into</typeparam>
        /// <param name="jObject">Source of serialization</param>
        /// <param name="propertyName">Name of the property to look up in the <see cref="JObject"/></param>
        /// <param name="converter">Converter method from the <see cref="JToken"/> to <see cref="T"/></param>
        /// <returns></returns>
        public static T Read<T>(this JObject jObject, string propertyName, Func<JToken, T> converter)
        {
            // Get the value out of the JObject
            if (jObject.TryGetValue(propertyName, out JToken token))
            {
                // Convert to type T
                return converter(token);
            }
            // Use exception
            throw OurException.Throw(new PropertyNotFoundException(propertyName));
        }

        /// <summary>
        /// Helper for reading properties from a <see cref="JObject"/> and casting and assigning the result to a particular item
        /// </summary>
        /// <typeparam name="T">Type to convert <see cref="JToken"/> into</typeparam>
        /// <param name="jObject">Source of the data</param>
        /// <param name="propertyName">Name of the property to lookup in the <see cref="JObject"/></param>
        /// <param name="converter">Converts from <see cref="JToken"/> to type <see cref="T"/></param>
        /// <param name="assigner">Lambda to assign the value of <see cref="T"/></param>
        public static void Read<T>(this JObject jObject, string propertyName, Func<JToken, T> converter, Action<T> assigner)
        {
            // Try reading out the data
            if (jObject.TryGetValue(propertyName, out JToken token))
            {
                // Convert the data
                var result = converter(token);
                // Assign to something
                assigner(result);
            }
            // Use exception
            throw OurException.Throw(new PropertyNotFoundException(propertyName));
        }
    }
}
