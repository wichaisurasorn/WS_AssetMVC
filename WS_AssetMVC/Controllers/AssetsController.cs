using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using WS_AssetMVC.Models;
using WS_AssetMVC.Services;
using Newtonsoft.Json;
using static WS_AssetMVC.Services.ApiRequest;
using Microsoft.AspNetCore.Http;

namespace WS_AssetMVC.Controllers
{
    public class AssetsController : Controller
    {
        public IActionResult Addasset()
        {
            return View();
        }
        //public IActionResult EditAsset(int id)
        //{
        //    //List<AssetId.AssetByID> Ass = (List<AssetId.AssetByID>)JsonConvert.DeserializeObject(HttpContext.Session.GetString("data"));
        //    //ViewData.GetViewDataInfo = HttpContext.Session.GetString("Data");
        //     Parameters apt = new Parameters();
        //    List<Parameters> lapt = new List<Parameters>();

        //    List<AssetId.AssetByID> Ass = new List<AssetId.AssetByID>();
        //    List<Assets> last = new List<Assets>();
        //    WebClient client = new WebClient();
        //    client.UseDefaultCredentials = true;
        //    client.Headers[HttpRequestHeader.ContentType] = "application/x-www-from-urlencoded";

        //    string Parameter = string.Empty;
        //    int PLenght = 0;

        //    apt = new Parameters();
        //    apt.Name = "id";
        //    apt.Value = id.ToString();
        //    lapt.Add(apt);

        //    foreach (var p in lapt)
        //    {
        //        if (PLenght == 0) Parameter += "?" + p.Name + "=" + p.Value;
        //        else Parameter += "&" + p.Name + "=" + p.Value;
        //        PLenght++;
        //    }

        //    var Url = "https://localhost:44351/api/Assets/AssetGetById";
        //    var Response = "";

        //    string FinalUrl = Url + Parameter;
        //    var responsedata = client.DownloadData(FinalUrl);
        //    //Response = UnicodeEncoding.UTF8.GetString(responsedata);
        //    Response = UnicodeEncoding.UTF8.GetString(responsedata);

        //    List<AssetID> las = (List<AssetID>)JsonConvert.DeserializeObject(Response, typeof(List<AssetID>));
        //   // Ass.LAssetById = new List<AssetId.AssetByID>();

        //    foreach (var item in las)
        //    {
        //        AssetId.AssetByID ast = new AssetId.AssetByID();

        //        ast.asset_ID = item.asset_ID;
        //        ast.asset_Name = item.asset_Number;
        //        ast.asset_Serial = item.asset_Serial;
        //        ast.type_ID = item.type_ID;
        //        ast.asset_Datebuy = item.asset_Datebuy;
        //        ast.asset_Waranty = item.asset_Waranty;
        //        ast.asset_Price = item.asset_Price;
        //        ast.asset_Supply = item.asset_Supply;
        //        ast.user_ID = item.user_ID;
        //        ast.admin_ID = item.admin_ID;
        //        ast.asset_Number = item.asset_Number;
        //        ast.asset_Modify = item.asset_Modify;

        //        Ass.Add(ast);
        //    }
        //    ViewData["data"] = Ass;
        //    return RedirectToAction(,);
        //}


        public IActionResult Add(string Asset_Name,string Asset_Serial,int Type_ID,string Asset_Datebuy,string Asset_Waranty,
            string Asset_Price,string Asset_Supply,int User_ID,int Admin_ID,string Asset_Number,string Asset_Modify)
        {
            ApiParameter apt = new ApiParameter();
            List<ApiParameter> lapt = new List<ApiParameter>();

            WebClient Client = new WebClient();
            Client.UseDefaultCredentials = true;
            var Url = "https://localhost:44351/api/Assets/AddAsset";

            JObject Parameters = new JObject(
                new JProperty("asset_Name", Asset_Name),
                new JProperty("asset_Serial", Asset_Serial),
                new JProperty("type_ID", Type_ID),
                new JProperty("asset_Datebuy", Asset_Datebuy),
                new JProperty("asset_Waranty", Asset_Waranty),
                new JProperty("asset_Price", Asset_Price),
                new JProperty("asset_Supply", Asset_Supply),
                new JProperty("user_ID", User_ID),
                new JProperty("admin_ID", Admin_ID),
                new JProperty("asset_Number", Asset_Number),
                new JProperty("asset_Modify", Asset_Modify)
                );
            string DataStrting = Parameters.ToString();
            var Response = "";

            apt = new ApiParameter();
            apt.Name = "Json";
            apt.Value = DataStrting;
            lapt.Add(apt);

            string PostUrl = Url + "?";
            string PostBody = "";
            foreach(var p in lapt)
            {
                if (p.Name == "Json") PostBody += p.Value;
                else PostUrl += p.Name + "=" + p.Value + "&";
            }
            PostUrl = PostUrl.Remove(PostUrl.Length - 1);
            Client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            Client.Encoding = Encoding.UTF8;
            Response = Client.UploadString(PostUrl, "POST", PostBody);

            return Ok(Response);
        }

        public IActionResult detaildata(int id)
        {
            Parameters apt = new Parameters();
            List<Parameters> lapt = new List<Parameters>();

            List<AssetId.AssetByID> Ass = new List<AssetId.AssetByID>();
            List<Assets> last = new List<Assets>();
            WebClient client = new WebClient();
            client.UseDefaultCredentials = true;
            client.Headers[HttpRequestHeader.ContentType] = "application/x-www-from-urlencoded";

            string Parameter = string.Empty;
            int PLenght = 0;

            apt = new Parameters();
            apt.Name = "id";
            apt.Value = id.ToString();
            lapt.Add(apt);

            foreach (var p in lapt)
            {
                if (PLenght == 0) Parameter += "?" + p.Name + "=" + p.Value;
                else Parameter += "&" + p.Name + "=" + p.Value;
                PLenght++;
            }

            var Url = "https://localhost:44351/api/Assets/AssetGetById";
            var Response = "";

            string FinalUrl = Url + Parameter;
            var responsedata = client.DownloadData(FinalUrl);
            //Response = UnicodeEncoding.UTF8.GetString(responsedata);
            Response = UnicodeEncoding.UTF8.GetString(responsedata);

            List<AssetID> las = (List<AssetID>)JsonConvert.DeserializeObject(Response, typeof(List<AssetID>));
           // Ass.LAssetById = new List<AssetId.AssetByID>();

            foreach (var item in las)
            {
                AssetId.AssetByID ast = new AssetId.AssetByID();

                ast.asset_ID = item.asset_ID;
                ast.asset_Name = item.asset_Number;
                ast.asset_Serial = item.asset_Serial;
                ast.type_ID = item.type_ID;
                ast.asset_Datebuy = item.asset_Datebuy;
                ast.asset_Waranty = item.asset_Waranty;
                ast.asset_Price = item.asset_Price;
                ast.asset_Supply = item.asset_Supply;
                ast.user_ID = item.user_ID;
                ast.admin_ID = item.admin_ID;
                ast.asset_Number = item.asset_Number;
                ast.asset_Modify = item.asset_Modify;

                Ass.Add(ast);
            }
            //HttpContext.Session.SetString("data",JsonConvert.SerializeObject(Ass));
           // ViewData["Data"] = Ass;
            return RedirectToAction("EditAsset","Assets");

        }
    }
}
