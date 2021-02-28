using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WS_AssetMVC.Models.UploadForm
{
    public class Allemploye
    {
        private List<Employe> _LEmploye = new List<Employe>();
        public List<Employe> LEmploye { get => _LEmploye; set => _LEmploye = value; }

        public class Employe
        {
            public int id { get; set; }
            public string firstname { get; set; }
            public string lastname { get; set; }
            public string department { get; set; }
            public string filename { get; set; }
            public string filepath { get; set; }
        }
    }
    
}
