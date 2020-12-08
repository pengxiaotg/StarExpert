using System.Collections.Generic;

namespace Stanton.Common.Entity
{
    public class Location
    {
        public List<string> Address { get; set; }

        public string FullAddress
        {
            get => string.Join("-", Address);
        }
    }
}
