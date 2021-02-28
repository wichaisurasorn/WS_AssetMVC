using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WS_AssetMVC.Services
{

    public class Parameters
    {
        private string _Name;
        private string _Value;

        public string Name { get => _Name; set => _Name = value; }
        public string Value { get => _Value; set => _Value = value; }

    }
}
