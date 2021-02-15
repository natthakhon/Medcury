using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Medury
{
    public class Lines
    {
        private string content;
        public Lines(string content)
        {
            this.content = content;
        }

        private List<Line> getLines()
        {
            List<string> info = this.content.Split('\n').ToList();
            List<Line> listline = new List<Line>();
            foreach(string s in info)
            {
                listline.Add(new Line(s));
            }
            return listline;
        }

        public string GetResult(string phone)
        {
            List<Line> lines = this.getLines();
            if (lines.Where(p => p.Phone == phone).Count() > 1)
            {
                return "Error => Too many people at " + phone;
            }
            else if (lines.Where(p => p.Phone == phone).Count() == 1)
            {
                return lines.FirstOrDefault(p => p.Phone == phone).ToString();
            }

            return "No record found";
        }

        public Line GetLine(string phone)
        {
            List<Line> lines = this.getLines();
            if (lines.Where(p => p.Phone == phone).Count() > 1)
            {
                throw new Exception("More than one record found");
            }
            else if (lines.Where(p => p.Phone == phone).Count() == 1)
            {
                return lines.FirstOrDefault(p => p.Phone == phone);
            }

            throw new Exception("No record found");
        }

    }
}
