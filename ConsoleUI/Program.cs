using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            EducationManager educationManager = new EducationManager(new EfEducationDal());

            var result = educationManager.GetAll();
            foreach (var education in result.Data)
            {
                Console.WriteLine(education.EduName);
            }
            
        }
    }
}
