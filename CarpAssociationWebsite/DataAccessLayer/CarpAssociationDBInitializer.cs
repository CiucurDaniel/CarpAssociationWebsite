using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using CarpAssociationWebsite.Controllers;
using CarpAssociationWebsite.Models;

namespace CarpAssociationWebsite.DataAccessLayer
{
    public class CarpAssociationDBInitializer : DropCreateDatabaseAlways<CarpAssociationWebsiteContext>
    {
        protected override void Seed(CarpAssociationWebsiteContext context)
        {
            //IList<User> demoUsers = new List<User>();

            //demoUsers.Add(new User(){FirstName = "Daniel", LastName = "Dny", Email = "ciucur.daniel14@gmail.com", Password = "Pass1234", ConfirmPassword = "Pass1234"});
            //demoUsers.Add(new User() { FirstName = "Alina", LastName = "Sturza", Email = "alina.sturza01@gmail.com", Password = "MyPass123", ConfirmPassword = "MyPass123"});

            //context.Users.AddRange(demoUsers);

            IList<Member> demoMembers = new List<Member>();

            demoMembers.Add(new Member(){FirstName = "Andrei", LastName = "Pop", City = "Orastie", NetIncome = 4000, Address = "Str. Oituz", IsMarried = false, PhoneNumber = "0775647657", PersonalIdentificationNumber = "34234234235234", State = "Hunedoara"});
            demoMembers.Add(new Member() { FirstName = "Denisia", LastName = "Carmen", City = "Orastie", NetIncome = 1200, Address = "Str. Vasile Parvan", IsMarried = false, PhoneNumber = "07756747657", PersonalIdentificationNumber = "34234237685234", State = "Hunedoara" });
            demoMembers.Add(new Member() { FirstName = "Mihai", LastName = "Popescu", City = "Orastie", NetIncome = 2200, Address = "Str. Crisan", IsMarried = true, PhoneNumber = "07756547657", PersonalIdentificationNumber = "34234237685234", State = "Hunedoara" });
            demoMembers.Add(new Member() { FirstName = "Adrian", LastName = "Constatin", City = "Orastie", NetIncome = 3200, Address = "Str. Horia", IsMarried = true, PhoneNumber = "07756747657", PersonalIdentificationNumber = "34234237685234", State = "Hunedoara" });

            demoMembers.Add(new Member() { FirstName = "Geogiana", LastName = "Florina", City = "Orastie", NetIncome = 2200, Address = "Str. Principala", IsMarried = true, PhoneNumber = "07756747757", PersonalIdentificationNumber = "34234467385234", State = "Hunedoara" });
            demoMembers.Add(new Member() { FirstName = "Larisa", LastName = "Voicu", City = "Orastie", NetIncome = 4200, Address = "Str. Horia", IsMarried = false, PhoneNumber = "07756547657", PersonalIdentificationNumber = "34238237685234", State = "Hunedoara" });
            demoMembers.Add(new Member() { FirstName = "Mihai", LastName = "Ionescu", City = "Orastie", NetIncome = 8200, Address = "Str. Crisan", IsMarried = false, PhoneNumber = "07859747657", PersonalIdentificationNumber = "34234237685234", State = "Hunedoara" });

            demoMembers.Add(new Member() { FirstName = "Marin", LastName = "Serban", City = "Orastie", NetIncome = 3500, Address = "Str. Principala", IsMarried = true, PhoneNumber = "07456747757", PersonalIdentificationNumber = "34234237385234", State = "Hunedoara" });
            demoMembers.Add(new Member() { FirstName = "Maria", LastName = "Manole", City = "Orastie", NetIncome = 3400, Address = "Str. Horia", IsMarried = false, PhoneNumber = "07756587657", PersonalIdentificationNumber = "342342376383234", State = "Hunedoara" });
            demoMembers.Add(new Member() { FirstName = "Adrian", LastName = "Cenusa", City = "Orastie", NetIncome = 1200, Address = "Str. Crisan", IsMarried = false, PhoneNumber = "07856747657", PersonalIdentificationNumber = "34484237685234", State = "Hunedoara" });

            context.Members.AddRange(demoMembers);

            context.SaveChanges();


            IList<EconomyAccountInterest> economyAccountInterests = new List<EconomyAccountInterest>()
            {
                new EconomyAccountInterest() {Date = new DateTime(2018, 12, 20), Percentage = 6.6M},
                new EconomyAccountInterest() {Date = new DateTime(2019, 12, 20), Percentage = 5.5M},
                new EconomyAccountInterest() {Date = new DateTime(2020, 12, 20), Percentage = 5.4M},
                new EconomyAccountInterest() {Date = new DateTime(2021, 12, 20), Percentage = 6.3M},
                new EconomyAccountInterest() {Date = new DateTime(2022, 12, 20), Percentage = 5.0M},
            };

            context.EconomyAccountInterests.AddRange(economyAccountInterests);


            IList<LoanRateInterest> loanRateInterests = new List<LoanRateInterest>()
            {
                new LoanRateInterest() {Date = new DateTime(2020, 01, 20), Percentage = 7.2M},
                new LoanRateInterest() {Date = new DateTime(2020, 02, 20), Percentage = 2.5M},
                new LoanRateInterest() {Date = new DateTime(2020, 03, 20), Percentage = 3.4M},
                new LoanRateInterest() {Date = new DateTime(2020, 04, 20), Percentage = 4.3M},
                new LoanRateInterest() {Date = new DateTime(2020, 05, 20), Percentage = 5.0M},
            };

            context.LoanRateInterests.AddRange(loanRateInterests);

            base.Seed(context);
        }
    }
}