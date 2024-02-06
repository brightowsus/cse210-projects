using System;

class Entry {
    public string Prompt { get; }
    public string Response { get; }
    public DateTime Date { get; }

    public Entry(string prompt, string response, DateTime date) {
        Prompt = prompt;
        Response = response;
        Date = date;
    }

    public override string ToString() {
        return $"{Date}: {Prompt}\n{Response}\n";
    }
}

class Journal {
    private List<Entry> entries;

    public Journal() {
        entries = new List<Entry>();
    }

    public void AddEntry(string prompt, string response, DateTime date) {
        entries.Add(new Entry(prompt, response, date));
    }

    public void DisplayEntries() {
        foreach (var entry in entries) {
            Console.WriteLine(entry);
        }
    }

    public void SaveToFile(string filename) {
        using (StreamWriter writer = new StreamWriter(filename)) {
            foreach (var entry in entries) {
                writer.WriteLine($"{entry.Date}: {entry.Prompt}");
                writer.WriteLine(entry.Response);
            }
        }
    }

    public void LoadFromFile(string filename) {
        entries.Clear();
        using (StreamReader reader = new StreamReader(filename)) {
            while (!reader.EndOfStream) {
                DateTime date;
                string prompt = reader.ReadLine();
                string response = reader.ReadLine();
                if (DateTime.TryParse(prompt.Substring(0, prompt.IndexOf(':')), out date)) {
                    entries.Add(new Entry(prompt.Substring(prompt.IndexOf(':') + 1).Trim(), response, date));
                }
            }
        }
    }
}

class Program {
    static void Main(string[] args) {
        Journal journal = new Journal();
        bool exit = false;

        while (!exit) {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice) {
                case "1":
                    WriteNewEntry(journal);
                    break;
                case "2":
                    journal.DisplayEntries();
                    break;
                case "3":
                    Console.Write("Enter filename to save: ");
                    string saveFileName = Console.ReadLine();
                    journal.SaveToFile(saveFileName);
                    break;
                case "4":
                    Console.Write("Enter filename to load: ");
                    string loadFileName = Console.ReadLine();
                    journal.LoadFromFile(loadFileName);
                    break;
                case "5":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void WriteNewEntry(Journal journal) {
        // Sample prompts
        string[] prompts = {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };

        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Length)];
        
        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();
        journal.AddEntry(prompt, response, DateTime.Now);
    }
}
