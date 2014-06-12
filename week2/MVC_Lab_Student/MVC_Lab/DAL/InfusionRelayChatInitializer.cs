/*
 * @author Infusion bootcamp instructors
 * @author Clinton Freeman <clintonfreeman@infusion.com>
 * @date 2014-06-10
 */

using System.Collections.Generic;
using System.Data.Entity;
using MVC_Lab.Models;

namespace MVC_Lab.DAL
{
    public class InfusionRelayChatInitializer : DropCreateDatabaseIfModelChanges<InfusionRelayChatContext>
    {
        protected override void Seed(InfusionRelayChatContext context)
        {
            var users = new List<User>();

            var ned = new User
            {
                UserId = 1,
                UserName = "Ned",
                Password = "123456",
                ConfirmPassword = "123456",
                RealName = "Eddard Stark",
                Email = "Ned@Winterfell.com",
                About = "Winter is Coming"
            };
            users.Add(ned);

            var jaime = new User
            {
                UserId = 2,
                UserName = "TheKingSlayer",
                Password = "123456",
                ConfirmPassword = "123456",
                RealName = "Jaime Lannister",
                Email = "TheKingSlayer@CasterlyRock.com",
                About = "Hear Me Roar!"
            };
            users.Add(jaime);

            var daenerys = new User
            {
                UserId = 3,
                UserName = "Khaleesi",
                Password = "123456",
                ConfirmPassword = "123456",
                RealName = "Daenerys Targaryen",
                Email = "Khaleesi@Dragonstone.com",
                About = "Fire and Blood"
            };
            users.Add(daenerys);

            var petyr = new User
            {
                UserId = 4,
                UserName = "LittleFinger",
                Password = "123456",
                ConfirmPassword = "123456",
                RealName = "Petyr Baelish",
                Email = "LittleFinger@Eyrie.com",
                About = "As High as Honor"
            };
            users.Add(petyr);

            var oberyn = new User
            {
                UserId = 5,
                UserName = "RedViper",
                Password = "123456",
                ConfirmPassword = "123456",
                RealName = "Oberyn Martell",
                Email = "RedViper@Sunspear.com",
                About = "Unbowed, Unbent, Unbroken"
            };
            users.Add(oberyn);

            users.ForEach(u => context.Users.Add(u));
            context.SaveChanges();

            //var friendships = new List<Friendship>
            //    {
            //        new Friendship{ Truster = ned, TrusterId = ned.UserId, Trustee = jaime, TrusteeId = jaime.UserId },
            //        new Friendship{ Truster = ned, TrusterId = ned.UserId, Trustee = petyr, TrusteeId = petyr.UserId },
            //        new Friendship{ Truster = ned, TrusterId = ned.UserId, Trustee = oberyn, TrusteeId = oberyn.UserId },
            //        new Friendship{ Truster = jaime, TrusterId = jaime.UserId, Trustee = petyr, TrusteeId = petyr.UserId },
            //        new Friendship{ Truster = jaime, TrusterId = jaime.UserId, Trustee = oberyn, TrusteeId = oberyn.UserId },
            //        new Friendship{ Truster = jaime, TrusterId = jaime.UserId, Trustee = ned, TrusteeId = ned.UserId },
            //        new Friendship{ Truster = petyr, TrusterId = petyr.UserId, Trustee = oberyn, TrusteeId = oberyn.UserId },
            //        new Friendship{ Truster = oberyn, TrusterId = oberyn.UserId, Trustee = ned, TrusteeId = ned.UserId },
            //        new Friendship{ Truster = oberyn, TrusterId = oberyn.UserId, Trustee = jaime, TrusteeId = jaime.UserId },
            //        new Friendship{ Truster = oberyn, TrusterId = oberyn.UserId, Trustee = petyr, TrusteeId = petyr.UserId },
            //    };
            //friendships.ForEach(f => context.Friendships.Add(f));
            //context.SaveChanges();
        }
    }
}