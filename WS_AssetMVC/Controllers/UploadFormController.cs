using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Data.SqlClient;
using WS_AssetMVC.Models.UploadForm;

namespace WS_AssetMVC.Controllers
{
    public class UploadFormController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UploadFormController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AllEmployes()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UploadFile(string firstname,string lastname,string department, IEnumerable<IFormFile> files)
        {
            
            var path = Path.Combine(_webHostEnvironment.WebRootPath,"UploadFiles");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            foreach (IFormFile postedFile in files)
            {
                string partimagee = "/UploadFiles/";
                string extFile = Path.GetExtension(postedFile.FileName);
                string fileName = DateTime.Now.ToString("ddMMyyyyhhmmss") + extFile;
                var filepath = Path.Combine(path, fileName);
                var SSS = partimagee + fileName;
                using (FileStream stream = new FileStream(filepath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }

                var query = "INSERT INTO [dbo].[tb_employes](firstname,lastname,department,fileimage,pathimage)VALUES(@firstname,@lastname,@department,@fileName,@filepath)";
                
                SqlParameter pt = new SqlParameter();
                List<SqlParameter> lpt = new List<SqlParameter>();

                pt = new SqlParameter();
                pt.ParameterName = "@firstname";
                pt.Value = firstname;
                lpt.Add(pt);

                pt = new SqlParameter();
                pt.ParameterName = "@lastname";
                pt.Value = lastname;
                lpt.Add(pt);

                pt = new SqlParameter();
                pt.ParameterName = "department";
                pt.Value = department;
                lpt.Add(pt);

                pt = new SqlParameter();
                pt.ParameterName = "@fileName";
                pt.Value = fileName;
                lpt.Add(pt);

                pt = new SqlParameter();
                pt.ParameterName = "@filepath";
                pt.Value = SSS;
                lpt.Add(pt);

                SqlConnection con = new SqlConnection(Startup.ConnectionString);
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                foreach(var item in lpt)
                {
                    cmd.Parameters.Add(item); 
                }
                cmd.ExecuteNonQuery();
                con.Close();
            }

            return Ok("Success Upload File");
        }

        //show data 
        public IActionResult Alldata()
        {
            Allemploye all = new Allemploye();
            var query = "SELECT * FROM [dbo].[tb_employes]";
            SqlConnection con = new SqlConnection(Startup.ConnectionString);
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Allemploye.Employe em = new Allemploye.Employe();

                if (reader["id"] != DBNull.Value)
                {
                    em.id = int.Parse(reader["id"].ToString());
                }
                if(reader["firstname"] != DBNull.Value)
                {
                    em.firstname = reader["firstname"].ToString();
                }
                if (reader["lastname"] != DBNull.Value)
                {
                    em.lastname = reader["lastname"].ToString();
                }
                if (reader["department"] != DBNull.Value)
                {
                    em.department = reader["department"].ToString();
                }
                if (reader["fileimage"] != DBNull.Value)
                {
                    em.filename = reader["fileimage"].ToString();
                }
                if (reader["pathimage"] != DBNull.Value)
                {
                    em.filepath = reader["pathimage"].ToString();
                }
                all.LEmploye.Add(em);
                           
            }

            return PartialView("AllEmployes",all);
        }

        //Update data by ID
        public IActionResult UpdateFile(int id,string firstname,string lastname,string department, string filename ,IEnumerable<IFormFile> files)
        {
            var path = Path.Combine(_webHostEnvironment.WebRootPath, "UploadFiles"); 
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if(filename != null)
            {
                var ll = path + "\\" + filename;
                if (System.IO.File.Exists(ll))
                {
                    System.IO.File.Delete(ll);
                }
              
            }
            //Directory.Delete(filenamee);
            foreach (IFormFile postedFile in files)
            {
                string partimagee = "/UploadFiles/";
                string extFile = Path.GetExtension(postedFile.FileName);
                string fileName = DateTime.Now.ToString("ddMMyyyyhhmmss") + extFile;
                var filepath = Path.Combine(path, fileName);
                var SSS = partimagee + fileName;
                using (FileStream stream = new FileStream(filepath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }

                var query = "UPDATE  [dbo].[tb_employes] SET firstname = @firstname,lastname = @lastname,department = @department,fileimage = @fileName,pathimage = @filepath WHERE id = @id";

                SqlParameter pt = new SqlParameter();
                List<SqlParameter> lpt = new List<SqlParameter>();

                pt = new SqlParameter();
                pt.ParameterName = "@id";
                pt.Value = id;
                lpt.Add(pt);

                pt = new SqlParameter();
                pt.ParameterName = "@firstname";
                pt.Value = firstname;
                lpt.Add(pt);

                pt = new SqlParameter();
                pt.ParameterName = "@lastname";
                pt.Value = lastname;
                lpt.Add(pt);

                pt = new SqlParameter();
                pt.ParameterName = "department";
                pt.Value = department;
                lpt.Add(pt);

                pt = new SqlParameter();
                pt.ParameterName = "@fileName";
                pt.Value = fileName;
                lpt.Add(pt);

                pt = new SqlParameter();
                pt.ParameterName = "@filepath";
                pt.Value = SSS;
                lpt.Add(pt);

                SqlConnection con = new SqlConnection(Startup.ConnectionString);
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                foreach (var item in lpt)
                {
                    cmd.Parameters.Add(item);
                }
                cmd.ExecuteNonQuery();
                con.Close();
            }


                return Ok("Updata Data Success");
        }
    }
}
