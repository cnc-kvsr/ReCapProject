using Business.Concrete;
using DataAccess.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("KİRALIK ARAÇ FİLOSU");
            Console.WriteLine("----------------------------");
            CarManager carManager = new CarManager(new InMemoryCarDal());
            foreach (var car in carManager.GetCars())
            {
                Console.WriteLine($"Araç Bilgisi \n\n Id : {car.Id} \n\n Marka : {car.BrandId} \n\n Renk : {car.ColorId}" +
                    $" \n\n ModelYılı : {car.ModelYear} \n\n GünlükFiyat : {car.DailyPrice}TL \n\n Açıklama : {car.Description}");
                Console.WriteLine("-----------------------------");
            }
            Console.ReadLine();
        }
    }
}
