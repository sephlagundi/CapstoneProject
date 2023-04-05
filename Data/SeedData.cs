using EMSwebapp.Models;
using Microsoft.EntityFrameworkCore;

namespace EMSwebapp.Data
{
    public static class SeedData
    {
        public static void SeedDefaultData(this ModelBuilder modelBuilder)
        {
            /* modelBuilder.Entity<Employee>().HasData(
                 new Employee(2, "John Padua", DateTime.Now, "lexter.padua17@gmail.com", "09453823795", 1, "very good"),*/



            modelBuilder.Entity<Department>().HasData(
                new Department(1, "IT Department"),
                new Department(2, "Accounting Department"),
                new Department(3, "Human Resources Department"),
                new Department(4, "Marketing Department"));
        }
    }
}

