using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WS_AssetMVC.Services
{
    public class ApiRequest
    {


        public class ApiParameter
        {
            private string _Name;
            private string _Value;

            public string Name
            {
                get
                {
                    return _Name;
                }

                set
                {
                    _Name = value;
                }
            }

            public string Value
            {
                get
                {
                    return _Value;
                }

                set
                {
                    _Value = value;
                }
            }
        }
    }
}
