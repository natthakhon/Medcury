using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Medury
{
    public class WUBRemover
    {
        private string input;
        private List<int> removeTargetIndex = new List<int>();

        public WUBRemover(string input)
        {
            this.input = input;
        }

        private void getTargetIndex()
        {
            List<char> chars = this.input.ToCharArray().ToList();
            for(int i =0; i< chars.Count; i++)
            {
                if (chars[i].ToString() == "W" && 
                    chars[i+1].ToString() == "U" &&
                    chars[i+2].ToString() == "B")
                {
                    this.removeTargetIndex.Add(i);
                }                    
            }
        }

        public string GetResult()
        {
            string result = string.Empty;
            this.getTargetIndex();
            List<char> chars = this.input.ToCharArray().ToList();
            for (int i = 0; i < chars.Count; i++)
            {
                IEnumerable<int> index = this.removeTargetIndex.Where(p => p == i);
                if (index.Count() > 0)
                {
                    result = result + ' ';
                    i = i + 2;                        
                }
                else
                {
                    result = result + chars[i].ToString();
                }
            }

            string final = string.Empty;
            List<char> resultChars = result.ToCharArray().ToList();
            for (int i = 0; i < resultChars.Count; i++)
            {
                if (resultChars[i].ToString() != " ")
                {
                    final = final + resultChars[i].ToString();
                }
                else
                {
                    for (int j = i+1; j < resultChars.Count; j++)
                    {
                        if (resultChars[j].ToString() == " ")
                        {
                            continue;
                        }
                        else
                        {
                            i = j - 1;
                            final = final + " ";
                            break;
                        }
                    }
                }
            }

            return final.TrimStart().TrimEnd();
        }
    }
}
