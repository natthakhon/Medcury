using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Medury
{
    public class Line
    {
        private string line;
        private List<string> fractions = new List<string>();
        private string firstname = string.Empty;
        private string lastname = string.Empty;
        private string fullname = string.Empty;
        private string phone = string.Empty;
        private string address = string.Empty;

        public Line(string line)
        {
            this.line = line;
            this.extract();
        }

        public string InputString
        {
            get { return this.line; }
        }

        public string Name
        {
            get 
            {
                if (string.IsNullOrEmpty(this.fullname))
                {
                    return String.Format("{0} {1}", firstname, lastname);
                }
                else{
                    return String.Format("{0}", fullname);
                }
                 
            }
        }

        public string Address
        {
            get
            {
                return this.address;
            }
        }

        public string Phone
        {
            get
            {
                return this.phone;
            }
        }

        public override string ToString()
        {
            return string.Format("Phone => {0} Name => {1} Address => {2}", this.Phone, this.Name, this.Address);
        }

        public List<string> Fractions
        {
            get
            {
                if (this.fractions.Count == 0)
                {
                    this.fractions = this.line.Split(' ').ToList();
                    this.fractions.Remove(string.Empty);
                }
                return this.fractions;
            }
        }

        private void extract()
        {               
            foreach(string fraction in this.Fractions)
            {
                LineFraction lineFraction = new LineFraction(fraction);
                Dictionary<fractionType, string> lineResult = lineFraction.GetResult();
                if (lineResult.ContainsKey(fractionType.Address))
                {
                    address = address + " " + lineResult.FirstOrDefault().Value; 
                }
                else if (lineResult.ContainsKey(fractionType.Phone))
                {
                    phone = phone + lineResult.FirstOrDefault().Value;
                }
                else if (lineResult.ContainsKey(fractionType.FullName))
                {
                    fullname = lineResult.FirstOrDefault().Value;
                }
                else if (lineResult.ContainsKey(fractionType.FirstName))
                {
                    firstname = lineResult.FirstOrDefault().Value;
                }
                else if (lineResult.ContainsKey(fractionType.LastName))
                {
                    lastname = lineResult.FirstOrDefault().Value;
                }
                else
                {
                    throw new ArgumentException("Unrecognized type");
                }
            }
        }
    }
}
