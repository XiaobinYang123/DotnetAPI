// namespace WebApplicationAPI.Data
// {
//     public class seed
//     {
        
//     }
// }

using System.Collections.Generic;
using Newtonsoft.Json;
using WebApplicationAPI.Models;

namespace WebApplicationAPI.Data
{
    public class Seed
    {
        // private readonly DataContext _context;
        // public Seed(DataContext context)
        // {
        //     _context = context;
        // }

        public static void SeedUsers(DataContext context) 
        {
            var userData = System.IO.File.ReadAllText("Data/UserSeedData.json");
            var users = JsonConvert.DeserializeObject<List<User>>(userData);
            foreach (var user in users)
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash("password", out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                user.Username = user.Username.ToLower();

                context.Users.Add(user);
            }

            context.SaveChanges();
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            } 
        }
    }
}