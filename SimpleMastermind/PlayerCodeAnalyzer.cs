using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleMastermind
{
    public static class PlayerCodeAnalyzer
    {
        public static char[] GenerateAnswer(int[] masterCode, int[] codeBreakerCode)
        {
            var answer = new char[4];
            for (int s = 0; s <= 3; s++)
            {
                var codeSeg = codeBreakerCode[s];
                if (masterCode.Contains(codeBreakerCode[s]))
                {
                    if (masterCode[s] == codeBreakerCode[s])
                    {
                        // response code is present in fullCode in right position
                        answer[s] = '+';
                    }
                    else
                    {
                        // response code is present in fullCode in wrong position
                        answer[s] = '-';
                    }
                }
            }

            return answer;
        }
    }
}
