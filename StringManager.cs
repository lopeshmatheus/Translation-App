using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace TranslationApp
{
    static public class StringManager
    {
        // static public string RemoveSpecialChars(string book)
        // {
            
        //     return Regex.Replace(book, "[^a-zA-Z0-9 ]+!:…", "", RegexOptions.Compiled);
        // }
        public static string RemoveSpecialChars(string book)
        {
            book = new string((from c in book
                              where char.IsWhiteSpace(c) || char.IsLetterOrDigit(c)
                              select c
       ).ToArray());
            book = Regex.Replace(book, @"\s+", " ");


            return book;
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
        public static List<string> RankItems(List<string> wordList)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();

            for (int i = 0; i < wordList.Count; i++)
            {
                if (!dic.ContainsKey(wordList[i]))
                {
                    dic.Add(wordList[i], 1);
                }
                else if (dic.ContainsKey(wordList[i]))
                {
                    dic[wordList[i]]++;
                }
            }

            var sortedDict = from entry in dic orderby entry.Value descending select entry;
            var newDict = sortedDict.ToDictionary<KeyValuePair<string, int>, string, int>(pair => pair.Key, pair => pair.Value);
            var sortedList = newDict.Select(kvp => kvp.Key).ToList();
            return sortedList;

        }
        public static IEnumerable<T> TakePercent<T>(this ICollection<T> source, double percent)
        {
            int count = (int)(source.Count * percent / 100);
            return source.Take(count);
        }
        public static List<string> DeletePercent(List<string> list)
        {
            var topPercentList = TakePercent(list, 5);
            List<string> newList = new List<string>();
            list.RemoveRange(0, topPercentList.Count());
            return list;
        }
        public static List<string> ReturnMinusOnePercent(List<string> list )
        {
            var newList = DeletePercent(list);                   
            return newList;
        }


    }
    
}