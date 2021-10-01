using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonManager personManager = new PersonManager(new EfPersonDal());
            foreach (var item in personManager.GetAll())
            {
                Console.WriteLine(item.PhoneNumber);
            }
        
        }
    }
}
