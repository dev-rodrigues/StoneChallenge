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
    public class InssRepository : IDiscount
    {
        private readonly EFDataContext _db;

        public InssRepository()
        {
            _db = new EFDataContext();
        }

        public Discount GetDiscount(decimal salary)
        {
            List<Inss> alicotas = _db.Inss.ToList();
            decimal alicota = 0;

            foreach (var a in alicotas)
            {
                if (salary >= a.Minimo && salary <= a.Maximo)
                {
                    alicota = a.Alicota;
                       
                }
            }

            return new Discount()
            {
                TypeOfDiscount = "INSS",
                Dedution = alicota,
                Aliquot = 0
            };
        }
    }
}
