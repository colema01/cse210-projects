public class ScriptureReference
{
    public string Book { get; private set; }
    public int Chapter { get; private set; }
    public int? VerseStart { get; private set; }
    public int? VerseEnd { get; private set; }

    public ScriptureReference(string book, int chapter, int verse)
    {
        Book = book;
        Chapter = chapter;
        VerseStart = verse;
    }

    public ScriptureReference(string book, int chapter, int verseStart, int verseEnd)
        : this(book, chapter, verseStart)
    {
        VerseEnd = verseEnd;
    }

    public override string ToString()
    {
        return VerseEnd.HasValue ? $"{Book} {Chapter}:{VerseStart}-{VerseEnd}" : $"{Book} {Chapter}:{VerseStart}";
    }
}