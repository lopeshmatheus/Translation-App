using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace TranslationApp
{
    static public class StringManager
    {
        static public string RemoveSpecialChars(string book)
        {
            
            return Regex.Replace(book, "[^a-zA-Z0-9 ]+!:…", "", RegexOptions.Compiled);
        }

        static public String RemoveNewLines(string book)
        {
            return Regex.Replace(book, @"[\r\n]+", Environment.NewLine);

        }
                static public List<string> RawSentenceGetter(string bookString)
        {        
            List<String> bookSentences = bookString.Split(Environment.NewLine).ToList();
            return bookSentences;
                    
        }
        static public List<string> GetRawSentences()
        {
            return RawSentenceGetter(RemoveNewLines(RemoveSpecialChars(TxtInput.GetTxt())));
        }

        static public List<String> SentencesGetter(List<string> bookRawLines)
        {
            List<string> sentences = new List<string>();
            
            for (int i = 0; i < bookRawLines.Count; i++)
            {
                
                int startingIndex = 0;
                int endingIndex = 0;
                

                for(int j = 0; j < bookRawLines[i].Length; j++)
                {
                    if (j != 0)
                    {
                        if (bookRawLines[i][j] == ',' || bookRawLines[i][j] == '.' || bookRawLines[i][j] == ':' || bookRawLines[i][j] == '?' || bookRawLines[i][j] == '—' )
                        {
                        endingIndex = j;
                        string currentSubstring = (bookRawLines[i].Substring(startingIndex, endingIndex - startingIndex)).Trim();
                        char.ToUpper(currentSubstring[0]);
                        sentences.Add(currentSubstring);
                        bookRawLines[i].Remove(startingIndex, endingIndex - startingIndex);
                        startingIndex = endingIndex + 1;
                        continue;
                        }
                    }
                                                      
                }


            }

            return sentences;
        }

        public static List<string> ShortenSentences(List<string> sentences)
        {
            var newSentencesList = new List<string>();

            for (int i = 0; i <sentences.Count; i++)
            {
                int wordCount = 0;
                for (int j = 0; j < sentences[i].Count(); j++)
                {
                    if(sentences[i][j] == ' ')
                    {
                        wordCount++;
                    }

                }
                if (wordCount > 2)
                {
                    newSentencesList.Add(sentences[i]);
                }
            }
            return newSentencesList;
        }

    }
    
}