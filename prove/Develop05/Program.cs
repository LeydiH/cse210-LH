using System;

//namespace Develop05

abstract class Goal
{
    private string name;
    private int score;
    private bool isCompleted;

    public Goal(string name)
    {
        this.name = name;
        this.score = 0;
        this.isCompleted = false;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Score
    {
        get { return score; }
        set { score = value; }
    }

    public bool IsCompleted
    {
        get { return isCompleted; }
        set { isCompleted = value; }
    }

    public virtual void RecordEvent()
    {
        this.Score += 1;
    }

    public abstract string GetGoalDetails();
}

class SimpleGoal : Goal
{
    private int value;

    public SimpleGoal(string name, int value) : base(name)
    {
        this.value = value;
    }

    public int Value
    {
        get { return value; }
        set { this.value = value; }
    }

    public override void RecordEvent()
    {
        base.RecordEvent();
        this.IsCompleted = true;
        this.Score = this.Value;
    }

    public override string GetGoalDetails()
    {
        return "Simple Goal: " + this.Name + " [Score: " + this.Score + "]";
    }
}

// Derived Eternal Goals
class EternalGoal : Goal
{
    private int value;

    public EternalGoal(string name, int value) : base(name)
    {
        this.value = value;
    }

    public int Value
    {
        get { return value; }
        set { this.value = value; }
    }

    public override void RecordEvent()
    {
        base.RecordEvent();
        this.Score += this.Value;
    }

    public override string GetGoalDetails()
    {
        return "Eternal Goal: " + this.Name + " [Score: " + this.Score + "]";
    }
}

// Derived Checklist Goals
class ChecklistGoal : Goal
{
    private int value;
    private int timesToComplete;
    private int timesCompleted;

    public ChecklistGoal(string name, int value, int timesToComplete) : base(name)
    {
        this.value = value;
        this.timesToComplete = timesToComplete;
        this.timesCompleted = 0;
    }

    public int Value
    {
        get { return value; }
        set { this.value = value; }
    }

    public int TimesToComplete
    {
        get { return timesToComplete; }
        set { timesToComplete = value; }
    }

    public int TimesCompleted
    {
        get { return timesCompleted; }
        set { timesCompleted = value; }
    }

    public override void RecordEvent()
    {
        base.RecordEvent();
        this.TimesCompleted += 1;
        this.Score += this.Value;
        if (this.TimesCompleted == this.TimesToComplete)
        {
            this.IsCompleted = true;
            this.Score += this.Value * 10;
        }
    }

    public override string GetGoalDetails()
    {
        return "Checklist Goal: " + this.Name + " [Score: " + this.Score + "] [Completed " + this.TimesCompleted + "/" + this.TimesToComplete + " times]";
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Goal> goals = new List<Goal>();

        // user choice
        int choice = 0;

        // user goal name variable
        string goalName = "";

        // user goal value
        int goalValue = 0;

        // user goal times to complete
        int goalTimesToComplete = 0;

        // user goal index
        int goalIndex = 0;

        // user goal type
        int goalType = 0;

        while (choice != 4)
        {
            // menu
            Console.WriteLine("1. Add a goal");
            Console.WriteLine("2. Record an event");
            Console.WriteLine("3. Display all goals");
            Console.WriteLine("4. Save goals and Exit");

            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    // Get the goal
                    Console.WriteLine("What type of goal do you want to add?");
                    Console.WriteLine("1. Simple Goal");
                    Console.WriteLine("2. Eternal Goal");
                    Console.WriteLine("3. Checklist Goal");
                    goalType = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter the goal name:");
                    goalName = Console.ReadLine();

                    Console.WriteLine("Enter the goal value:");
                    goalValue = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter the goal times to complete:");
                    goalTimesToComplete = Convert.ToInt32(Console.ReadLine());

                    // make the goal
                    switch (goalType)
                    {
                        case 1:
                            goals.Add(new SimpleGoal(goalName, goalValue));
                            break;
                        case 2:
                            goals.Add(new EternalGoal(goalName, goalValue));
                            break;
                        case 3:
                            goals.Add(new ChecklistGoal(goalName, goalValue, goalTimesToComplete));
                            break;
                    }
                    break;
                case 2:
  
                    Console.WriteLine("Enter the goal index to record an event for:");
                    goalIndex = Convert.ToInt32(Console.ReadLine());


                    // Record the event
                    goals[goalIndex].RecordEvent();

                    // Check if the goal is completed
                    if (goals[goalIndex].IsCompleted)
                    {
                        Console.WriteLine("You completed the goal!");
                    }
                    break;
                case 3:

                    for (int i = 0; i < goals.Count; i++)
                    {
                        // goal details
                        Console.WriteLine(goals[i].GetGoalDetails());
                    }
                    break;
                case 4:
                    
                    StreamWriter writer = new StreamWriter("goals.txt");
                    // write the goals to file
                    for (int i = 0; i < goals.Count; i++)
                    {
                        writer.WriteLine(goals[i].Name);
                        writer.WriteLine(goals[i].Score);
                        writer.WriteLine(goals[i].IsCompleted);
                        writer.WriteLine(goals[i].GetType());
                    }

                    writer.Close();
                    Console.WriteLine("Goodbye!");
                    break;
                default:

                    Console
                        .WriteLine("Invalid choice. Please choose a number between 1 and 4.");
                    break;
            }
        }
    }
}