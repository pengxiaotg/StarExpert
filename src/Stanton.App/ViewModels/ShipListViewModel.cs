using System.Collections.ObjectModel;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using AutoMapper;
using Stanton.Common.Entity;
using Stanton.Service;
using Stanton.App.Model;
using System.Threading.Tasks;

namespace Stanton.App.ViewModels
{
    public class ShipListViewModel : ObservableObject
    {
        public ObservableCollection<ShipItem> Source = new ObservableCollection<ShipItem>();

        public async Task LoadDataAsync()
        {
            Source.Clear();
            var data = ShipManager.GetAllShips();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Ship, ShipItem>());
            var mapper = config.CreateMapper();
            int i = 0;
            foreach (var ship in data)
            {
                var shipItem = mapper.Map<ShipItem>(ship);
                Source.Add(shipItem);
                // just magic
                if (i >= 20)
                {
                    await Task.Delay(50);
                }
                i++;
            }
        }
    }
}
