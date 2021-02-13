using Business.Concrete;
using Business.Constants;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarManager carManager = new CarManager(new EfCarDal());

            //CarList();
            //BringTheColorList();
            //CarDetails();
            //BrandIdCarLİst();
            //ColorIdCarList();
            //AddCar();
            //UpdateCar();
            //DeleteCar();

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result=rentalManager.GetRentalDetailsDto(1);
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarName);
                }
            }
            else
            {
                Console.WriteLine(Messages.CarNotAvailable);
            }
            Console.ReadLine();
        }

        private static void DeleteCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Delete(new Car { CarId = 10 });
            CarDetails();
        }

        private static void UpdateCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Update(new Car
            {
                CarId = 10,
                ColorId = 5
            });
            CarDetails();
            Console.WriteLine();

        }

        private static void AddCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine("------Araç Ekleme------");


            carManager.Add(new Car
            {
                BrandId = 2,
                CarName = "Peugeot",
                ColorId = 5,
                ModelYear = 2020,
                DailyPrice = 200,
                Description = " "
            });

            carManager.Add(new Car
            {
                CarName = "Ab",
                BrandId = 2,
                ColorId = 1,
                DailyPrice = 0,
                Description = "Dizel",
                ModelYear = 2019
            });
        }

        private static void ColorIdCarList()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine("\n------ColorId'ye göre------ ");
            foreach (var car in carManager.GetCarsByColorId(2).Data)
            {
                Console.WriteLine(car.CarName);
            }
        }

        private static void BrandIdCarLİst()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine("\n-----BrandId'ye göre-----");
            foreach (var car in carManager.GetCarsByBrandId(1).Data)
            {
                Console.WriteLine(car.CarName);
            }
        }

        private static void CarDetails()
        {
            Console.WriteLine("Car Details: ");
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine($"{car.CarId}.Araba : {car.CarName} / {car.BrandName} / {car.ColorName} / {car.DailyPrice}TL");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }

        /// <summary>
        /// Araba listesini döner.
        /// </summary>
        private static void CarList()
        {
            Console.WriteLine("KİRALIK ARAÇ FİLOSU");
            Console.WriteLine("----------------------------");

            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine($"Araç Bilgisi : {car.CarName} \n Id : {car.CarId} \n Marka : {car.BrandId} \n Renk : {car.ColorId}" +
                    $" \n ModelYılı : {car.ModelYear} \n GünlükFiyat : {car.DailyPrice}TL \n Açıklama : {car.Description}");
                Console.WriteLine("-----------------------------");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// CarRental veritabanı-Colors Tablosundaki renkleri listeler.
        /// </summary>
        private static void BringTheColorList()
        {
            Console.WriteLine("Araba Renk Listesi: ");
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorName);
            }
            Console.WriteLine();
        }
    }
}
