﻿using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
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
                new Car{Id=1,BrandId=1,ColorId=1,ModelYear=2018,DailyPrice=150,Description="Manuel Vites"},
                new Car{Id=2,BrandId=1,ColorId=3,ModelYear=2016,DailyPrice=100,Description="Otomatik vites"},
                new Car{Id=3,BrandId=2,ColorId=2,ModelYear=2020,DailyPrice=250,Description="Manuel Vites"},
                new Car{Id=4,BrandId=2,ColorId=4,ModelYear=2019,DailyPrice=200,Description="Benzin,Otomatik vites"},
                new Car{Id=5,BrandId=3,ColorId=2,ModelYear=2020,DailyPrice=200,Description="Dizel Motor,Manuel Vites"},
                new Car{Id=6,BrandId=4,ColorId=3,ModelYear=2016,DailyPrice=150,Description="Benzin,Otomatik vites"},
                new Car{Id=7,BrandId=4,ColorId=1,ModelYear=2018,DailyPrice=200,Description="Dizel Motor,Manuel Vites"},
                new Car{Id=8,BrandId=5,ColorId=1,ModelYear=2019,DailyPrice=200,Description="Benzin,Otomatik vites"}
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
            Car carToDelete = _cars.FirstOrDefault(c => c.Id == car.Id);

            _cars.Remove(carToDelete);
        }
        /// <summary>
        /// Sistemdeki arabaların hepsini listeler.
        /// </summary>
        /// <returns>Araba Listesi</returns>
        public List<Car> GetAll()
        {
            return _cars;
        }
    /// <summary>
    /// Sisteme kayıtlı olan arabaları Id numarasına göre listeler.
    /// </summary>
    /// <param name="id">Araba Id'si</param>
    /// <returns></returns>
    public List<Car> GetById(int id)
        {
            return _cars.Where(c => c.Id == id).ToList();
        }
        /// <summary>
        /// Sisteme kayıtlı olan araba bilgilerini günceller.
        /// </summary>
        /// <param name="car"></param>
        public void Update(Car car)
        {
            Car carToUpdate = _cars.FirstOrDefault(c=> car.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
