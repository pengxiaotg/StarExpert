using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stanton.Service;

namespace Stanton.App.Services
{
    class DataLoadService
    {

        public static async void LoadFromDataAsync()
        {
            await LoadShipDataAsync();
        }

        public static async Task LoadShipDataAsync()
        {
            var path = "ms-appx:///Data/Ships.json";
            using (StreamReader r = new StreamReader(path))
            {
                string json = await r.ReadToEndAsync();
                ShipManager.SetSourceData(json);
            }
        }
    }
}
