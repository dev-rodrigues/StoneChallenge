using Stone.Domain.Entities;
using Stone.Domain.Interface.Repositories;
using Stone.Infrastructure.DataContextLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stone.Infrastructure.Repositories
{
    public class IrpfRepository : IDiscount
    {
        private readonly EFDataContext _db;

        public IrpfRepository()
        {
            _db = new EFDataContext();
        }

        public Discount GetDiscount(decimal salary)
        {
            var alicotas = _db.Irpf.ToList();
            decimal alicota = 0;
            decimal deducao = 0;

            foreach (var a in alicotas)
            {
                if (salary >= a.Minimo && salary <= a.Maximo)
                {
                    alicota = a.Alicota;
                    deducao = a.Deduzir;
                }
            }
            
            return new Discount()
            {
                TypeOfDiscount = "INSS",
                Aliquot = alicota,
                Dedution = deducao
            };
        }
    }
}
