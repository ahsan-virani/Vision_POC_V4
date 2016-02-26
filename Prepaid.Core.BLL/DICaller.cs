using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Prepaid.Core.BLL
{
    public class DICaller
    {
        //This is made to call the specific business function

        //Controller will call these method.
        PrepaidCore prepaid = new PrepaidCore();

        public void GetAllUsers()
        {
            //prepaid.SearchData();
        }


        /****** Implementing dependency injection ******/

        private IModel _model;

        public DICaller(IModel model)
        {
            _model = model;
        }
        public void LoadData()
        {
            _model.SearchData();
        }
    }
}
