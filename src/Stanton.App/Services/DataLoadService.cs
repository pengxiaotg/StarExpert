using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stanton.Service;
using Windows.Storage;

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
            var filepath = @"Data\Ships.json";
            StorageFolder folder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            StorageFile file = await folder.GetFileAsync(filepath); // error here
            using (var inputStream = await file.OpenReadAsync())
            using (var classicStream = inputStream.AsStreamForRead())
            using (var streamReader = new StreamReader(classicStream))
            {
                var json = await streamReader.ReadToEndAsync();
                ShipManager.SetSourceData(json);
            }
        }
    }
}
