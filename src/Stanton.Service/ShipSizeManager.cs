using System;
using System.Collections.Generic;
using System.Text;

namespace Stanton.Service
{
    public class ShipSizeManager
    {
        public static int GetSizeSocre(string size)
        {
            switch(size)
            {
                case "Snub": return 0;
                case "Small": return 1;
                case "Medium": return 2;
                case "Large": return 3;
                case "Capital": return 4;
                default: return 10;
            }
        }
    }
}
