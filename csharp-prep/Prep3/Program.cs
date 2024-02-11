using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        // Create a scripture
        var scripture = new Scripture("John 3:16", "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");

        // Display initial scripture
        DisplayScripture(scripture);

        // Hide words until all are hidden
        while (!scripture.AllWordsHidden)
        {
            Console.WriteLine("Press Enter to continue or type 'quit' to exit:");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            HideRandomWords(scripture);
            DisplayScripture(scripture);
        }

        Console.WriteLine("All words in the scripture are hidden. Press any key to exit.");
        Console.ReadKey();
    }

    static void DisplayScripture(Scripture scripture)
    {
        Console.Clear();
        Console.WriteLine(scripture.Reference);
        Console.WriteLine(scripture.HiddenText);
    }

    static void HideRandomWords(Scripture scripture)
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
