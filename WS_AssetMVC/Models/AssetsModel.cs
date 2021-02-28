using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WS_AssetMVC.Models
{
    public class AssetsModel
    {
        private List<AllAssets> _LAssets = new List<AllAssets>();

        public List<AllAssets> LAssets { get => _LAssets; set => _LAssets = value; }

        public class AllAssets        {
            public int asset_ID { get; set; }
            public string asset_Name { get; set; }
            public string asset_Serial { get; set; }
            public int Type_ID { get; set; }
            public string asset_Datebuy { get; set; }
            public string asset_Waranty { get; set; }
            public string asset_Price { get; set; }
            public string asset_Supply { get; set; }
            public int User_ID { get; set; }
            public int Admin_ID { get; set; }
            public string asset_Number { get; set; }
            public string asset_Modify { get; set; }
        }

    }

    public class Assetlist
    {
        public int asset_ID { get; set; }
        public string asset_Name { get; set; }
        public string asset_Serial { get; set; }
        public int Type_ID { get; set; }
        public string asset_Datebuy { get; set; }
        public string asset_Waranty { get; set; }
        public string asset_Price { get; set; }
        public string asset_Supply { get; set; }
        public int User_ID { get; set; }
        public int Admin_ID { get; set; }
        public string asset_Number { get; set; }
        public string asset_Modify { get; set; }
    }
}
