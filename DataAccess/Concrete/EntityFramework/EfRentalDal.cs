using Core.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.Concrete.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarRentalContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDtos()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from r in context.Rentals
                             join c in context.Customers
                             on r.CustomerId equals c.CustomerId
                             join u in context.Users
                             on c.UserId equals u.Id
                             join car in context.Cars
                             on r.CarId equals car.Id
                             join b in context.Brands
                             on car.BrandId equals b.BrandId
                             join color in context.Colors
                             on car.ColorId equals color.ColorId
                             select new RentalDetailDto
                             {
                                 CarName = color.ColorName + " " + b.BrandName + " " + car.CarName + " " + car.ModelYear,
                                 CustomerFullName = u.FirstName + " " + u.LastName,
                                 CompanyName = c.CompanyName,
                                 Id = r.Id,
                                 RentalDate = r.RentDate.Value,
                                 ReturnDate = r.ReturnDate.Value
                             };

                return result.ToList();
            }
        }

        public bool IsFinish(int carId)
        {
            using (CarRentalContext context = new CarRentalContext())
            {


                var result = from r in context.Rentals
                             where r.CarId.Equals(carId)
                             select new
                             {
                                 IsNull = r.ReturnDate == null ? true : false,
                                 r.ReturnDate
                             };

                //null olan bir değer varsa o araç henüz teslim edilmemiş demektir ve kiralanamazdır.
                if (result.Any(i => i.IsNull == true))
                {
                   
                    return false;
                }

                //Kiralanırken belirtilen teslim edilecek tarih şuanki tarihten küçükse true, büyükse false gönderecektir.
                else if (result.Count()!=0)
                {
                    List<DateTime> returnDates = new List<DateTime>();
                    foreach (var dates in result)
                    {
                        returnDates.Add(dates.ReturnDate.Value);
                    }
                    returnDates.OrderByDescending(i => i.Date);
                    
                    return returnDates[0] <= DateTime.Now;

                }
                else
                {
                    return true;
                }
            }




        }
    }
}

