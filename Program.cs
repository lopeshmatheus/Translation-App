using TranslationApp;


StringManager.GetRawSentences();

var sentences = StringManager.ShortenSentences(StringManager.SentencesGetter(StringManager.GetRawSentences()));

foreach(string word in sentences)
{
    System.Console.WriteLine(word);
}




