using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBMProjectDAL.common;
using SBMProjectModel.DatabaseContext;
using SBMProjectModel.Models;
using SBMProjectModel.Models.ViewModels;

namespace SBMProjectDAL.customer
{
    public class CustomerRepository
    {
        SBMDbContext _db = new SBMDbContext();
        private SqlFactory _sqlFactory = new SqlFactory();
        private DataTable _dt;
        public bool SaveCustomer(Customer obj)
        {
            bool isSave = false;
            _db.Customers.Add(obj);
            int add = _db.SaveChanges();
            if (add > 0)
            {
                isSave = true;
            }
            else
            {
                isSave = false;
            }
            return isSave;

        }
        //public bool UpdateStudent(SBMModels.Models.Customer obj)
        //{
        //    bool isSave = false;
        //    _db.Entry(obj).State = EntityState.Modified;
        //    int add = _db.SaveChanges();
        //    if (add > 0)
        //    {
        //        isSave = true;
        //    }
        //    else
        //    {
        //        isSave = false;
        //    }
        //    return isSave;
        //}
        public List<VM_Customer> GetStudent()
        {
            List<VM_Customer> vmList = new List<VM_Customer>();
            _dt = new DataTable();
            string query = @"Select * From VW_GetStudentInfo";
            _dt = _sqlFactory.ExecuteQuery(query);
            if (_dt.Rows.Count > 0)
            {
                foreach (DataRow row in _dt.Rows)
                {
                    var vm = new VM_Customer();
                    vm.Id = Convert.ToInt32(row["Id"]);
                    vm.Name = row["Name"].ToString();
                    vm.Address = row["Address"].ToString();
                    vm.Contact = row["Contact"].ToString();
                    vm.Email = row["Email"].ToString();
                    vm.LoyaltyPoint = row["LoyaltyPoint"].ToString();
                    vmList.Add(vm);
                }

            }
            return vmList;
        }
    }
}
