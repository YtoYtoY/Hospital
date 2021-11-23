using System;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;
using System.Text;

namespace Hospital
{
    public static class Settings
    {
        public static ResourceManager Resources { get; set; }
        public static CultureInfo Lang { get; set; }
    }
}
