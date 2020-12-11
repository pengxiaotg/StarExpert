using Stanton.Common.Entity;
using Stanton.App.Helpers;

namespace Stanton.App.Model
{
    public class ShipItem : Ship
    {
        public string AllRole
        {
            get => string.Join(" / ", Role);
        }

        public string PreviewImageSource
        {
            get => $"ms-appx:///Assets/images/ship/{Name}/1.jpeg";
        }

        public string PriceText
        {
            get => $"${PledgePrice}";
        }

        public string ManufacturerIcon
        {
            get => ManufacturerHelper.GetIcon(Manufacturer);
        }
    }
}
