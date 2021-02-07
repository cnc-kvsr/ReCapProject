using Business.Concrete;
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
            CarManager carManager = new CarManager(new EfCarDal());

            CarList();

            BringTheColorList();

            CarDetails();
            Console.WriteLine();
            Console.WriteLine("-----BrandId'ye göre-----");
            foreach (var car in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine(car.CarName);
            }
            Console.WriteLine();
            Console.WriteLine("------ColorId'ye göre------ ");
            foreach (var car in carManager.GetCarsByColorId(2))
            {
                Console.WriteLine(car.CarName);
            }
            Console.WriteLine();
            carManager.Add(new Car
            {
                BrandId = 2,
                CarName = "Peugeot",
                ColorId = 5,
                ModelYear = 2020,
                DailyPrice = 200,
                Description = " "
            });
            CarDetails();
            Console.WriteLine();
            carManager.Update(new Car
            {
                Id = 10,
                ColorId = 5
            });
            CarDetails();
            Console.WriteLine();
            carManager.Delete(new Car { Id = 10 });
            CarDetails();

            //Console.WriteLine("------Araç Ekleme------");
            //carManager.Add(new Car
            //{
            //    CarName = "Ab",
            //    BrandId = 2,
            //    ColorId = 1,
            //    DailyPrice = 0,
            //    Description = "Dizel",
            //    ModelYear = 2019
            //});

            Console.ReadLine();
        }

        private static void CarDetails()
        {
            Console.WriteLine("Car Details: ");
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine($"{car.CarId}.Araba : {car.CarName} / {car.BrandName} / {car.ColorName} / {car.DailyPrice}TL");
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
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine($"Araç Bilgisi : {car.CarName} \n Id : {car.Id} \n Marka : {car.BrandId} \n Renk : {car.ColorId}" +
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
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }
            Console.WriteLine();
        }
    }
}
