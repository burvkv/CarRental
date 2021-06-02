using Bussiness.Concrete;
using Core.EntityFramework;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            GetDetailsAll();
            //GetById();
        }

        private static void GetById()
        {
            CarManager manager = new CarManager(new EfCarDal());

            var car = manager.GetById(1);
            Console.WriteLine(car.CarName);
        }

        private static void GetDetailsAll()
        {
            CarManager manager = new CarManager(new EfCarDal());
            foreach (var dto in manager.carDetails())
            {
                Console.WriteLine("{0} {1} {2} :{3}₺", dto.ColorName, dto.BrandName, dto.CarName, dto.DailyPrice);
            }
        }
    }
}


