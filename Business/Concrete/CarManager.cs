using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (!(car.CarName.Length <= 2))
            {
                _carDal.Add(car);
            }
            else
            {
                Console.WriteLine("Hatalı giriş yaptınız. 2'den fazla karakter giriniz!");
            }

        }

        public void Delete(Car car)
        {

            _carDal.Delete(car);
        }

        public List<Car> GetCars()
        {
            return _carDal.GetAll(c => c.DailyPrice!=0);
        }

        public List<Car> GetCarsByBrandId(int brandId) => _carDal.GetAll(c => c.BrandId == brandId);


        public List<Car> GetCarsByColorId(int colorId) => _carDal.GetAll(c => c.ColorId == colorId);

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}
