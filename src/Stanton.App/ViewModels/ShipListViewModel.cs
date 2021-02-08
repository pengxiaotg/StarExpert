using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using AutoMapper;
using Stanton.Common.Entity;
using Stanton.Service;
using Stanton.App.Model;

namespace Stanton.App.ViewModels
{
    public class ShipListViewModel : ObservableObject
    {
        public ObservableCollection<ShipItem> ShipSource = new ObservableCollection<ShipItem>();
        public ObservableCollection<ShipManifacturer> ManifactureSource = new ObservableCollection<ShipManifacturer>();
        public ObservableCollection<string> AutoSuggestionSource = new ObservableCollection<string>();
        private readonly List<ShipItem> _ships = new List<ShipItem>();

        public async Task LoadDataAsync()
        {
            var data = ShipManager.GetAllShips();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Ship, ShipItem>());
            var mapper = config.CreateMapper();

            foreach (var ship in data)
            {
                var shipItem = mapper.Map<ShipItem>(ship);
                _ships.Add(shipItem);
            }
            await SetSource(_ships);
            LoadManifacturer();
        }

        public async Task UpdateDataAsync(ShipFilter filter)
        {
            IEnumerable<ShipItem> ships = _ships;
            if (filter.IsFlightReady)
                ships = ships.Where(x => x.FlightReady == true);
            if (filter.Mainfacturer != null)
                ships = ships.Where(x => x.Manufacturer == filter.Mainfacturer);
            if (filter.Size != null)
                ships = ships.Where(x => x.Size == filter.Size);
            if (filter.Sort == "Name")
                ships = ships.OrderBy(x => x.Name);
            else if (filter.Sort == "Size")
                ships = ships.OrderBy(x => ShipSizeManager.GetSizeSocre(x.Size));
            else if (filter.Sort == "Price")
                ships = ships.OrderBy(x => x.PledgePrice);
            if (filter.SearchText != string.Empty)
                ships = ships.Where(x => x.Name.Contains(filter.SearchText, StringComparison.OrdinalIgnoreCase));
            await SetSource(ships);
        }

        public void UpdateAutoSuggestionSource(string searchText)
        {
            AutoSuggestionSource.Clear();
            var names = _ships.Where(x => x.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase)).Select(x => x.Name);
            if (names.Count() == 0)
                AutoSuggestionSource.Add("No results found");
            foreach(var name in names)
            {
                AutoSuggestionSource.Add(name);
            }
        }

        private void LoadManifacturer()
        {
            ManifactureSource.Add(new ShipManifacturer() { Name = "All", Icon = "" });
            var manifacturers = _ships.Select(x => new ShipManifacturer { Name = x.Manufacturer, Icon = x.ManufacturerIcon }).Distinct();
            foreach (var manifacturer in manifacturers)
            {
                ManifactureSource.Add(manifacturer);
            }
        }

        private async Task SetSource(IEnumerable<ShipItem> data)
        {
            ShipSource.Clear();
            int i = 0;
            foreach (var ship in data)
            {
                ShipSource.Add(ship);
                // optimize page loading time
                if (i > 40)
                    await Task.Delay(10);
                i++;
            }
        }
    }



    public class ShipFilter
    {
        public bool IsFlightReady { get; set; }
        public string Mainfacturer { get; set; }
        public string Size { get; set; }
        public string Sort { get; set; }
        public string SearchText { get; set; }
    }
}
