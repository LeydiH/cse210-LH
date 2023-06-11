namespace Mindfulness
{
    class Program
    {
        static void Main(string[] args)
        {
            Mindfulness mindfulness = new Mindfulness();

            mindfulness.Run();

            Console.ReadKey();
        }
    }

    class Mindfulness
    {
        Menu menu = new Menu();

        public void Run()
        {
            // Show menu options
            menu.Show();

            // Get user input
            int choice = int.Parse(Console.ReadLine());

            // Perform selected activity
            Activity activity;
            switch (choice)
            {
                case 1:
                    // Start Breathing Activity
                    activity = new BreathingActivity();
                    activity.Start();
                    break;
                case 2:
                    // Start Reflection Activity
                    activity = new ReflectionActivity();
                    activity.Start();
                    break;
                case 3:
                    // Start Listing Activity
                    activity = new ListingActivity();
                    activity.Start();
                    break;
                case 4:
                    // Start reminder activity
                    activity = new ReminderActivity();
                    activity.Start();
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    return;
            }

            // Show end message
            Console.WriteLine("Good job! You have completed the activity.");
            Console.WriteLine("Duration: " + activity.duration + " seconds");
            Console.WriteLine("Press any key to exit.");
        }
    }

    class Animation
    {
        public static void Spinner()
        {
            Console.Write("Starting in ");
            for (int i = 3; i > 0; i--)
            {
                Console.Write(i + " ");
                System.Threading.Thread.Sleep(1000);
            }
            Console.WriteLine();
        }

        public static void Pause()
        {
            Console.Write("Pause");
            for (int i = 0; i < 3; i++)
            {
                Console.Write(".");
                System.Threading.Thread.Sleep(1000);
            }
            Console.WriteLine();
        }

        public static void Countdown()
        {
            Console.Write("Starting in ");
            for (int i = 3; i > 0; i--)
            {
                Console.Write(i + " ");
                System.Threading.Thread.Sleep(1000);
            }
            Console.WriteLine();
        }
    }

    class Menu
    {
        public void Show()
        {
            Console.WriteLine("Welcome to Mindfulness!");
            Console.WriteLine("Please select an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Reminder Activity");
        }
    }


    class Activity
    {
        public int duration;
        public virtual void Start()
        {
            // Get duration from user
            Console.Write("How long would you like to do this activity for? (in seconds) ");
            duration = int.Parse(Console.ReadLine());


            // Start activity
            Animation.Countdown();
        }
    }

    class ReminderActivity : Activity
    {
        public ReminderActivity()
        {
            Console.WriteLine("This activity will help you remember to do something.");
        }

        public override void Start()
        {
            // Start activity
            base.Start();

            // Perform activity
            Console.WriteLine("Type what would you like to remember to do?");
            string reminder = Console.ReadLine();
            Console.WriteLine("You will be reminded to " + reminder + " in " + duration + " seconds.");
            System.Threading.Thread.Sleep(duration * 1000);
            Console.WriteLine();
            Console.WriteLine("Remember to " + reminder + "!\n");
        }
    }

    class BreathingActivity : Activity
    {
        public BreathingActivity()
        {
            Console.WriteLine("This activity will help you focus on your breathing and relax.");
        }

        public override void Start()
        {
            // Start activity
            base.Start();

            // Perform activity
            for (int i = 0; i < duration / 2; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine("Breathe in...");
                }
                else
                {
                    Console.WriteLine("Breathe out...");
                }
                Animation.Pause();
            }
        }
    }

    class ReflectionActivity : Activity
    {
        public ReflectionActivity()
        {
            Console.WriteLine("This activity will help you reflect on your thoughts and emotions.");
        }

        public override void Start()
        {
            // Start activity
            base.Start();

            // Get prompt
            string[] prompts = new string[] {
                "Think of a time when you stood up for someone else.",
                "Think of a time when you did something really difficult.",
                "Think of a time when you helped someone in need.",
                "Think of a time when you did something truly selfless."
            };
            Random random = new Random();
            int promptIndex = random.Next(prompts.Length);
            string prompt = prompts[promptIndex];


            // Perform activity
            for (int i = 0; i < duration / 2; i++)
            {
                Console.WriteLine("Reflect about the following questions.\n");
                // Get question
                string[] questions = new string[] {
                    "Why was this experience meaningful to you?",
                    "Have you ever done anything like this before?",
                    "How did you get started?",
                    "How did you feel when it was complete?",
                    "What made this time different than other times when you were not as successful?",
                    "What is your favorite thing about this experience?",
                    "What could you learn from this experience that applies to other situations?",
                    "What did you learn about yourself through this experience?",
                    "How can you keep this experience in mind in the future?"
                };
                int questionIndex = random.Next(questions.Length);
                string question = questions[questionIndex];

                // Ask question
                Console.WriteLine(question);
                Animation.Pause();

                Animation.Pause();
            }
        }
    }

    class ListingActivity : Activity
    {
        public ListingActivity()
        {
            Console.WriteLine("This activity will help you organize your thoughts by listing things.");
        }

        public override void Start()
        {
            // Start activity
            base.Start();
            // Get prompt
            string[] prompts = new string[] {
            "Who are people that you appreciate?.",
            "What are personal strengths of yours?.",
            "Who are people that you have helped this week?.",
            "When have you felt the Holy Ghost this month?.",
            "Who are some of your personal heroes?."};

            Random random = new Random();
            int index = random.Next(prompts.Length);
            string prompt = prompts[index];

            // Perform activity
            Console.WriteLine(prompt);

            // Get list
            string[] list = new string[duration];


            // Perform activity
            for (int i = 0; i < duration / 2; i++)
            {
                Animation.Pause();
            }
        }
    }
}