using Business.ValidationRules.FluentValidation;
using Bussiness.Abstract;
using Bussiness.Constants;
using Core;
using Core.Aspect.Autofac;
using Core.Results;
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

        public IDataResult<List<CarDetailDto>> CarDetails()
        {
            //Business codes
            if (DateTime.Now.Hour == 00)//00da bakım başlıyor varsayalım
            {
                return new ErrorDataResult<List<CarDetailDto>>(_carDal.CarDetailDto(), Messages.CarsNotListed);
            }

            else
            {
                return new SuccessDataResult<List<CarDetailDto>>(_carDal.CarDetailDto(), Messages.ListedCars);
            }
            
        }

        public IResult Delete(Car entity)
        {
            _carDal.Delete(entity);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 00)
            {
                return new ErrorDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsNotListed);
            }
            else
            {
                return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.ListedCars);
            }
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.GetById(c => c.Id == id));
        }

        [ValidationAspect(typeof(CarValidator))]

        public IResult Insert(Car entity)
        {
            _carDal.Insert(entity);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Update(Car entity)
        {
            _carDal.Update(entity);
            return new SuccessResult(Messages.CarUpdated);
        }
    }
}
