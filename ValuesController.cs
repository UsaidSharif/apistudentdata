using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Script.Serialization;
using System.Runtime.Caching;


namespace API_StudentTable.Controllers
{
    public class ValuesController : ApiController
    {
       
        public class Students
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }
            public int Marks { get; set; }

            public Students(int id, string name, string address, int marks)
            {
                this.ID = id;
                this.Name = name;
                this.Address = address;
                this.Marks = marks;
            }

        }
        // GET api/values
        public string Get()
        {
            string connetionString = ConfigurationManager.ConnectionStrings["ProjectAPI"].ConnectionString; ;
            SqlConnection mycnn;

            mycnn = new SqlConnection(connetionString);
            mycnn.Open();
            SqlCommand command;
            SqlDataReader dataReader;
            string sql = "Select * From StudentData";
            command = new SqlCommand(sql, mycnn);
            dataReader = command.ExecuteReader();

            List<Students> StudentList = new List<Students>();

            while (dataReader.Read())
            {
                int ID = Convert.ToInt32(dataReader.GetValue(0));
                string name = dataReader.GetValue(1).ToString();
                string address = dataReader.GetValue(2).ToString();
                int marks = Convert.ToInt32(dataReader.GetValue(3));
                Students account = new Students(ID, name, address, marks);
                StudentList.Add(account);
            }

            dataReader.Close();
            command.Dispose();
            mycnn.Close();

            ObjectCache cache = MemoryCache.Default;

            if (cache["students"] == null)
            {
                var cacheItemPolicy = new CacheItemPolicy
                {
                    AbsoluteExpiration = DateTimeOffset.Now.AddDays(1)
                };
                var cacheItem = new CacheItem("students", StudentList);
                cache.Add(cacheItem, cacheItemPolicy);
            }

            JavaScriptSerializer js = new JavaScriptSerializer();

            return js.Serialize((List<Students>)cache.Get("students"));
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
