using Stone.Domain.Entities;
using Stone.Domain.Interface.Repositories;
using Stone.Infrastructure.DataContextLayer;
using Stone.Service;
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

        public Discount GetDesconto(decimal salario)
        {
            var alicotas = _db.Irpf.ToList();
            decimal alicota = 0;
            decimal deducao = 0;
            decimal descontar = 0;

            foreach (var a in alicotas)
            {
                if (salario >= a.Minimo && salario <= a.Maximo)
                {
                    alicota = a.Aliquota;
                    deducao = a.Deduzir;
                    descontar = CalculeteDiscountService.CalculeteIrpf(alicota, deducao, salario);
                    break;
                }
            }
            
            return new Discount()
            {
                TipoDeDesconto = "IRPF",
                Aliquota = alicota,
                Deducao = deducao,
                ValorDesconto = descontar
            };
        }
    }
}
