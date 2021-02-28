using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WS_AssetMVC.Models;
using WS_AssetMVC.Models.List;

namespace WS_AssetMVC.Datas
{
    public class DataDB
    {
        public List<EmpleyeGet> GetUser()
        {
            var query = "SELECT * FROM tb_users";
            List<EmpleyeGet> users = new List<EmpleyeGet>();
            SqlConnection con = new SqlConnection(Startup.ConnectionString);
            SqlCommand cmd = new SqlCommand(query,con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                EmpleyeGet user = new EmpleyeGet();
                if (reader["user_Username"] != DBNull.Value)
                {
                    user.user_Username = reader["user_Username"].ToString();
                }
                if (reader["user_Password"] != DBNull.Value)
                {
                    user.user_Password = reader["user_Password"].ToString();
                }
                users.Add(user);
            }
            con.Close();
            return users;
        }


        //list Department
        public List<Department> Department()
        {
            var query = "SELECT * FROM tb_department";
            List<Department> departments = new List<Department>();
            SqlConnection con = new SqlConnection(Startup.ConnectionString);
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read()){
                Department dep = new Department();
                if(reader["id"] != DBNull.Value)
                {
                    dep.id = int.Parse(reader["id"].ToString());
                }
                if(reader["department"] != DBNull.Value)
                {
                    dep.department = reader["department"].ToString();
                }
                departments.Add(dep);
            }
            con.Close();
            return departments;
        }

        //list Levels
        public List<Levels> Levels()
        {
            var query = "SELECT * FROM tb_level";
            List<Levels> level = new List<Levels>();
            SqlConnection con = new SqlConnection(Startup.ConnectionString);
            SqlCommand cmd = new SqlCommand(query,con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Levels lev = new Levels();
                if (reader["id"] != DBNull.Value)
                {                    
                    lev.id = int.Parse(reader["id"].ToString());
                }
                if(reader["level"] != DBNull.Value)
                {
                    lev.level = reader["level"].ToString();
                }
                level.Add(lev);
            }
            return level;
        }

        //list Statuss
        public List<Statuss> Status()
        {
            var query = "SELECT * FROM tb_status";
            List<Statuss> status = new List<Statuss>();
            SqlConnection con = new SqlConnection(Startup.ConnectionString);
            SqlCommand cmd = new SqlCommand(query,con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Statuss sta = new Statuss();
                if(reader["id"] != DBNull.Value)
                {
                    sta.id = int.Parse(reader["id"].ToString());
                }
                if(reader["status"] != DBNull.Value)
                {
                    sta.status = reader["status"].ToString();
                }
                status.Add(sta);
            }
            return status;
        }
    }
}
