using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_13
{
    public static class StringExtensions
    {
        public static bool ContainsAny(this string text , IEnumerable<string> keywords)
        {
            return keywords.Any(keyword => text.Contains(keyword));
        }
    }
}
