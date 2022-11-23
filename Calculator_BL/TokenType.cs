using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_BL
{
    internal enum TokenType
    {
        Empty,
        Number,
        Operation,
        OpenedBracket,
        ClosedBracket
    }
}
