﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.Enums
{
    public enum Title
    {
        [Description("Mr")]
        Mr = 1,

        [Description("Mrs")]
        Mrs,

        [Description("Miss")]
        Miss,

        [Description("Dr")]
        Dr
    }
}
