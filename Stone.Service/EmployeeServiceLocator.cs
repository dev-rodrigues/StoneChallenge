using Stone.Domain.Interface.Repositories;
using Stone.Infrastructure.DataContextLayer;
using Stone.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.Service
{
    public class EmployeeServiceLocator
    {
        
        private static Dictionary<Type, Type> EmployeeService = new Dictionary<Type, Type>
        {
            [typeof(IEmployee)] = typeof(EmployeeRepository)
        };

        internal static T GetInstance<T>()
        {
            return Activator.CreateInstance<T>();
        }
    }
}
