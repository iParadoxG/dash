using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;

namespace LoginAPI.Controller
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LoginAPIController : ApiController
    {
        public IHttpActionResult Get(String uname, String pwd)
        {
            string conString = "User Id=SYSTEM; password=;Data Source=localhost:1521/xe; Pooling=false;";
            OracleConnection con = new OracleConnection
            {
                ConnectionString = conString
            };
            con.Open();
            //Console.WriteLine("Enter User Name");
            //var uname = "admin";//Console.ReadLine();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "select pass from \"locuser\".\"NPB_DASH_USERS\" where uname = '" + uname + "'";
            OracleDataReader reader = cmd.ExecuteReader();
            var dpwd = "";
            while (reader.Read())
            {
                dpwd = reader.GetString(0);
            }
            try
            {
                if (dpwd == null || dpwd == "")
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
                else
                {
                    try
                    {
                        if (dpwd != pwd)
                        { throw new HttpResponseException(HttpStatusCode.Unauthorized); }
                        else
                            return Ok();
                    }
                    catch
                    {
                        return Unauthorized();
                    }
                }
            }
            catch
            {
                return NotFound();
            }

        }


    }

    public class ChartAPIController : ApiController
    {
        public String Get()
        {

            string conString = "User Id=SYSTEM; password=;Data Source=localhost:1521/xe; Pooling=false;";
            OracleConnection con = new OracleConnection
            {
                ConnectionString = conString
            };
            con.Open();
            //Console.WriteLine("Enter User Name");
            //var uname = "admin";//Console.ReadLine();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "select * from \"locuser\".\"CHART_DATA\"";
            OracleDataReader reader = cmd.ExecuteReader();
            string v = "[";
            while (reader.Read())
            {
                v += "{ \"x\": " + reader.GetInt32(0) + ", \"y\": " + reader.GetInt32(1) + ", \"label\": \"" + reader.GetString(2) + "\"},";
            }
            String altered_v = v.Remove(v.Length - 1, 1);
            altered_v += "]";
            con.Close();
            return altered_v;
        }
    }
}