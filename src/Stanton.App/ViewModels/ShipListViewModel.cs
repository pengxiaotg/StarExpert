using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Stanton.Common.Entity;
using Stanton.App.Services;
using Stanton.Service;

namespace Stanton.App.ViewModels
{
    public class ShipListViewModel : ObservableObject
    {
        public ObservableCollection<Ship> Source = new ObservableCollection<Ship>();

        public async Task LoadDataAsync()
        {
            Source.Clear();
            await DataLoadService.LoadShipDataAsync();
            var data = ShipManager.GetAllShips();
            foreach(var item in data)
            {
                Source.Add(item);
            }
        }

        private void OnItemSelected(ItemClickEventArgs args)
        {
        }
    }
}
