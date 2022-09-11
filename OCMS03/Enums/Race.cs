using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.Enums
{
    public enum Race
    {
        [Description("Black")]
        Black = 1,

        [Description("Colored")]
        Colored,

        [Description("Idian")]
        Idian,

        [Description("White")]
        White
    }
}
