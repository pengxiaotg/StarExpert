using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using Windows.UI.Xaml;
using Stanton.Common.Enum;

namespace Stanton.App.Helpers
{
    public class ManufacturerHelper
    {
        public static string GetIcon(string manufacturer)
        {
            switch (manufacturer)
            {
                case "Crusader Industries":
                    return Application.Current.Resources["CrusaderIndustriesIcon"] as string;
            }
            return "";
        }
    }
}
