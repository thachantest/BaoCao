using System;
using Cau1.DAO;
using Cau1.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cau1.BLL
{
    public class DepartmentBLL
    {
        DepartmentDAO dao = new DepartmentDAO();
        public List<Department> ReadAreaList()
        {
            List<Department> lstDepart = dao.ReadAreaList();
            return lstDepart;
        }
    }
}
