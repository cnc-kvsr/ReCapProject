using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<List<RentalDetailDto>> GetRentalDetailsDto(int carId);
        IResult CheckReturnDate(int carId);
    }
}
