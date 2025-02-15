using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Scripture> scriptures = new List<Scripture>
        {
            new Scripture(new Reference("Alma", 7, 11),
                "And he shall go forth, suffering pains and afflictions and temptations of every kind; and this that the word might be fulfilled which saith he will take upon him the pains and the sicknesses of his people."),
            
            new Scripture(new Reference("2nd Nephi", 11, 5),
                "And also my soul delighteth in the covenants of the Lord which he hath made to our fathers; yea, my soul delighteth in his grace, and in his justice, and power, and mercy in the great and eternal plan of deliverance from death."),

            new Scripture(new Reference("Helaman", 5, 12),
                "And now, my sons, remember, remember that it is upon the rock of our Redeemer, who is Christ, the Son of God, that ye must build your foundation; that when the devil shall send forth his mighty winds, yea, his shafts in the whirlwind, yea, when all his hail and his mighty storm shall beat upon you, it shall have no power over you to drag you down to the gulf of misery and endless wo, because of the rock upon which ye are built, which is a sure foundation, a foundation whereon if men build they cannot fall.")
        };

        Console.WriteLine("Select a scripture to memorize:");
        for (int i = 0; i < scriptures.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {scriptures[i].GetReference()}");
        }

        Console.Write("\nEnter a number: ");
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > scriptures.Count)
        {
            Console.Write("Invalid input. Enter a valid number: ");
        }

        Scripture selectedScripture = scriptures[choice - 1];

        while (!selectedScripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(selectedScripture.GetRenderedText());
            Console.WriteLine("\nPress Enter to continue or type 'quit' to exit.");

            string input = Console.ReadLine();
            if (input.ToLower() == "quit") break;

            selectedScripture.HideWords();
        }

        Console.Clear();
        Console.WriteLine("All words are hidden. Program ended.");
    }
}
