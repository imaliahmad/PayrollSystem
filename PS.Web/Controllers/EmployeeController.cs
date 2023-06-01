using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PS.BLL;
using PS.BOL;



namespace PS.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeBs objemployeeBs;
        private readonly IDepartmentBs departmentBs;
        public EmployeeController(IEmployeeBs _objemployeeBs,IDepartmentBs _departmentBs)
        { 
            objemployeeBs = _objemployeeBs;
            departmentBs = _departmentBs;
        }
        /** 
         * This function is used to get employee list.
        **/
        public IActionResult Index()
        {
            try
            {
                var list = objemployeeBs.GetAll().ToList();
                return View(list);
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                TempData["ErrorMessage"] = msg;
                return View();
            }
            
        }
        /**
         * This function is used to get employee record.
        **/
        [HttpGet]
        public IActionResult CreateorEdit(int id)
        {
            try
            {
                Employee obj = new Employee();
                if (id > 0)
                {
                    obj = objemployeeBs.GetById(id);
                }
              ViewBag.DepartmentList= new SelectList(departmentBs.GetAll(), "DeptId", "DeptName");
              return View(obj);
            }
            catch (Exception ex)
            {

               var msg=ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                TempData["ErrorMessage"] = msg;
                return View();
            }
        }
        /**
         * This function is used to insert and update employee.
        **/
        [HttpPost]
        public IActionResult CreateorEdit(Employee model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    if(model.EmpId > 0)
                    {
                        objemployeeBs.Update(model);
                    }
                    else
                    {
                        objemployeeBs.Insert(model);
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["ErrorMessage"] = "Employee is not Insert/Update";
                    return View(model);
                }

            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                TempData["ErrorMessage"] = msg;
                return View();
            }
        }
        /**
         * This function is used to get employee detail. 
        **/ 
        public IActionResult Details(int id)
        {
            try
            {
                Employee obj = new Employee();
                if (id > 0)
                {
                    obj = objemployeeBs.GetById(id);
                   
                }
                ViewBag.DepartmentList = new SelectList(departmentBs.GetAll(), "DeptId", "DeptName");
                return View(obj);
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                TempData["ErrorMessage"] = msg;
                return View();
               
            }
           
        }
    }
}
