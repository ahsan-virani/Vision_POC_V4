using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Web;
using DataAccess;
using System.Runtime.Serialization;

namespace Prepaid.Core.BLL
{
    [DataContract]
    public class DataParameter
    {
        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string ID { get; set; }

        [DataMember]
        public string Code { get; set; }
    }
}
