using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Core.Utilities.Uploads.ImageUploads;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _imageDal;

        public CarImageManager(ICarImageDal imageDal)
        {
            _imageDal = imageDal;
        }



        [CacheAspect]
        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_imageDal.GetAll(), Messages.Listed);
        }



        [CacheAspect]
        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            //return new SuccessDataResult<List<CarImage>>(_imageDal.GetAll(i => i.CarID == carId), Messages.Listed);

            var result = _imageDal.GetAll(i => i.CarId == carId);

            if (result.Count > 0)
            {
                return new SuccessDataResult<List<CarImage>>(result);
            }

            List<CarImage> images = new List<CarImage>();
            images.Add(new CarImage() { CarId = 0, CarImageId = 0, Date = DateTime.Now, ImagePath = "/images/car-rent.png" });

            return new SuccessDataResult<List<CarImage>>(images);
        }



        [CacheAspect]
        public IDataResult<CarImage> GetById(int imageId)
        {
            return new SuccessDataResult<CarImage>(_imageDal.Get(i => i.CarImageId == imageId));

        }



        //[CacheRemoveAspect("ICarImageService.Get")]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            var result = BusinessRules.Run(
                CheckIfImageCount(carImage),
                CheckIfImageExtensionValid(file));

            if (result != null)
            {
                return result;
            }


            carImage.ImagePath = FileHelper.Add(file);
            carImage.Date = DateTime.Now;
            _imageDal.Add(carImage);
            return new SuccessResult("Car image added");

        }

        public IResult AddCollective(IFormFile[] files, CarImage carImage)
        {
            foreach (var file in files)
            {
                carImage = new CarImage { CarId = carImage.CarId };
                Add(file, carImage);
            }
            return new SuccessResult();
        }



        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Update(IFormFile file, CarImage carImage)
        {
            var result = BusinessRules.Run(
               CheckIfImageExtensionValid(file));

            if (result != null)
            {
                return result;
            }

            CarImage oldCarImage = GetById(carImage.CarImageId).Data;
            carImage.ImagePath = FileHelper.Update(file, oldCarImage.ImagePath);
            carImage.Date = DateTime.Now;
            carImage.CarId = oldCarImage.CarId;
            _imageDal.Update(carImage);
            return new SuccessResult("Car image updated");
        }



        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Delete(CarImage carImage)
        {

            string oldPath = GetById(carImage.CarImageId).Data.ImagePath;
            FileHelper.Delete(oldPath);
            _imageDal.Delete(carImage);
            return new SuccessResult(Messages.Deleted);
        }

        private IResult CheckIfImageCount(CarImage carImage)
        {
            List<CarImage> gelAll = _imageDal.GetAll(i => i.CarId == carImage.CarId);
            var result = (gelAll.Count() >= 15);
            if (result)
            {
                return new ErrorResult("Bir aracın en fazla 5 resmi olabilir.");
            }
            return new SuccessResult();
        }

        private IResult CheckIfImageExtensionValid(IFormFile file)
        {
            string[] validImageFileTypes = { ".JPG", ".JPEG", ".PNG", ".TIF", ".TIFF", ".GIF", ".BMP", ".ICO", ".WEBP" };
            var result = validImageFileTypes.Any(t => t == Path.GetExtension(file.FileName).ToUpper());
            if (!result)
            {
                return new ErrorResult("Geçersiz uzantı");
            }
            return new SuccessResult();
        }


    }
}