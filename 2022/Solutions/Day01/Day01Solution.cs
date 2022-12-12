using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Solutions.Day01
{
    public class Day01Solution
    {
        public int GetTotalCalories()
        {
            var fileContents = Helpers.ReadEmbeddedFile(1, "Input.txt");
            var lines = Regex.Split(fileContents, "\r\n");
            var maxCalories = 0;
            var currentCalories = 0;

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    currentCalories = 0;
                    continue;
                }

                currentCalories += int.Parse(line);
                if (currentCalories > maxCalories)
                    maxCalories = currentCalories;
            }

            Console.WriteLine($"Max Calories = {maxCalories}");
            return maxCalories;
        }
    }
}
