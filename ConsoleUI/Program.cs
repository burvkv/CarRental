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
            CarManager manager = new CarManager(new EfCarDal());
            var result = manager.GetAll();
            foreach (var car in result.Data)
            {
                Console.WriteLine(car.CarName);
            }
            Console.WriteLine(result.Message);

            var resultDto = manager.CarDetails();
            foreach (var dto in resultDto.Data)
            {
                Console.WriteLine("{0} {1} {2} : {3} TL", dto.BrandName, dto.CarName, dto.ColorName, dto.DailyPrice);
            }
        }

    }
}


