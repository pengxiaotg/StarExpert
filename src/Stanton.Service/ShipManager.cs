using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Stanton.Common.Entity;
using Stanton.Common.Util;
using Serilog;
namespace Stanton.Service
{
    public class ShipManager
    {
        private static ICollection<Ship> _ships;

        public static async void SetSourceData(string json)
        {
            try
            {
                _ships = await Json.ToObjectAsync<List<Ship>>(json);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
            }
        }
    }
}
