namespace EmployeeDirectory.Web.Migrations
{
    using EmployeeDirectory.Data.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EmployeeDirectory.Web.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "EmployeeDirectory.Web.Models.ApplicationDbContext";
        }

        protected override void Seed(EmployeeDirectory.Web.Models.ApplicationDbContext context)
        {
            context.Offices.AddOrUpdate(o => o.OfficeId
                , new Office { OfficeId = "HOUTX", OfficeName = "Houston", City = "Houston", State = "TX", ChangeDate = DateTime.Now, ChangeUser = "Seth Peters" }
                , new Office { OfficeId = "AUSTX", OfficeName = "Austin", City = "Austin", State = "TX", ChangeDate = DateTime.Now, ChangeUser = "Seth Peters" }
                );
            context.Employees.AddOrUpdate(
                  new Employee { FirstName = "Seth", LastName = "Peters", OfficeId = "HOUTX", Title = "Architect", ChangeDate = DateTime.Now, ChangeUser = "Seth Peters" }
                , new Employee { FirstName = "Michael", LastName = "Smith", OfficeId = "HOUTX", Title = "Architect", ChangeDate = DateTime.Now, ChangeUser = "Seth Peters" }
                , new Employee { FirstName = "Evan", LastName = "James", OfficeId = "AUSTX", Title = "Project Manager", ChangeDate = DateTime.Now, ChangeUser = "Seth Peters" }
                );
            string[] fname = { "Abby", "Albert", "Ashley", "Brian", "Ben", "Chris", "Charles", "Donald", "Emily", "Eric", "Herman", "John", "James", "Jennifer", "Jessica", "Lee",
                                 "Michael", "Mark", "Michelle", "Robert", "Ruby", "Scott", "Stephen", "Steve", "Thomas", "Tracy" };
            string[] lname = { "Smith", "Jones", "Lee", "Chow", "Nguyen", "Michaels", "Roberts", "Peterson", "Young", "Brown", "Bennett", "Bryant", "Johnson" };
            string[] title = { "Manager", "Architect", "Consultant", "Administrator", "Vice President" };
            string[] office = { "HOUTX", "AUSTX" };

            int i = 0;
            foreach (var f in fname)
            {
                foreach (var l in lname)
                {
                    i++;
                    context.Employees.AddOrUpdate(new Employee { FirstName = f, LastName = l, OfficeId = office[i % office.Count()], Title = title[i % title.Count()], ChangeDate = DateTime.Now, ChangeUser = "Seth Peters" });
                }
            }
        }
    }
}