﻿using Bussiness.Abstract;
using Core.Results;
using Entity.Concrete;
using Entity.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRentalService:IServiceRepository<Rental>
    {
        IDataResult<List<RentalDetailDto>> GetRentalDtos();


    }
}
