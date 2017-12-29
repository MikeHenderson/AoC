using System.Collections.Generic;
using System.Linq;

namespace Chownus.AoC.Console._2017._25
{
    public class Solution : IAoCSolution
    {
        public int Day => 25;
        public int Year => 2017;

        public string RunPart1(IEnumerable<string> testData)
        {
            var performChecksumAt = 12261543;
            var currentState = 'a';

            var states = new Dictionary<int, int> {{0, 0}};
            var index = 0;

            while (performChecksumAt > 0)
            {
                if(!states.ContainsKey(index)) states.Add(index, 0);

                switch (currentState)
                {
                    case 'a':
                        if (states[index] == 0)
                        {
                            states[index] = 1;
                            index++;
                            currentState = 'b';
                        }
                        else
                        {
                            states[index] = 0;
                            index--;
                            currentState = 'c';
                        }

                        break;
                    case 'b':

                        if (states[index] == 0)
                        {
                            states[index] = 1;
                            index--;
                            currentState = 'a';
                        }
                        else
                        {
                            index++;
                            currentState = 'c';
                        }
                        break;
                    case 'c':
                        if (states[index] == 0)
                        {
                            states[index] = 1;
                            index++;
                            currentState = 'a';
                        }
                        else
                        {
                            states[index] = 0;
                            index--;
                            currentState = 'd';
                        }
                        break;
                    case 'd':
                        currentState = states[index] == 0 ? 'e' : 'c';
                        states[index] = 1;
                        index--;
                        break;
                    case 'e':
                        currentState = states[index] == 0 ? 'f' : 'a';
                        states[index] = 1;
                        index++;
                        break;
                    case 'f':
                        currentState = states[index] == 0 ? 'a' : 'e';
                        states[index] = 1;
                        index++;
                        break;
                }

                performChecksumAt--;
            }

            return states.Count(x => x.Value == 1).ToString();
        }

        public string RunPart2(IEnumerable<string> testData)
        {
            return "Go deposit those stars for Santa!!!";
        }
    }
}