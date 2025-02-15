using System;
using System.Collections.Generic;
using System.Linq;

class Scripture
{
    private Reference reference;
    private List<Word> words;
    private Random random = new Random();

    public Scripture(Reference reference, string text)
    {
        this.reference = reference;
        words = text.Split(' ').Select(w => new Word(w)).ToList();
    }

    public void HideWords()
    {
        List<Word> visibleWords = words.Where(w => !w.IsHidden()).ToList();
        if (visibleWords.Count == 0) return;

        int wordsToHide = Math.Max(1, visibleWords.Count / 4);
        for (int i = 0; i < wordsToHide; i++)
        {
            visibleWords[random.Next(visibleWords.Count)].Hide();
        }
    }

    public bool IsCompletelyHidden() => words.All(w => w.IsHidden());

    public string GetRenderedText()
    {
        return $"{reference}\n" + string.Join(" ", words.Select(w => w.GetRenderedText()));
    }
    public string GetReference()
{
    return reference.ToString();
}
}
