using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avanza.DataAccess;

namespace Prepaid.Core.BLL
{
    public class PrepaidCore : IPrepaidCore
    {
        VisionDBModel db = new VisionDBModel();        
        public List<SEC_USER> SearchData(DataParameter parameter)
        {
            List<SEC_USER> users = null;
            
            
            //if (parameter.ID != string.Empty)
            //    users = db.SEC_USER.Where(x => x.DEPT_ID == Convert.ToDecimal(parameter.ID)).ToList();

            return users;
        }

        public void SaveData()
        {

        }

        public void DeleteData()
        {

        }

        public void UpdateData()
        {
 
        }
    }
}
