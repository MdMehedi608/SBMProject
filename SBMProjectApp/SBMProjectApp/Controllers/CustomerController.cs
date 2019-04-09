using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SBMProjectBLL.customer;
using SBMProjectModel.Models;
using SBMProjectModel.Models.ViewModels;


namespace SBMProjectApp.Controllers
{
    public class CustomerController : Controller
    {
        // GET: /Customer/
        CustomerManager _cuManager = new CustomerManager();
        public ActionResult CustomerList()
        {
            ViewBag.CallingForm = "Student";
            ViewBag.CallingForm1 = "Student List";
            ViewBag.CallingViewPage = "#";
            //var vmList = LoadCustomers();
            return View();
        }
        public ActionResult CustomerCreate()
        {
            DefaultLoad();
            return View();
        }

        [HttpPost]
        public ActionResult CustomerCreate(Customer customer)
        {
            DefaultLoad();
            try
            {
                bool isSave = false;
                if (ModelState.IsValid)
                {
                    isSave = _cuManager.SaveCustomer(customer);
                    if (isSave)
                    {
                        ViewBag.SMsg = "Student Add Successfully!!";
                    }
                    else
                    {
                        ViewBag.FMsg = "Student Add Failed!!";
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.FMsg = ex.Message;
            }
            //ViewBag.SubDistrictId = new SelectList(_db.SubDistricts, "Id", "Name", student.SubDistrictId);
            return View(customer);
        }
        //public List<VM_Customer> LoadCustomers()
        //{
        //    List<VM_Customer> stList = new List<VM_Customer>();
        //    stList = _cuManager.GetStudent();
        //    return stList;
        //}
        //[HttpPost]
        //public ActionResult StudentUpdate(Customer student)
        //{
        //    DefaultLoad();
        //    try
        //    {
        //        bool isSave = false;
        //        if (student.Id > 0)
        //        {
        //            isSave = _stManager.UpdateStudent(student);
        //            if (isSave)
        //            {
        //                ViewBag.SMsg = "Student Update Successfully!!";
        //            }
        //            else
        //            {
        //                ViewBag.FMsg = "Student Update Failed!!";
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ViewBag.FMsg = ex.Message;
        //    }
        //    //ViewBag.SubDistrictId = new SelectList(_db.SubDistricts, "Id", "Name");
        //    return View(student);
        //}


        public void DefaultLoad()
        {
            ViewBag.CallingForm = "Customer";
            ViewBag.CallingForm1 = "Customer";
            ViewBag.CallingForm2 = "Add New";
            ViewBag.CallingViewPage = "/Customer/CustomerList";
        }
	}
}