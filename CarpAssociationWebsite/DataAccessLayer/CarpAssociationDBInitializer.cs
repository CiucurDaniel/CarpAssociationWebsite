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
            demoMembers.Add(new Member() { FirstName = "Denisia", LastName = "Carmen", City = "Timisoara", NetIncome = 1200, Address = "Str. Vasile Parvan", IsMarried = false, PhoneNumber = "07756747657", PersonalIdentificationNumber = "34234237685234", State = "Timisoara" });

            context.Members.AddRange(demoMembers);

            context.SaveChanges();


            IList<EconomyAccountInterest> economyAccountInterests = new List<EconomyAccountInterest>()
            {
                new EconomyAccountInterest() {Date = new DateTime(2018, 12, 20), Percentage = 6.6},
                new EconomyAccountInterest() {Date = new DateTime(2019, 12, 20), Percentage = 5.5},
                new EconomyAccountInterest() {Date = new DateTime(2020, 12, 20), Percentage = 5.4},
                new EconomyAccountInterest() {Date = new DateTime(2021, 12, 20), Percentage = 6.3},
                new EconomyAccountInterest() {Date = new DateTime(2022, 12, 20), Percentage = 5.0},
            };

            context.EconomyAccountInterests.AddRange(economyAccountInterests);


            IList<LoanRateInterest> loanRateInterests = new List<LoanRateInterest>()
            {
                new LoanRateInterest() {Date = new DateTime(2020, 01, 20), Percentage = 7.2},
                new LoanRateInterest() {Date = new DateTime(2020, 02, 20), Percentage = 2.5},
                new LoanRateInterest() {Date = new DateTime(2020, 03, 20), Percentage = 3.4},
                new LoanRateInterest() {Date = new DateTime(2020, 04, 20), Percentage = 4.3},
                new LoanRateInterest() {Date = new DateTime(2020, 05, 20), Percentage = 5.0},
            };

            context.LoanRateInterests.AddRange(loanRateInterests);

            base.Seed(context);
        }
    }
}