namespace EmployeeDirectory.Data.Migrations
{
    using EmployeeDirectory.Data.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EmployeeDirectory.Data.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EmployeeDirectory.Data.DataContext context)
        {
            context.Offices.AddOrUpdate(o => o.OfficeId
                , new Office { OfficeId = "HOUTX", OfficeName = "Houston", City = "Houston", State = "TX", ChangeDate = DateTime.Now, ChangeUser = "Seth Peters" }
                , new Office { OfficeId = "AUSTX", OfficeName = "Austin", City = "Austin", State = "TX", ChangeDate = DateTime.Now, ChangeUser = "Seth Peters" }
                );
            context.Employees.AddOrUpdate(p => p.EmployeeNo
                , new Employee { FirstName = "Seth", LastName = "Peters", OfficeId = "HOUTX", Title = "Architect", ChangeDate = DateTime.Now, ChangeUser = "Seth Peters" }
                , new Employee { FirstName = "Michael", LastName = "Smith", OfficeId = "HOUTX", Title = "Architect", ChangeDate = DateTime.Now, ChangeUser = "Seth Peters" }
                , new Employee { FirstName = "Evan", LastName = "James", OfficeId = "AUSTX", Title = "Project Manager", ChangeDate = DateTime.Now, ChangeUser = "Seth Peters" }
                );
        }
    }
}