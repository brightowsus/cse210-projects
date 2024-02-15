using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        // Create a new instance of the ScriptureMemorizer class
        var scriptureMemorizer = new ScriptureMemorizer();

        // Run the memorization process
        scriptureMemorizer.Run();
    }
}

public class ScriptureMemorizer
{
    private List<Scripture> scriptures;

    public ScriptureMemorizer()
    {
        scriptures = new List<Scripture>();

        // Add sample scriptures
        scriptures.Add(new Scripture("John 3:16", "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."));
        scriptures.Add(new Scripture("Proverbs 3:5-6", "Trust in the LORD with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight."));
    }

    public void Run()
    {
        // Iterate over each scripture
        foreach (var scripture in scriptures)
        {
            // Display initial scripture
            DisplayScripture(scripture);

            // Hide words until all are hidden
            while (!scripture.AllWordsHidden)
            {
                Console.WriteLine("Press Enter to continue or type 'quit' to exit:");
                string input = Console.ReadLine();

                if (input.ToLower() == "quit")
                    return;

                HideRandomWords(scripture);
                DisplayScripture(scripture);
            }

            Console.WriteLine($"All words in the scripture '{scripture.Reference}' are hidden.");
        }

        Console.WriteLine("All scriptures are memorized. Press any key to exit.");
        Console.ReadKey();
    }

    private void DisplayScripture(Scripture scripture)
    {
        Console.Clear();
        Console.WriteLine(scripture.Reference);
        Console.WriteLine(scripture.HiddenText);
    }

    private void HideRandomWords(Scripture scripture)
    {
        scripture.HideRandomWords();
    }
}

public class Scripture
{
    public string Reference { get; }
    private List<string> Words { get; }
    private List<int> HiddenWordIndices { get; }

    public string HiddenText
    {
        get
        {
            var hiddenText = new List<string>(Words);
            foreach (var index in HiddenWordIndices)
            {
                hiddenText[index] = new string('_', hiddenText[index].Length);
            }
            return string.Join(" ", hiddenText);
        }
    }

    public bool AllWordsHidden => HiddenWordIndices.Count == Words.Count;

    public Scripture(string reference, string text)
    {
        Reference = reference;
        Words = text.Split(' ').ToList();
        HiddenWordIndices = new List<int>();
    }

    public void HideRandomWords()
    {
        Random random = new Random();
        int randomIndex;
        do
        {
            randomIndex = random.Next(Words.Count);
        } while (HiddenWordIndices.Contains(randomIndex));

        HiddenWordIndices.Add(randomIndex);
    }
}
