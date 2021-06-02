
using Core;
using Core.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalContext>, ICarDal
    {
        public List<CarDetailDto> CarDetailDto(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join col in context.Colors
                             on c.ColorId equals col.ColorId
                             select new CarDetailDto { CarId = c.Id, CarName = c.CarName, BrandName = b.BrandName, ColorName = col.ColorName, DailyPrice = c.DailyPrice };

                return filter != null ? result.Where(filter).ToList() : result.ToList();
            }
        }
    }
}
