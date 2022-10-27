using TranslationApp;


StringManager.GetRawSentences();

var sentences = StringManager.SentencesGetter(StringManager.GetRawSentences());

foreach(string word in sentences)
{
    System.Console.WriteLine(word);
}

File.WriteAllLines("Books/LePetitPrinceSentences.txt", sentences);


