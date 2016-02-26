using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;


namespace MVC_Approach.Models
{
    public class RestCaller
    {
        public string GetUsersList()
        {
            using (var client = new HttpClient())
            {
                Task<string> getStringTask = client.GetStringAsync("http://localhost:54138/api/UserEF/");
                return getStringTask.ToString();
            }
        }
    }
}