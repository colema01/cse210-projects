public class Scripture
{
    public ScriptureReference Reference { get; private set; }
    public List<ScriptureWord> Words { get; private set; }

    public Scripture(string text, ScriptureReference reference)
    {
        Reference = reference;
        Words = new List<ScriptureWord>();
        foreach (var word in text.Split(' '))
        {
            Words.Add(new ScriptureWord { Word = word });
        }
    }

    public void HideRandomWords(int count)
    {
        var rand = new Random();
        for (int i = 0; i < count; i++)
        {
            Words[rand.Next(Words.Count)].IsHidden = true;
        }
    }

    public bool AllWordsHidden => Words.TrueForAll(w => w.IsHidden);

    public override string ToString()
    {
        return $"{Reference} - " + string.Join(" ", Words.Select(w => w.IsHidden ? "___" : w.Word));
    }
}