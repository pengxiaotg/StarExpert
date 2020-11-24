using System.Collections.Generic;
using Stanton.Common.Attribute;

namespace Stanton.Common.Entity
{
    public class Ship
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        public List<string> Role { get; set; }
        public int MinCrew { get; set; }
        public int MaxCrew { get; set; }
        public decimal? CargoCapacity { get; set; }
        public bool FlightReady { get; set; }
        public decimal? PledgePrice { get; set; }
        public string Availability { get; set; }
        public decimal Length { get; set; }
        public decimal Beam { get; set; }
        public decimal Height { get; set; }
        public decimal CombatSpeed { get; set; }
        public decimal MaxSpeed { get; set; }
        public Dictionary<string, ShipComponentAttribute> Component { get; set; }
        public Dictionary<string, List<ShipWeaponryAttribute>> Weaponry { get; set; }
        public string ModelUid { get; set; }
    }
}
