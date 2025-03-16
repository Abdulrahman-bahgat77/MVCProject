using Demo.BLL.interfaces;
using Demo.DAL.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Demo.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private IDepartmentRepositories _departmentRepositories;
        public DepartmentController(IDepartmentRepositories departmentRepositories)//Ask Clr to dreates object from class implement interface IdepartmentRepositories  
        {
            _departmentRepositories = departmentRepositories;
        }
        public IActionResult Index()
        {
            var departments = _departmentRepositories.GetAll();
            return View(departments);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                _departmentRepositories.Add(department);
                return  RedirectToAction(nameof(Index));
            }
            return View(department);
        }
        public IActionResult Detail(int? id,string ViewName="Detail")
        {
            if (id is null)
                return BadRequest();
            var department = _departmentRepositories.GetbyId(id.Value);

            if(department is null)
            
                return NotFound();
            return View(ViewName,department);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            //if (id is null) 
            //    return BadRequest();
            //var department = _departmentRepositories.GetbyId(id.Value);

            //if (department is null)

            //    return NotFound();
            //return View(department);
            return Detail(id,"Edit");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Department department,[FromRoute]int id)
        {
            if (id != department.id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _departmentRepositories.Update(department);
                    return RedirectToAction(nameof(Index));
                }
                catch(System.Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
                return View(department);

        }
    }
}
