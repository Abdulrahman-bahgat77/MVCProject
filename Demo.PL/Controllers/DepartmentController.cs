using Demo.BLL.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Demo.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private IDepartmentRepositories _departmentRepositories;
        public DepartmentController(IDepartmentRepositories departmentRepositories)//Ask Clr to dreates object from class implement interface IdepartmentRepositories  
        {
            
        }
        public IActionResult Index()
        {
            var department = _departmentRepositories.GetAll();
            return View(department);
        }
    }
}
