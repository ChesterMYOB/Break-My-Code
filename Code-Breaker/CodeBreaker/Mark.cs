using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBreaker
{
    public enum Mark
    {
        Black = 'b',
        White = 'w'
    }

    public static class MarkExtension
    {
        public static string AsString(this Mark mark)
        {
            return ((char)mark).ToString();
        }
    }
}
