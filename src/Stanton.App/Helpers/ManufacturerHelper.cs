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
            var resource = Application.Current.Resources;
            return manufacturer switch
            {
                "Aegis Dynamics" => resource["AegisIcon"] as string,
                "Anvil Aerospace" => resource["AnvilIcon"] as string,
                "Aopoa" => resource["AopoaIcon"] as string,
                "Argo Astronautics" => resource["ArgoIcon"] as string,
                "Banu Souli" => resource["BanuIcon"] as string,
                "Consolidated Outland" => resource["ConsolidatedOutlandIcon"] as string,
                "Crusader Industries" => resource["CrusaderIcon"] as string,
                "Drake Interplanetary" => resource["DrakeIcon"] as string,
                "Esperia" => resource["EsperiaIcon"] as string,
                "Kruger Intergalactic" => resource["KrugerIcon"] as string,
                "Musashi Industrial and Starflight Concern" => resource["MISCIcon"] as string,
                "Origin Jumpworks" => resource["OriginIcon"] as string,
                "Roberts Space Industries" => resource["RSIIcon"] as string,
                "Vanduul Clans" => resource["VanduulClansIcon"] as string,
                _ => resource["ShipIcon"] as string
            };
        }
    }
}
