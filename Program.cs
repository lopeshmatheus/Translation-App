using TranslationApp;


var wordList = TxtInput.stringToList(StringManager.RemoveSpecialChars(TxtInput.GetTxt()));
var rankedWords = StringManager.RankItems(wordList);
rankedWords = StringManager.DeletePercent(rankedWords);

var finalList = StringManager.TakePercent(rankedWords, 3).ToList();

string path = "Books/LePetitPrince-Sentences-FR.txt";
List<string> sentencesList = File.ReadAllLines(path).ToList();
List<string> finalSentenceList = new List<string>();


for (int i = 0; i < sentencesList.Count; i++)
{
    for (int j = 0; j < finalList.Count; j ++)
    {
        if (sentencesList[i].Contains(finalList[j]))
        {
            if (!finalSentenceList.Contains(sentencesList[i]))
            {
                finalSentenceList.Add(sentencesList[i]);
                finalList.Remove(finalList[j]);
            }
        }
    }
}

foreach(string sentence in finalSentenceList)
{
    System.Console.WriteLine(sentence);
}
System.Console.WriteLine(finalList.Count);
System.Console.WriteLine(finalSentenceList.Count);





//var translatedSentencesString = Translation.TranslateText(originalSentencesString, "fr");

//List<string> translatedSentecesList = translatedSentencesString.Split(Environment.NewLine).ToList();

//FileManager.CsvExport(originalSentencesList, translatedSentecesList);

//File.WriteAllLines("Books/results.txt", originalSentencesList);




