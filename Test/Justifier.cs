using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace TestJustifier
{
    public class Justifier:IJustifier
    {
        const char Space = ' ';
        public string Justify(string[] x, int l)
        {
            if (x.Length == 1)
                return GetJustifyStringForLine(x[0], l);
            else
            {
                return GetJustifyStringMultyLine(x, l);
            }
        }

        private string GetJustifyStringMultyLine(string[] x,  int l)
        {
            var lengthCount = SetSpace(x);
            if (lengthCount >= l) return string.Join(string.Empty, x);
            else
            {
                return GetNormalizeJustifyString(x, l, lengthCount);
            }
        }

        private string GetNormalizeJustifyString(string[] x,int l, int lengthCount)
        {
            int i = 0;
            while (lengthCount!=l)
            {
                if (i == x.Length - 1)
                {
                    i = 0;
                }
                else
                {
                    x[i] += Space;
                    i++;
                    lengthCount++;
                }
            }
            return String.Join(String.Empty,x);
        }

        private int  SetSpace(string[] x)
        {
            int summarySize = 0,i;
            for (i = 0; i < x.Length-1; i++)
            {
                x[i] += Space;
                summarySize += x[i].Length;
            }

            summarySize += x[i].Length;
            return summarySize;
        }

        private string GetJustifyStringForLine(string s, int l)
        {
            return s + new string(Space,l>s.Length ? l-s.Length : 0);
        }
    }
}