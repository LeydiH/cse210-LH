using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int userNumber = -1;
        while (userNumber != 0)
        {
            Console.Write("Enter a number (0 to quit): ");
            
            string userResponse = Console.ReadLine();
            userNumber = int.Parse(userResponse);
            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        }

        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }

        Console.WriteLine($"The sum is: {sum}");
        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        int max = numbers[0];
        int minPositive = -1;

        foreach (int number in numbers)
        {
            if (number > max)
            {
               
                max = number;
            }
              if (number > 0 && (minPositive == -1 || number < minPositive))
            {
                minPositive = number;
            }
        }

        Console.WriteLine($"The max is: {max}");
         if (minPositive != -1)
        {
            Console.WriteLine($"The smallest positive number is: {minPositive}");
        }
        else
        {
            Console.WriteLine("There are no positive numbers in the list");
        }

        List<int> sortedNumbers = numbers.OrderBy(n => n).ToList();
        Console.WriteLine("The sorted list is: ");
        foreach (int number in sortedNumbers)
        {
            Console.Write($"{number} ");
        }
    }
}
