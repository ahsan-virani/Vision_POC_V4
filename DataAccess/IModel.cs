using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace DataAccess
{
    [ServiceContract]
    public interface IModel
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "SearchData", ResponseFormat = System.ServiceModel.Web.WebMessageFormat.Json)]
        string SearchData();

        [OperationContract]
        [WebInvoke(UriTemplate = "SaveData", ResponseFormat = System.ServiceModel.Web.WebMessageFormat.Json)]
        string SaveData();
    }
}
