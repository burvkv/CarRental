using Bussiness.Abstract;
using Core;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using Entity.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public List<CarDetailDto> carDetails()
        {
            
            return _carDal.CarDetailDto();
            
        }

        public void Delete(Car entity)
        {
            _carDal.Delete(entity);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public Car GetById(int id)
        {
            return _carDal.GetById(c=>c.Id == id);
        }

        public void Insert(Car entity)
        {
            _carDal.Insert(entity);
        }

        public void Update(Car entity)
        {
            _carDal.Update(entity);
        }
    }
}
