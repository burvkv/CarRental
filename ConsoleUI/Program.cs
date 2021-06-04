using Business.Concrete;
using Bussiness.Concrete;
using Core.EntityFramework;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            RentalManager manager = new RentalManager(new EfRentalDal());

           var result =  manager.Insert(new Rental { CarId = 7, CustomerId = 1, RentDate = DateTime.Now });
            Console.WriteLine(result.Message);
        }

    }
}


