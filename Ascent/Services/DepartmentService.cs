using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascent.Models;

namespace Ascent.Services
{
    public class DepartmentService
    {
        private readonly AppDbContext _db;

        public DepartmentService(AppDbContext db)
        {
            _db = db;
        }

        public List<Department> GetDepartments()
        {
            return _db.Departments.OrderBy(d => d.Name).ToList();
        }
    }
}
