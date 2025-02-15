class Word
{
    private string text;
    private bool isHidden;

    public Word(string text)
    {
        this.text = text;
        isHidden = false;
    }

    public void Hide() => isHidden = true;
    public bool IsHidden() => isHidden;
    public string GetRenderedText() => isHidden ? "____" : text;
}
