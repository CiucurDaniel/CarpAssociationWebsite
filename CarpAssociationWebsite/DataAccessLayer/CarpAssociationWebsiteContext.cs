﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using CarpAssociationWebsite.Models;

namespace CarpAssociationWebsite.DataAccessLayer
{
    public class CarpAssociationWebsiteContext : DbContext
    {
        public CarpAssociationWebsiteContext() : base("CarpAssociationWebsiteDatabase")
        {
            // In case of migration errors or changes to model uncomment the above initializer
            //Database.SetInitializer(new DropCreateDatabaseAlways<SportAttendanceManagerContext>());

            // TODO: Create a working custom initializer
            Database.SetInitializer(new DropCreateDatabaseAlways<CarpAssociationWebsiteContext>());
            //Database.SetInitializer(new SportAttendanceManagerInitializer()); // BUG: Does no work throws: entity error when adding Users in the seed method
        }


        // Add the entities
        public DbSet<User> Users { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<MoneySavingsAccount> MoneySavingsAccounts { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<LoanRate> LoanRates { get; set; }  

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Database.SetInitializer<demoEntities>(null);
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}