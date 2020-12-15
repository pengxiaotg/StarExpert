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
        public ObservableCollection<ShipItem> Source = new ObservableCollection<ShipItem>();
        
        public void LoadData()
        {
            Source.Clear();
            var data = ShipManager.GetAllShips();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Ship, ShipItem>());
            var mapper = config.CreateMapper();
            foreach (var item in data)
            {
                Source.Add(mapper.Map<ShipItem>(item));
            }
        }
    }
}
