using Demo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.interfaces
{
  public  interface IDepartmentRepositories 
    {
        IEnumerable<Department> GetAll();
        Department GetbyId(int id);
        int Add(Department department);
        int Update(Department department);
        int Delete(Department department);
    }
}
