using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarRentalContext>, IRentalDal
    {
       
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (CarRentalContext context =new CarRentalContext())
            {
                var result = from r in context.Rentals
                             join cu in context.Customers on r.CustomerId equals cu.CustomerId
                             join ca in context.Cars on r.CarId equals ca.CarId
                             join u in context.Users on cu.UserID equals u.UserId

                             select new RentalDetailDto
                             {
                                 CarId=ca.CarId,
                                 CarName=ca.CarName,
                                 UserId=u.UserId,
                                 CustomerId=cu.CustomerId,
                                 FirstName=u.FirstName,
                                 LastName=u.LastName,
                                 CompanyName=cu.CompanyName,
                                 RentDate=r.RentDate,
                                 ReturnDate=r.ReturnDate
                             };
                return result.ToList();
                
            }
        }

    }
}
