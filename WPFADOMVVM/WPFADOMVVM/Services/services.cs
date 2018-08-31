using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFADOMVVM.Model;

namespace WPFADOMVVM.Services
{
    public interface IDataAccessService
    {
        ObservableCollection<Brouwers> GetEmployees();
        int CreateEmployee(Brouwers Emp);
    }

    public class DataAccessService : IDataAccessService
    {
        CompanyEntities context;
        public DataAccessService()
        {
            context = new CompanyEntities();
        }
        public ObservableCollection<employeeinfo> GetEmployees()
        {
            ObservableCollection<employeeinfo> Employees = new ObservableCollection<employeeinfo>();
            foreach (var item in context.EmployeeInfoes)
            {
                Employees.Add(item);
            }
            return Employees;
        }

        public int CreateEmployee(EmployeeInfo Emp)
        {
            context.EmployeeInfoes.Add(Emp);
            context.SaveChanges();
            return Emp.EmpNo;
        }

    }
    class services
    {
    }
}
