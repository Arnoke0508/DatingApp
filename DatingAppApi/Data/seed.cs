using DatingAppApi.Models;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DatingAppApi.Data
{
    public class Seed
    {
        public static void SeedUsers(ApplicationDbContext Context)
        {
            if (!Context.Users.Any())
            {
                var userData = System.IO.File.ReadAllText("Data/UserSeedData.Json");
                var users = JsonConvert.DeserializeObject<List<User>>(userData);
                foreach (var user in users)
                {
                    CreatePasswordHash("password", out byte[] passwordHash, out byte[] passwordSalt);

                    user.PasswordHash = passwordHash;
                    user.PasswordSalt = passwordSalt;
                    user.Username = user.Username.ToLower();
                    Context.Users.Add(user);
                }
                Context.SaveChanges();
            }
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
