using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBMProjectDAL.customer;
using SBMProjectModel.Models;

namespace SBMProjectBLL.customer
{
    public class CustomerManager
    {
        CustomerRepository _cuRepository = new CustomerRepository();
        public bool SaveCustomer(Customer obj)
        {
            bool isSave = false;
            isSave = _cuRepository.SaveCustomer(obj);
            return isSave;
        }
    }
}
