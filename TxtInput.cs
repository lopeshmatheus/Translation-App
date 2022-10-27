using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TranslationApp
{
    static public class TxtInput
    {
        static public string GetTxt()
        {
            return File.ReadAllText("Books/LePetitPrince.txt");
;        }
    }
}