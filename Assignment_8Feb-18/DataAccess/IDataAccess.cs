using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_8Feb_18.DataAccess
{
    internal interface IDataAccess<TEntity, in TKey> where TEntity : class
    {
        IEnumerable<TEntity> GetAllEmployeesByDeptName(TKey id);
        IEnumerable<TEntity> GetAllEmployeesWithMaxSalByDeptName(TKey id);
        IEnumerable<TEntity> GetSumSalaryByDeptName(TKey id);
        IEnumerable<TEntity> GetAllEmployeesByLocation(TKey id);

    }
}
