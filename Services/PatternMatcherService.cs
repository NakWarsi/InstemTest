using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstemTest.Services
{
    public class PatternMatcherService
    {
        public bool IfPatternExist(string patternArg, string txtArg)
        {

            var txt = txtArg.ToUpper();
            var pattern = patternArg.ToUpper();
            int patternLength = pattern.Length;
            int textLength = txt.Length;
            int textIndex = 0;

            while (textIndex <= textLength - patternLength)
            {
                int currentIndex;
                for (currentIndex = 0; currentIndex < patternLength; currentIndex++)
                {
                    if (txt[textIndex + currentIndex] != pattern[currentIndex])
                        break;
                }

                if (currentIndex == patternLength)
                {
                    return true;
                }
                else if (currentIndex == 0)
                    textIndex = textIndex + 1;
                else
                    textIndex = textIndex + currentIndex;
            }
            return false;
        }
    }
}
