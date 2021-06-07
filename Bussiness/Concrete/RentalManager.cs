using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Bussiness.Constants;
using Core.Aspect.Autofac;
using Core.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Delete(Rental entity)
        {
            _rentalDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.GetById(r=>r.Id == id));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDtos()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDtos());
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Insert(Rental entity)
        {
            if (_rentalDal.IsFinish(entity.CarId))
            {
                _rentalDal.Insert(entity);
                return new SuccessResult(Messages.CarRented);
            }
            else
            {
                return new ErrorResult(Messages.CarNotRented);
            }
            
            
        }



        public IResult Update(Rental entity)
        {
            _rentalDal.Update(entity);
            return new SuccessResult();
        }
    }
}
