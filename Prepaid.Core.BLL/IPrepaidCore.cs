using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Web;
using Avanza.DataAccess;

namespace Prepaid.Core.BLL
{
    [ServiceContract]
    interface IPrepaidCore
    {
        // need to be exposed for Rest Api..
        //[OperationContract]
        //[WebInvoke(UriTemplate = "IssueCards", ResponseFormat = System.ServiceModel.Web.WebMessageFormat.Json)]
        //void IssueCards();

        //[OperationContract]
        //[WebInvoke(UriTemplate = "TransferFunds", ResponseFormat = System.ServiceModel.Web.WebMessageFormat.Json)]
        //void TransferFunds();

        //[OperationContract]
        //[WebInvoke(UriTemplate = "GetUsers", ResponseFormat = System.ServiceModel.Web.WebMessageFormat.Json)]
        //List<SEC_USER> GetUsers();
        
        [OperationContract]
        [WebInvoke(UriTemplate = "SearchData", ResponseFormat = System.ServiceModel.Web.WebMessageFormat.Json)]
        List<SEC_USER> SearchData(DataParameter requestParams);

        [OperationContract]
        [WebInvoke(UriTemplate = "SaveData", ResponseFormat = System.ServiceModel.Web.WebMessageFormat.Json)]
        void SaveData();

        [OperationContract]
        [WebInvoke(UriTemplate = "DeleteData", ResponseFormat = System.ServiceModel.Web.WebMessageFormat.Json)]
        void DeleteData();

        [OperationContract]
        [WebInvoke(UriTemplate = "UpdateData", ResponseFormat = System.ServiceModel.Web.WebMessageFormat.Json)]
        void UpdateData();
    }
}
