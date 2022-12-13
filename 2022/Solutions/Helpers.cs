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

        public static (int Index, int Value) IndexOfMin(this IList<int> self)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            if (self.Count == 0)
            {
                throw new ArgumentException("List is empty.", "self");
            }

            int min = self[0];
            int minIndex = 0;

            for (int i = 1; i < self.Count; ++i)
            {
                if (self[i] < min)
                {
                    min = self[i];
                    minIndex = i;
                }
            }

            return (minIndex, min);
        }
    }
}
