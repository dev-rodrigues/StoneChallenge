using Stone.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Stone.Domain.Interface.Repositories
{
    public interface IDiscount
    {
        Discount GetDesconto(decimal salary);
    }
}
