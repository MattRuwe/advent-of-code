using System.Text.RegularExpressions;

namespace Solutions.Day01
{
    public class Day01Solution
    {
        public int[] GetTotalCalories()
        {
            var fileContents = Helpers.ReadEmbeddedFile(1, "Input.txt");
            var lines = Regex.Split(fileContents, "\r\n");
            var currentCalories = 0;

            var maxCalories = Enumerable.Range(0, 3).ToList();

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    currentCalories = 0;
                    continue;
                }

                currentCalories += int.Parse(line);
                var minAndIndex = maxCalories.IndexOfMin();
                if (currentCalories > minAndIndex.Value)
                    maxCalories[minAndIndex.Index] = currentCalories;
                  
            }

            foreach (var elf in maxCalories)
            {
                Console.WriteLine(elf);   
            }
            Console.WriteLine($"Max Calories = {maxCalories.Max()}");
            Console.WriteLine($"Top 3 Max Calories = {maxCalories.Sum()}");
            return maxCalories.ToArray();
        }
    }
}
