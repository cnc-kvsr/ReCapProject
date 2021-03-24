using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{CarId=1,BrandId=1,ColorId=1,ModelYear=2018,DailyPrice=150,Description="Manuel Vites"},
                new Car{CarId=2,BrandId=1,ColorId=3,ModelYear=2016,DailyPrice=100,Description="Otomatik vites"},
                new Car{CarId=3,BrandId=2,ColorId=2,ModelYear=2020,DailyPrice=250,Description="Manuel Vites"},
                new Car{CarId=4,BrandId=2,ColorId=4,ModelYear=2019,DailyPrice=200,Description="Benzin,Otomatik vites"},
                new Car{CarId=5,BrandId=3,ColorId=2,ModelYear=2020,DailyPrice=200,Description="Dizel Motor,Manuel Vites"},
                new Car{CarId=6,BrandId=4,ColorId=3,ModelYear=2016,DailyPrice=150,Description="Benzin,Otomatik vites"},
                new Car{CarId=7,BrandId=4,ColorId=1,ModelYear=2018,DailyPrice=200,Description="Dizel Motor,Manuel Vites"},
                new Car{CarId=8,BrandId=5,ColorId=1,ModelYear=2019,DailyPrice=200,Description="Benzin,Otomatik vites"}
            };
        }
        /// <summary>
        /// Sisteme araba kaydı ekler.
        /// </summary>
        /// <param name="car"></param>
        public void Add(Car car) => _cars.Add(car);
       
        /// <summary>
        /// Sistemden araba kaydı siler
        /// </summary>
        /// <param name="car"></param>
        public void Delete(Car car)
        {
            Car carToDelete = _cars.FirstOrDefault(c => c.CarId == car.CarId);

            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sistemdeki arabaların hepsini listeler.
        /// </summary>
        /// <returns>Araba Listesi</returns>
        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sisteme kayıtlı olan arabaları Id numarasına göre listeler.
        /// </summary>
        /// <param name="id">Araba Id'si</param>
        /// <returns></returns>
        public List<Car> GetById(int id)
        {
            return _cars.Where(c => c.CarId == id).ToList();
        }

        public List<Car> GetById(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sisteme kayıtlı olan araba bilgilerini günceller.
        /// </summary>
        /// <param name="car"></param>
        public void Update(Car car)
        {
            Car carToUpdate = _cars.FirstOrDefault(c=> car.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }

        Car IEntityRepository<Car>.GetById(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

    }
}
