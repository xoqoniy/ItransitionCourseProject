
using Course_Project.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Data;
using System.Net.Mail;
using System.Security;

namespace Course_Project.Dal.DbContexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }


    #region Creating tables in db
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Collection> Collections { get; set; }
    public virtual DbSet<Item> Items { get; set; }
    public virtual DbSet<Comment> Comments { get; set; }
    public virtual DbSet<CustomField> CustomFields { get; set; }

    #endregion


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>()
            .Property(i => i.CustomFieldValues)
            .HasConversion(
                v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<Dictionary<string, object>>(v)
            );

        //Configure other entity mappings...

            #region Seed

            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = 1,
                    Username = "Safarmurod",
                    Email = "sm.ashurov7@gmail.com",
                    Password = "2005",
                    IsAdmin = true
                },
                new User()
                {
                    Id = 2,
                    Username = "Shahribonu",
                    Email = "Shahribonu@gmail.com",
                    Password = "IELTS7",
                    IsAdmin = true
                },
                new User()
                {
                    Id = 3,
                    Username = "AkmalAziz",
                    Email = "Akmaliygmail.com",
                    Password = "1234",
                },
                new User()
                {
                    Id = 4,
                    Username = "Sasha",
                    Email = "Sasha@gmail.com",
                    Password = "123",
                },
                new User()
                {
                    Id = 5,
                    Username = "Antonio",
                    Email = "Antoniy3@gmail.com",
                    Password = "1232"
                },
                new User()
                {
                    Id = 6,
                    Username = "MarkZuckerberg",
                    Email = "mark@gmail.com",
                    Password = "122"
                });


        base.OnModelCreating(modelBuilder);
    }
    #endregion

}

  