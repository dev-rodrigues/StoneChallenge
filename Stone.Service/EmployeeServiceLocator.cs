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

        private static Dictionary<Type, Type> InssService = new Dictionary<Type, Type>
        {
            [typeof(IDiscount)] = typeof(InssRepository)
        };

        private static Dictionary<Type, Type> IrpfService = new Dictionary<Type, Type>
        {
            [typeof(IDiscount)] = typeof(IrpfRepository)
        };

        public static T GetInstance<T>()
        {
            return Activator.CreateInstance<T>();
        }
    }
}
