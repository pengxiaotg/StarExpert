using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stanton.App.Model
{
    public class ShipManifacturer : IEquatable<ShipManifacturer>
    {
        public string Name { get; set; }
        public string Icon { get; set; }

        public bool Equals(ShipManifacturer other)
        {
            return Name == other.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
