using Stanton.Common.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stanton.Common.Entity
{
    public class GameItem
    {
        public GameItemType BaseType { get; set; }
        public List<LocationBuyingPrice> LocationBuyingPrices { get; set; }
    }
}
