
namespace CalorieTracker
{
    abstract class Person
    {
        protected string _name;
        protected float _age;
        protected float _weight;
        protected float _height;
        protected float _bmr;

        public abstract void GetUserData();

        public virtual void SaveUserData()
        {
            string[] userData = { _name, _age.ToString(), _weight.ToString(), _height.ToString(), _bmr.ToString() };
            File.WriteAllLines("user_data.txt", userData);
        }
    }

    class User : Person
    {
        public override void GetUserData()
        {
            Console.Write("Enter your name: ");
            _name = Console.ReadLine();
            Console.Write("Enter your age: ");
            _age = float.Parse(Console.ReadLine());
            Console.Write("Enter your weight in Kg: ");
            _weight = float.Parse(Console.ReadLine());
            Console.Write("Enter your height in cm: ");
            _height = float.Parse(Console.ReadLine());
            CalculateBmr();
        }

        private void CalculateBmr()
        {
            _bmr = 66 + (13.7f * _weight) + (5 * _height) - (6.8f * _age);
            Console.WriteLine($"Your BMR is: {_bmr}");
        }

        public void PrintUserData()
        {
            string[] userData = File.ReadAllLines("user_data.txt");
            Console.WriteLine($"User name: {userData[0]}");
            Console.WriteLine($"User age: {userData[1]}");
            Console.WriteLine($"User weight in Kg: {userData[2]}");
            Console.WriteLine($"User height in cm: {userData[3]}");
            Console.WriteLine($"BMR: {userData[4]}");
        }
    }

    class Food
    {
        private string _foodName;
        private float _caloriesPer100g;
        private float _quantity;

        public void EnterFoodData()
        {
            Console.Write("Enter food name: ");
            _foodName = Console.ReadLine();
            Console.Write("Enter quantity in grams: ");
            _quantity = float.Parse(Console.ReadLine());
            Console.Write("Enter calories per 100 grams: ");
            _caloriesPer100g = float.Parse(Console.ReadLine());
            SaveFoodData();
        }

        public void SaveFoodData()
        {
            float totalCalories = (_quantity / 100) * _caloriesPer100g;
            string[] foodData = { _foodName, totalCalories.ToString() };
            File.AppendAllLines("food_data.txt", foodData);
        }
    }

    class CalorieCalculator
    {
        public void CalculateAndSaveRemainingCalories()
        {
            float totalCalories = 0;
            string[] foodData = File.ReadAllLines("food_data.txt");
            for (int i = 1; i < foodData.Length; i+=2)
            {
                totalCalories += float.Parse(foodData[i]);
            }

            string[] userData = File.ReadAllLines("user_data.txt");
            float bmr = float.Parse(userData[4]);

            float remainingCalories = bmr - totalCalories;
            File.WriteAllText("remaining_calories.txt", remainingCalories.ToString());
        }

        public void PrintRemainingCalories()
        {
            string remainingCalories = File.ReadAllText("remaining_calories.txt");
            Console.WriteLine($"Remaining calories: {remainingCalories}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1. Enter user data");
                Console.WriteLine("2. Enter food data");
                Console.WriteLine("3. Calculate remaining calories");
                Console.WriteLine("4. Print remaining calories");
                Console.WriteLine("5. Print user data");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

            if (choice == "1")
            {
                User user = new User();
                user.GetUserData();
                user.SaveUserData();
            }
            else if (choice == "2")
            {
                Food food = new Food();
                food.EnterFoodData();
            }
            else if (choice == "3")
            {
                CalorieCalculator calorieCalculator = new CalorieCalculator();
                calorieCalculator.CalculateAndSaveRemainingCalories();
            }
            else if (choice == "4")
            {
                CalorieCalculator calorieCalculator = new CalorieCalculator();
                calorieCalculator.PrintRemainingCalories();
            }
            else if (choice == "5")
            {
                User user = new User();
                user.PrintUserData();
            }
            else if (choice == "6")
            {
                Console.WriteLine("Goodbye!");
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Try again.");
            }
        }
    }
}
}