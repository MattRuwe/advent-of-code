using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Solutions
{
    public static class Helpers
    {
        public static string ReadEmbeddedFile(int dayNumber, string fileName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = $"Solutions.Day{dayNumber.ToString().PadLeft(2, '0')}.{fileName}";

            //var resourceNames = assembly.GetManifestResourceNames();
            //foreach (var name in resourceNames)
            //{
            //    Console.WriteLine(name);
            //}

            using Stream stream = assembly.GetManifestResourceStream(resourceName);
            if (stream == null)
                throw new InvalidOperationException($"The embedded resource {resourceName} could not be found.");
            using StreamReader reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }

        public static void Deconstruct<T>(this IList<T> list, out T first, out IList<T> rest)
        {
            first = list.Count > 0 ? list[0] : default(T); // or throw
            rest = list.Skip(1).ToList();
        }

        public static void Deconstruct<T>(this IList<T> list, out T first, out T second, out IList<T> rest)
        {
            first = list.Count > 0 ? list[0] : default(T); // or throw
            second = list.Count > 1 ? list[1] : default(T); // or throw
            rest = list.Skip(2).ToList();
        }
    }
}
