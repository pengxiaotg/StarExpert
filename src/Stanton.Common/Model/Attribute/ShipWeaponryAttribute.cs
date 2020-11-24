using System.Collections.Generic;

namespace Stanton.Common.Attribute
{
    public class ShipWeaponryAttribute
    {
        public string Name { get; set; }    // For Missiles it means default rack name
        public int Size { get; set; }
        public int Count { get; set; }
        public List<string> Mount { get; set; }
    }
}
