using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utitlities.Security.Hashing
{
    public class HashingHelper
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)//password hash i oluştuurlacak
        {
            using (var hmac= new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));//byte almak için stringi
            }
            //Verilen bir password değerine göre passwordsalt ve passwordhash oluşturuluyor
        }
        public static bool VerifyPasswordHash(string password,  byte[] passwordHash,  byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i]!= passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
     }
 }

