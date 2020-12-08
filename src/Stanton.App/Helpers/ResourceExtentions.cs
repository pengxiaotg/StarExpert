using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;

namespace Stanton.App.Helpers
{
    internal static class ResourceExtentions
    {
        private static ResourceLoader _resourceLoader = new ResourceLoader();
        public static string GetLocalized(this string resourceKey)
        {
            return _resourceLoader.GetString(resourceKey);
        }
    }
}
