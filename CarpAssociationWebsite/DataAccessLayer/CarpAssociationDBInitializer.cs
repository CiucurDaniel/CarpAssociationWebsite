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
            base.Seed(context);
        }
    }
}