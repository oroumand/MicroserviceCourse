using Newtonsoft.Json;
using System;
using System.Text;

namespace Rbt.Toolkits
{
    public static class Serializer
    {
        public static string ToJsonString<T>(this T input)=>JsonConvert.SerializeObject(input);
        public static T FromJsonString<T>(this string input) => JsonConvert.DeserializeObject<T>(input);
        public static byte[] ToByteArray<T>(this T input) => Encoding.ASCII.GetBytes(input.ToJsonString());
        public static T FromByteArray<T>(this byte[] input) => Encoding.ASCII.GetString(input).FromJsonString<T>();
    }
}
