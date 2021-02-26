using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfCountOfCarImageCorrect(carImage.ImageId));
            if (result!=null)
            {
                return result;
            }
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.ImageAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.ImageDeleted);

        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }
       
        public IResult Update(CarImage carImage)
        {
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        private IResult CheckIfCountOfCarImageCorrect(int imageId)
        {
            var result = _carImageDal.GetAll(c => c.ImageId == imageId).Count;
            if (result > 5)
            {
                return new ErrorResult(Messages.CountOfCarImageError);
            }
            return new SuccessResult();
        }
    }
}
