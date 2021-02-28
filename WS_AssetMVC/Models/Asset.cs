using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WS_AssetMVC.Models
{
    public class Assets
    {
        private List<Asset> _LAsset = new List<Asset>();

        public List<Asset> LAsset { get => _LAsset; set => _LAsset = value; }

        public class Asset
        {
            public int Asset_ID { get; set; }
            public string Asset_Name { get; set; }
            public string Asset_Serail { get; set; }
            public string Asset_Number { get; set; }
            public string Asset_Datebuy { get; set; }
            public string Users { get; set; }
        }        
    }
    public class AssetId
    {
        private List<AssetByID> _LAssetById = new List<AssetByID>();

        public List<AssetByID> LAssetById { get => _LAssetById; set => _LAssetById = value; }

        public class AssetByID
        {
            public int asset_ID { get; set; }
            public string asset_Name { get; set; }
            public string asset_Serial { get; set; }
            public int type_ID { get; set; }
            public string asset_Datebuy { get; set; }
            public string asset_Waranty { get; set; }
            public string asset_Price { get; set; }
            public string asset_Supply { get; set; }
            public int user_ID { get; set; }
            public int admin_ID { get; set; }
            public string asset_Number { get; set; }
            public string asset_Modify { get; set; }
        }
    }

}
