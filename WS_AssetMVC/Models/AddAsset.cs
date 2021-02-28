using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WS_AssetMVC.Models
{
    public class AddAsset
    {        
            public int Asset_ID { get; set; }
            public string Asset_Name { get; set; }
            public string Asset_Serail { get; set; }
            public string Asset_Number { get; set; }
            public string Asset_Datebuy { get; set; }
            public string Users { get; set; }
        
    }

    public class NewAsset
    {
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
    public class AssetID
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
