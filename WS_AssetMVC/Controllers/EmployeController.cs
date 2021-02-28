using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WS_AssetMVC.Datas;
using WS_AssetMVC.Models;
using WS_AssetMVC.Services;
using static WS_AssetMVC.Services.ApiRequest;

namespace WS_AssetMVC.Controllers
{
    public class EmployeController : Controller
    {
        public IActionResult EmployeIndex()
        {
            return View();
        }
        public IActionResult EmployesView()
        {
            return View();
        }


        //Show AllEmploye
        public IActionResult showEmploye()
        {
            EmployeModels employe = new EmployeModels();
            WebClient client = new WebClient();
            client.UseDefaultCredentials = true;
            client.Headers[HttpRequestHeader.ContentType] = "application/x-www-from-urlencoded";

            string Parameter = string.Empty;
            int PLenght = 0;

            List<Parameters> lpt = new List<Parameters>();

            var Url = "https://localhost:44351/api/Users/Users";
            var Response = "";

            foreach(var p in lpt)
            {
                if (PLenght == 0) Parameter += "?" + p.Name + "=" + p.Value;
                else Parameter += "&" + p.Name + "=" + p.Value;
                PLenght++;
            }
            string FinalUrl = Url + Parameter;
            var responsedata = client.DownloadData(FinalUrl);
            Response = UnicodeEncoding.UTF8.GetString(responsedata);

            List<EmpleyeGet> LemployeGet = (List<EmpleyeGet>)JsonConvert.DeserializeObject(Response, typeof(List<EmpleyeGet>));
            employe.LEmploye = new List<EmployeModels.Employes>();

            foreach(var item in LemployeGet)
            {
                EmployeModels.Employes emp = new EmployeModels.Employes();
                emp.user_ID = item.user_ID;
                emp.user_Fristname = item.user_Fristname;
                emp.user_Lastname = item.user_Lastname;
                emp.user_Department = item.user_Department;
                emp.user_Level = item.user_Level;
                emp.user_Status = item.user_Status;
                emp.createDate = item.createDate;
                emp.dateModify = item.dateModify;
                emp.user_Username = item.user_Username;
                emp.user_Password = item.user_Password;

                employe.LEmploye.Add(emp);
            }

            return PartialView("EmployesView", employe);
        }

        //AddUser
        public IActionResult AddUser(string user_Fristname, string user_Lastname,string user_Department,int user_Level,int user_Status,string user_Createdate,string user_DateModify,string user_Username,string user_Password)
        {
            ApiParameter apt = new ApiParameter();
            List<ApiParameter> lapt = new List<ApiParameter>();
            WebClient client = new WebClient();
            client.UseDefaultCredentials = true;
            var Url = "https://localhost:44351/api/Users/AddUser";

            JObject Parameters = new JObject(
                new JProperty("user_Fristname",user_Fristname),
                new JProperty("user_Lastname",user_Lastname),
                new JProperty("user_Department",user_Department),
                new JProperty("user_Level",user_Level),
                new JProperty("user_Status",user_Status),
                new JProperty("createDate",user_Createdate),
                new JProperty("dateModify",user_DateModify),
                new JProperty("user_Username",user_Username),
                new JProperty("user_Password",user_Password)
                );
            string DataString = Parameters.ToString();
            var Response = "";

            apt = new ApiParameter();
            apt.Name = "Json";
            apt.Value = DataString;
            lapt.Add(apt);

            string PostUrl = Url + "?";
            string PostBody = "";
            foreach(var p in lapt)
            {
                if (p.Name == "Json") PostBody += p.Value;
                else PostUrl += p.Name + "=" + p.Value + "&";
            }
            PostUrl = PostUrl.Remove(PostUrl.Length - 1);
            client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            client.Encoding = Encoding.UTF8;
            Response = client.UploadString(PostUrl, "POST", PostBody);
            return Ok(Response);
        }

        //Update User
        public IActionResult UpdateUser(int user_ID1,string user_Fristname,string user_Lastname,string user_Department,int user_Level,int user_Status,string user_Createdate,string user_Datemodify,string user_Username,string user_Password)
        {
            ApiParameter atp = new ApiParameter();
            List<ApiParameter> lapt = new List<ApiParameter>();
            WebClient client = new WebClient();
            client.UseDefaultCredentials = true;
            var Url = "https://localhost:44351/api/Users/UpdateUser";
            var Response = "";

            JObject Parameters = new JObject(
                new JProperty("user_ID",user_ID1),
                new JProperty("user_Fristname", user_Fristname),
                new JProperty("user_Lastname", user_Lastname),
                new JProperty("user_Department", user_Department),
                new JProperty("user_Level", user_Level),
                new JProperty("user_Status", user_Status),
                new JProperty("createDate", user_Createdate),
                new JProperty("dateModify", user_Datemodify),
                new JProperty("user_Username", user_Username),
                new JProperty("user_Password", user_Password)
                );
            string DataString = Parameters.ToString();

            atp = new ApiParameter();
            atp.Name = "/*json*/";
            atp.Value = DataString;
            lapt.Add(atp);

            string PutUrl = Url;
            string PutBody = "";

            foreach (var p in lapt)
            {
                if (p.Name == "json") PutUrl += "?" + "=" + p.Value;
                else if (p.Name == "Finalurl") PutUrl += p.Value;
                else PutBody += p.Value;
            }
            client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            client.Encoding = Encoding.UTF8;
            Response = client.UploadString(PutUrl, "PUT", PutBody);

            return Ok(Response);
        }

        //List Dropdows Department
        DataDB datadepartnent = new DataDB();
        public IActionResult KKKK()
        {
            var depart = datadepartnent.Department();

            return Json(new {IsSuccess = true,depart});
        }

        // Level
        public IActionResult LLLL()
        {
            var level = datadepartnent.Levels();
            return Json(new { IsSuccess = true, level });
        }

        //Status
        public IActionResult statusss()
        {
            var sta = datadepartnent.Status();            
            return Json(new { isSuccess = true, sta});
        }



    }
}
