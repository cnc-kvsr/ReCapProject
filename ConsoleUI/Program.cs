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
            Console.WriteLine("KİRALIK ARAÇ FİLOSU");
            Console.WriteLine("----------------------------");
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCars())
            {
                Console.WriteLine($"Araç Bilgisi : {car.CarName} \n Id : {car.Id} \n Marka : {car.BrandId} \n Renk : {car.ColorId}" +
                    $" \n ModelYılı : {car.ModelYear} \n GünlükFiyat : {car.DailyPrice}TL \n Açıklama : {car.Description}");
                Console.WriteLine("-----------------------------");
            }
            Console.WriteLine();

            //Kullanıcıdan alınan marka Id'sine göre Araç bilgisi getirir.
            Console.Write("Marka Id'si giriniz: ");
            int id = Convert.ToInt32(Console.ReadLine());

            foreach (var car in carManager.GetCarsByBrandId(id))
            {
                Console.WriteLine($"Araç Bilgisi : {car.CarName}");
            }
            Console.WriteLine("-------------------------");

            //Kullanıcıdan alınan renk Id'sine göre Araç bilgisi getirir.
            Console.Write("Renk Id'si giriniz: ");
            int id2 = Convert.ToInt32(Console.ReadLine());

            foreach (var car in carManager.GetCarsByColorId(id2))
            {
                Console.WriteLine($"Araç Bilgisi : {car.CarName}");
            }
            Console.WriteLine();
            Console.WriteLine("------Araç Ekleme------");
            carManager.Add(new Car
            {
                Id=6,
                CarName="Ab",
                BrandId=2,
                ColorId=1,
                DailyPrice=0,
                Description="Dizel",
                ModelYear=2019
            });

            Console.ReadLine();
        }
    }
}
