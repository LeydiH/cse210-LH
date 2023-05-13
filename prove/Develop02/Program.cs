using System;


class Journal
{

    public List<Entry> Entries { get; set; }

    public Journal(string title, string author)
    {

        Entries = new List<Entry>();
    }


    public void AddEntry(Entry entry)
    {
        Entries.Add(entry);
    }


    public void Save(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {

            foreach (Entry entry in Entries)
            {
                writer.WriteLine(entry.Date);
                writer.WriteLine(entry.Prompt);
                writer.WriteLine(entry.Content);
            }
        }
    }

    public static Journal Load(string filename)
    {
        Journal journal = null;
        using (StreamReader reader = new StreamReader(filename))
        {
            string title = reader.ReadLine();
            string author = reader.ReadLine();
            journal = new Journal(title, author);
            while (!reader.EndOfStream)
            {
                string date = reader.ReadLine();
                string prompt = reader.ReadLine();
                string content = reader.ReadLine();
                Entry entry = new Entry(date, prompt, content);
                journal.AddEntry(entry);
            }
        }
        return journal;
    }

    public void Display()
    {
        foreach (Entry entry in Entries)
        {
            Console.WriteLine(entry.Date);
            Console.WriteLine(entry.Prompt);
            Console.WriteLine(entry.Content);
        }
    }
}

class Entry
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Content { get; set; }

    public Entry(string date, string prompt, string content)
    {
        Date = date;
        Prompt = prompt;
        Content = content;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal("My Journal", "Me");
        string[] prompts = new string[] { "Who was the most interesting person I interacted with today?", "What was the best part of my day?", "How did I see the hand of the Lord in my life today?", "What was the strongest emotion I felt today?", "If I had one thing I could do over today, what would it be?" };
        Random random = new Random();
        while (true)
        {
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Load the journal from a file");
            Console.WriteLine("4. Save the journal to a file");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                int index = random.Next(0, prompts.Length);
                string prompt = prompts[index];
                Console.WriteLine(prompt);
                string content = Console.ReadLine();
                string date = DateTime.Now.ToString("MM/dd/yyyy");
                Entry entry = new Entry(date, prompt, content);
                journal.AddEntry(entry);
            }
            else if (choice == "2")
            {
                journal.Display();
            }
            else if (choice == "3")
            {
                Console.Write("Enter the filename: ");
                string filename = Console.ReadLine();
                journal = Journal.Load(filename);
            }
            else if (choice == "4")
            {
                Console.Write("Enter the filename: ");
                string filename = Console.ReadLine();
                journal.Save(filename);
            }
            else if (choice == "5")
            {
                break;
            }
        }
    }
}
//leydi