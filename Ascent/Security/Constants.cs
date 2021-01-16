using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ascent.Security
{
    public static class ClaimType
    {
        public const string Admin = "ascent_admin";
        public const string DepartmentRead = "ascent_department_read";
        public const string DepartmentWrite = "ascent_department_write";
    }

    public static class Policy
    {
        public const string IsAdmin = "IsAdmin";
        public const string CanReadDepartmentResources = "CanReadDepartmentResources";
        public const string CanWriteDepartmentResources = "CanWriteDepartmentResources";
    }
}
