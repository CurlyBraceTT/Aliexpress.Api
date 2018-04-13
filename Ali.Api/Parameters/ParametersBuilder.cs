using System;
using System.Net;
using System.Reflection;
using System.Text;

namespace Ali.Api.Parameters
{
    /// <summary>
    /// Parameters builder
    /// </summary>
    public class ParametersBuilder
    {
        public ParametersBuilder()
        { }

        /// <summary>
        /// Builds the specified parameters.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public virtual string Build<T>(T parameters)
        {
            var result = new StringBuilder();
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                var value = property.GetValue(parameters);

                if (value == null || string.IsNullOrEmpty(value.ToString()))
                {
                    continue;
                }

                var name = property.Name.Substring(0, 1).ToLower() + property.Name.Substring(1);
                var stringValue = string.Empty;

                if (property.PropertyType == typeof(DateTime) || property.PropertyType == typeof(DateTime?))
                {
                    var date = DateTime.Parse(value.ToString());
                    stringValue = date.ToString("yyyy-mm-dd");
                }
                else
                {
                    stringValue = value.ToString();
                }

                if (result.Length == 0)
                {
                    result.AppendFormat("{0}={1}", name, WebUtility.UrlEncode(stringValue));
                }
                else
                {
                    result.AppendFormat("&{0}={1}", name, WebUtility.UrlEncode(stringValue));
                }
            }

            return result.ToString();
        }
    }
}
