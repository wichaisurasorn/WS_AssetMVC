using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WS_AssetMVC.Models
{
    public class EmployeModels
    {
        private List<Employes> _LEmploye = new List<Employes>();

        public List<Employes> LEmploye { get => _LEmploye; set => _LEmploye = value; }

        public class Employes
        {
            public int user_ID { get; set; }
            public string user_Fristname { get; set; }
            public string user_Lastname { get; set; }
            public string user_Department { get; set; }
            public int user_Level { get; set; }
            public int user_Status { get; set; }
            public string createDate { get; set; }
            public string dateModify { get; set; }
            public string user_Username { get; set; }
            public string user_Password { get; set; }

        }
    }

    public class EmpleyeGet
    {
        public int user_ID { get; set; }
        public string user_Fristname { get; set; }
        public string user_Lastname { get; set; }
        public string user_Department { get; set; }
        public int user_Level { get; set; }
        public int user_Status { get; set; }
        public string createDate { get; set; }
        public string dateModify { get; set; }
        public string user_Username { get; set; }
        public string user_Password { get; set; }
    }

    public class AddEmploye
    {        
        public string user_Fristname { get; set; }
        public string user_Lastname { get; set; }
        public string user_Department { get; set; }
        public int user_Level { get; set; }
        public int user_Status { get; set; }
        public string createDate { get; set; }
        public string dateModify { get; set; }
        public string user_Username { get; set; }
        public string user_Password { get; set; }
    }
}
