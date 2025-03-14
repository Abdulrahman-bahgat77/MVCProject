using Demo.BLL.interfaces;
using Demo.DAL.Context;
using Demo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Repositories
{
 public   class DepartmentRepositories : IDepartmentRepositories
    {
        private MvcDBContext _dbcontext;
        public DepartmentRepositories(MvcDBContext dbcontext)
        {
            _dbcontext = dbcontext;
            //dbcontext = new MvcDBContext();
        }
        public IEnumerable<Department> GetAll()
        
        =>  _dbcontext.Departments.ToList();
        
        public int Add(Department department)
        {
        _dbcontext.Add(department);
            return _dbcontext.SaveChanges();
        }

        public int Delete(Department department)
        {
            _dbcontext.Remove(department);
          return  _dbcontext.SaveChanges();
        }

      

        public int Update(Department department)
        {
            _dbcontext.Update(department);
          return  _dbcontext.SaveChanges();
        }

        public Department GetbyId(int id)
        {
            //var D=   _dbcontext.Departments.Local.Where(D => D.id == id).FirstOrDefault();
            //   if(D is null)

            //       D= _dbcontext.Departments.Where(D => D.id == id).FirstOrDefault();
            //   return D;
           return _dbcontext.Departments.Find(id);
        }
    }
}
