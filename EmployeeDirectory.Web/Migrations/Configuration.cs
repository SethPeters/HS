namespace EmployeeDirectory.Web.Migrations
{
    using EmployeeDirectory.Data.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;
    using EmployeeDirectory.Web.Models;
    using Microsoft.AspNet.Identity;
    using EmployeeDirectory.Data;

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
                , new Office { OfficeId = "HOUTX", OfficeName = "Houston", City = "Houston", State = "TX"}
                , new Office { OfficeId = "AUSTX", OfficeName = "Austin", City = "Austin", State = "TX"}
                );

            context.Employees.AddOrUpdate(
                  new Employee { FirstName = "Seth", LastName = "Peters", OfficeId = "HOUTX", Title = "Architect"}
                , new Employee { FirstName = "Michael", LastName = "Smith", OfficeId = "HOUTX", Title = "Architect"}
                , new Employee { FirstName = "Evan", LastName = "James", OfficeId = "AUSTX", Title = "Project Manager"}
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
                    context.Employees.AddOrUpdate(new Employee { FirstName = f, LastName = l, OfficeId = office[i % office.Count()], Title = title[i % title.Count()]});
                }
            }


            if (!context.Roles.Any(r => r.Name == "HR"))
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                roleManager.Create(new IdentityRole { Name = "HR" });
            }

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            if (!context.Users.Any(u => u.UserName == "seth_peters@yahoo.com"))
            {
                userManager.Create(new ApplicationUser { UserName = "seth_peters@yahoo.com", Email = "seth_peters@yahoo.com" }, "Test");
            }

            if (!context.Users.Any(u => u.UserName == "HR@yahoo.com"))
            {
                var user = new ApplicationUser { UserName = "HR@yahoo.com", Email = "HR@yahoo.com" };
                var adminresult = userManager.Create(user, "Test");
                if (adminresult.Succeeded)
                {
                    userManager.AddToRole(user.Id, "HR");
                }
            }
        }
    }
}