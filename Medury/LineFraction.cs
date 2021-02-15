using System;
using System.Collections.Generic;
using System.Text;

namespace Medury
{
    public class LineFraction
    {
        private string fraction;
        private Dictionary<fractionType, string> fractionDict = new Dictionary<fractionType, string>();

        public LineFraction(string fraction)
        {
            this.fraction = fraction;
        }

        public Dictionary<fractionType,string> GetResult()
        {
            fractionType fractionType = this.getFractionType();
            this.fractionDict.Add(fractionType, this.getFinalString(fractionType));
            return this.fractionDict;
        }

        private fractionType getFractionType()
        {
            char[] fractionCharArray = this.fraction.ToCharArray();
            bool firstname = false;
            bool lastname = false;
            foreach (char c in fractionCharArray)
            {
                if (c.Equals('<'))
                {
                    firstname = true;
                    continue;
                }
                else if (c.Equals('>'))
                {
                    lastname = true;
                    continue;
                }
                else if (c.Equals('+'))
                {
                    return fractionType.Phone;
                }
            }

            if (firstname && lastname)
            {
                return fractionType.FullName;
            }
            else if (firstname)
            {
                return fractionType.FirstName;
            }
            else if (lastname)
            {
                return fractionType.LastName;
            }

            return fractionType.Address;
        }

        private string getFinalString(fractionType fractionType)
        {
            char[] fractionCharArray = this.fraction.ToCharArray();
            string finalstring = string.Empty;

            if (fractionType == fractionType.FirstName)
            {
                foreach (char c in fractionCharArray)
                {
                    if (!c.Equals('<')){
                        finalstring = finalstring + c.ToString();
                    }
                }
            }
            else if (fractionType == fractionType.LastName)
            {
                foreach (char c in fractionCharArray)
                {
                    if (!c.Equals('>'))
                    {
                        finalstring = finalstring + c.ToString();
                    }
                }
            }
            else if (fractionType == fractionType.FullName)
            {
                foreach (char c in fractionCharArray)
                {
                    if (!c.Equals('>') && !c.Equals('<'))
                    {
                        finalstring = finalstring + c.ToString();
                    }
                }
            }
            else if (fractionType == fractionType.Phone)
            {
                foreach (char c in fractionCharArray)
                {
                    if (c.Equals('-'))
                    {
                        finalstring = finalstring + c.ToString();
                    }
                    else if (int.TryParse(c.ToString(),out int cInt))
                    {
                        finalstring = finalstring + cInt.ToString();
                    }
                }
            }
            else if(fractionType == fractionType.Address)
            {
                finalstring = finalstring + this.fraction.Trim();
            }
            else
            {
                throw new ArgumentException("Unreconized Type");
            }

            return finalstring;
        }
    }

    public enum fractionType { Address,Phone,FirstName,LastName,FullName}
}
